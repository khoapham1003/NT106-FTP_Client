using FluentFTP;
using FluentFTP.Exceptions;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FTPClient
{
    public partial class Form1 : Form
    {
        private FtpClient client;
        public Form1()
        {
            InitializeComponent();
            LoadLocalTreeView();
        }

        private void LoadLocalTreeView()
        {
            localTreeView.Nodes.Clear();
            TreeNode rootNode = new TreeNode("C:\\");
            localTreeView.Nodes.Add(rootNode);

            rootNode.Nodes.Add(new TreeNode());
            rootNode.Expand();
        }
        private void LoadLocalDirectoryNodes(TreeNode node)
        {
            string path = node.FullPath;
            try
            {
                string[] directories = Directory.GetDirectories(path);
                string[] files = Directory.GetFiles(path);

                foreach (string directory in directories)
                {
                    string directoryName = Path.GetFileName(directory);
                    var childNode = new TreeNode(directoryName);
                    childNode.Nodes.Add(new TreeNode()); // Add dummy node to make it expandable
                    node.Nodes.Add(childNode);
                }

                foreach (string file in files)
                {
                    string fileName = Path.GetFileName(file);
                    node.Nodes.Add(new TreeNode(fileName));
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during directory access
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadRemoteTreeView(string path)
        {
            remoteTreeView.Nodes.Clear();
            var rootNode = new TreeNode(path);
            remoteTreeView.Nodes.Add(rootNode);
            LoadRemoteDirectoryNodes(rootNode);
        }
        private void LoadRemoteDirectoryNodes(TreeNode node)
        {
            string path = node.FullPath;

            foreach (var item in client.GetListing(path))
            {
                var childNode = new TreeNode(item.Name);
                if (item.Type == FtpObjectType.Directory)
                {
                    childNode.Nodes.Add("Loading..."); // Placeholder to show expand icon
                }
                node.Nodes.Add(childNode);
            }
        }
        private void localTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes.Count > 0 && e.Node.Nodes[0].Text == string.Empty)
            {
                e.Node.Nodes.Clear();
                LoadLocalDirectoryNodes(e.Node);
            }
        }
        private void localTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            txtLocalPath.Text = localTreeView.SelectedNode.FullPath;
        }
        private void remoteTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes[0].Text == "Loading...")
            {
                e.Node.Nodes.Clear();
                LoadRemoteDirectoryNodes(e.Node);
            }
        }
        private void remoteTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            txtRemotePath.Text = remoteTreeView.SelectedNode.FullPath;
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            string host = txtHost.Text;
            string user = txtUsername.Text;
            string pass = txtPassword.Text;
            try
            {
                client = new FtpClient(host)
                {
                    Credentials = new NetworkCredential(user, pass)
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error authenticating: " + ex.Message);
            }

            try
            {
                client.Connect();
                EnableButton(true);
                MessageBox.Show("Connected successfully!");
                LoadRemoteTreeView("/");
                txtRemotePath.Text = "/";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting: " + ex.Message);
            }
        }
        private async void btnDownload_Click(object sender, EventArgs e)
        {
            if (remoteTreeView.SelectedNode == null)
            {
                MessageBox.Show("Please select a file or directory on the FTP server.");
                return;
            }

            string remotePath = remoteTreeView.SelectedNode.FullPath;
            string localPath = localTreeView.SelectedNode.FullPath;

            try
            {
                if (remoteTreeView.SelectedNode.Nodes.Count > 0)
                {
                    string folderName = Path.GetFileName(remotePath.Substring(remotePath.LastIndexOf("\\") + 1));
                    string destinationPath = Path.Combine(localPath, folderName);

                    if (!Directory.Exists(destinationPath))
                    {
                        Directory.CreateDirectory(destinationPath);
                    }

                    await Task.Run(() => client.DownloadDirectory(destinationPath, remotePath, FtpFolderSyncMode.Update, FtpLocalExists.Overwrite, FtpVerify.Retry));
                }
                else
                {
                    string fileName = Path.GetFileName(remotePath);
                    string destinationPath = Path.Combine(localPath, fileName);

                    await Task.Run(() => client.DownloadFile(destinationPath, remotePath, FtpLocalExists.Overwrite, FtpVerify.Retry));
                }

                MessageBox.Show("Download completed!");
                //load
                TreeNode localParentNode = localTreeView.SelectedNode;
                if (localParentNode != null)
                {
                    localParentNode.Nodes.Clear();
                    LoadLocalDirectoryNodes(localParentNode);
                    LoadLocalTreeView();
                }
            }
            catch (FtpCommandException ex)
            {
                MessageBox.Show($"Error downloading file: {ex.Message}");
            }
            catch (FtpException ex)
            {
                MessageBox.Show($"Error while creating directories: {ex.InnerException?.Message}");
            }
        }
        private async void btnUpload_Click(object sender, EventArgs e)
        {
            if (remoteTreeView.SelectedNode == null)
            {
                MessageBox.Show("Please select a destination folder on the FTP server.");
                return;
            }

            string localPath = localTreeView.SelectedNode.FullPath;
            string remotePath = remoteTreeView.SelectedNode.FullPath;
            try
            {
                if (localPath.Contains("."))
                {
                    remotePath += "/" + Path.GetFileName(localPath);
                    await Task.Run(() => client.UploadFile(localPath, remotePath, FtpRemoteExists.Overwrite, true));
                }
                else
                {
                    remotePath += "/" + Path.GetFileName(localPath.Substring(localPath.LastIndexOf("\\") + 1));
                    await Task.Run(() => client.UploadDirectory(localPath, remotePath, FtpFolderSyncMode.Update, FtpRemoteExists.Overwrite, FtpVerify.Retry));
                }

                MessageBox.Show("Upload completed!");

                TreeNode parentNode = remoteTreeView.SelectedNode;
                if (parentNode != null)
                {
                    parentNode.Nodes.Clear();
                    LoadRemoteDirectoryNodes(parentNode);
                }
            }
            catch (FtpCommandException ex)
            {
                MessageBox.Show($"Error uploading file: {ex.Message}");
            }
            catch (FtpException ex)
            {
                MessageBox.Show($"Error while creating directories: {ex.InnerException?.Message}");
            }
        }
        private void btnCreateDirectory_Click(object sender, EventArgs e)
        {
            string directoryName = txtNewDir.Text.Trim();

            if (remoteTreeView.SelectedNode == null)
            {
                MessageBox.Show("Please select a destination folder on the FTP server.");
                return;
            }

            if (string.IsNullOrEmpty(directoryName))
            {
                MessageBox.Show("Please enter a directory name.");
                return;
            }

            string remotePath = remoteTreeView.SelectedNode.FullPath + "/" + directoryName;

            try
            {
                client.CreateDirectory(remotePath);
                MessageBox.Show("Directory created successfully!");

                remoteTreeView.SelectedNode.Nodes.Add(new TreeNode(directoryName));
                remoteTreeView.SelectedNode.Expand();
                txtNewDir.Clear();
            }
            catch (FtpCommandException ex)
            {
                MessageBox.Show($"Error creating directory: {ex.Message}");
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (remoteTreeView.SelectedNode == null)
            {
                MessageBox.Show("Please select a file or directory on the FTP server.");
                return;
            }

            string remotePath = remoteTreeView.SelectedNode.FullPath;

            try
            {
                if (remoteTreeView.SelectedNode.Nodes.Count > 0)
                {
                    MessageBox.Show("Please delete all files and subdirectories before deleting this directory.");
                    return;
                }
                else if (remotePath.Contains("."))
                {
                    if (MessageBox.Show("Do you really want to delete this file?",
                       "Delete File",
                       MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        client.DeleteFile(remotePath);
                        MessageBox.Show("File deleted successfully!");
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    if (MessageBox.Show("Do you really want to delete this folder?",
                      "Delete Folder",
                      MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        client.DeleteDirectory(remotePath);
                        MessageBox.Show("Directory deleted successfully!");
                    }
                    else
                    {
                        return;
                    }

                }
                remoteTreeView.SelectedNode.Remove();
                remoteTreeView.Refresh();
            }
            catch (FtpCommandException ex)
            {
                MessageBox.Show($"Error deleting: {ex.Message}");
            }
        }
        private void btnRename_Click(object sender, EventArgs e)
        {
            if (remoteTreeView.SelectedNode == null)
            {
                MessageBox.Show("Please select a file or directory on the FTP server.");
                return;
            }

            string remotePath = remoteTreeView.SelectedNode.FullPath;
            string newName = txtNewName.Text.Trim();

            if (string.IsNullOrEmpty(newName))
            {
                MessageBox.Show("Please enter a new name.");
                return;
            }
            try
            {
                if (remotePath.Contains("."))
                {
                    string extension = remotePath.Substring(remotePath.LastIndexOf("."));
                    newName += extension;
                }
                string newPath = Path.GetDirectoryName(remotePath) + "/" + newName;

                client.Rename(remotePath, newPath);
                MessageBox.Show("Rename completed!");

                remoteTreeView.SelectedNode.Text = newName;
                txtNewName.Clear();
            }
            catch (FtpCommandException ex)
            {
                MessageBox.Show($"Error renaming: {ex.Message}");
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (client != null && client.IsConnected)
            {
                client.Disconnect();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            TreeNode localParentNode = localTreeView.SelectedNode;
            if (localParentNode != null)
            {
                localParentNode.Nodes.Clear();
                LoadLocalDirectoryNodes(localParentNode);
                LoadLocalTreeView();
            }
            TreeNode remoteParentNode = remoteTreeView.SelectedNode;
            if (remoteParentNode != null)
            {
                remoteParentNode.Nodes.Clear();
                LoadRemoteDirectoryNodes(remoteParentNode);
            }
        }
        private void EnableButton(bool connected)
        {
            if (connected)
            {
                btnConnect.Visible = false;
                btnDisconnect.Visible = true;
                pnConnect.Visible = false;
                pnFeatures.Visible = true;
                btnRefresh.Location = new Point(939, 43);
            }
            else
            {
                btnConnect.Visible = true;
                btnDisconnect.Visible = false;
                pnConnect.Visible = true;
                pnFeatures.Visible = false;
                btnRefresh.Location = new Point(500, 43);
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            if (client != null && client.IsConnected)
            {
                EnableButton(false);
                client.Disconnect();
            }
        }
    }
}
