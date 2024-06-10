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

            rootNode.Nodes.Add(new TreeNode()); // Add dummy node to make it expandable

            rootNode.Expand();
        }

        private void localTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes.Count > 0 && e.Node.Nodes[0].Text == string.Empty)
            {
                e.Node.Nodes.Clear();
                LoadLocalDirectoryNodes(e.Node);
            }
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

        private void localTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            txtLocalPath.Text = localTreeView.SelectedNode.FullPath;
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

            client = new FtpClient(host)
            {
                Credentials = new NetworkCredential(user, pass)
            };

            try
            {
                client.Connect();
                MessageBox.Show("Connected successfully!");
                LoadDirectoryTree("/");
                txtRemotePath.Text = "/";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to server: " + ex.Message);
            }
        }

        private void LoadDirectoryTree(string path)
        {
            remoteTreeView.Nodes.Clear();
            var rootNode = new TreeNode(path);
            remoteTreeView.Nodes.Add(rootNode);
            LoadDirectoryNodes(rootNode);
        }

        private void LoadDirectoryNodes(TreeNode node)
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

        private void remoteTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes[0].Text == "Loading...")
            {
                e.Node.Nodes.Clear();
                LoadDirectoryNodes(e.Node);
            }
        }

        private async void btnDownload_Click(object sender, EventArgs e)
        {
            if (remoteTreeView.SelectedNode == null)
            {
                MessageBox.Show("Please select a file on the FTP server.");
                return;
            }

            string remotePath = remoteTreeView.SelectedNode.FullPath;
            string localPath = localTreeView.SelectedNode.FullPath;
            string fileName = Path.GetFileName(remotePath); // Lấy tên tệp tin từ đường dẫn

            string destinationPath = Path.Combine(localPath, fileName); // Kết hợp đường dẫn thư mục đích và tên tệp tin

            try
            {
                await Task.Run(() => client.DownloadFile(destinationPath, remotePath, FtpLocalExists.Overwrite, FtpVerify.Retry));
                MessageBox.Show("Download completed!");

                TreeNode parentNode = remoteTreeView.SelectedNode.Parent;
                if (parentNode != null)
                {
                    parentNode.Nodes.Clear();
                    LoadDirectoryNodes(parentNode);
                }
                TreeNode localParentNode = localTreeView.SelectedNode.Parent;
                if (localParentNode != null)
                {
                    localParentNode.Nodes.Clear();
                    LoadLocalDirectoryNodes(localParentNode);
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
            string remotePath = remoteTreeView.SelectedNode.FullPath + "/" + Path.GetFileName(localPath);

            try
            {
                await Task.Run(() => client.UploadFile(localPath, remotePath, FtpRemoteExists.Overwrite, true));
                MessageBox.Show("Upload completed!");

                TreeNode parentNode = remoteTreeView.SelectedNode;

                if (parentNode != null)
                {
                    parentNode.Nodes.Clear();
                    LoadDirectoryNodes(parentNode);
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

                client.DeleteDirectory(remotePath);
                MessageBox.Show("Directory deleted successfully!");

                remoteTreeView.SelectedNode.Remove();
            }
            catch (FtpCommandException ex)
            {
                MessageBox.Show($"Error deleting directory: {ex.Message}");
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

            string newPath = Path.GetDirectoryName(remotePath) + "/" + newName;

            try
            {
                client.Rename(remotePath, newPath);
                MessageBox.Show("Rename completed!");

                remoteTreeView.SelectedNode.Text = newName;
                txtNewName.Clear();
            }
            catch (FtpCommandException ex)
            {
                MessageBox.Show($"Error renaming file or directory: {ex.Message}");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (client != null && client.IsConnected)
            {
                client.Disconnect();
            }
        }
    }
}