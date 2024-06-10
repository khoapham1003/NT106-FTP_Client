namespace FTPClient
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.txtHost = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.localTreeView = new System.Windows.Forms.TreeView();
            this.remoteTreeView = new System.Windows.Forms.TreeView();
            this.txtLocalPath = new System.Windows.Forms.TextBox();
            this.txtRemotePath = new System.Windows.Forms.TextBox();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRename = new System.Windows.Forms.Button();
            this.txtNewName = new System.Windows.Forms.TextBox();
            this.btnCreateDirectory = new System.Windows.Forms.Button();
            this.txtNewDir = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(12, 12);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(200, 20);
            this.txtHost.TabIndex = 0;
            this.txtHost.Text = "127.0.0.1";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(12, 38);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(200, 20);
            this.txtUsername.TabIndex = 1;
            this.txtUsername.Text = "test1";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(12, 64);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(200, 20);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.Text = "1234";
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(218, 12);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(12, 100);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.localTreeView);
            this.splitContainer1.Panel1.Controls.Add(this.txtLocalPath);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.remoteTreeView);
            this.splitContainer1.Panel2.Controls.Add(this.txtRemotePath);
            this.splitContainer1.Size = new System.Drawing.Size(450, 338);
            this.splitContainer1.SplitterDistance = 169;
            this.splitContainer1.TabIndex = 4;
            // 
            // localTreeView
            // 
            this.localTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.localTreeView.Location = new System.Drawing.Point(0, 0);
            this.localTreeView.Name = "localTreeView";
            this.localTreeView.Size = new System.Drawing.Size(450, 149);
            this.localTreeView.TabIndex = 4;
            this.localTreeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.localTreeView_BeforeExpand);
            this.localTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.localTreeView_AfterSelect);
            // 
            // remoteTreeView
            // 
            this.remoteTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.remoteTreeView.Location = new System.Drawing.Point(0, 0);
            this.remoteTreeView.Name = "remoteTreeView";
            this.remoteTreeView.Size = new System.Drawing.Size(450, 165);
            this.remoteTreeView.TabIndex = 4;
            this.remoteTreeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.remoteTreeView_BeforeExpand);
            this.remoteTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.remoteTreeView_AfterSelect);
            // 
            // txtLocalPath
            // 
            this.txtLocalPath.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtLocalPath.Location = new System.Drawing.Point(0, 149);
            this.txtLocalPath.Name = "txtLocalPath";
            this.txtLocalPath.Size = new System.Drawing.Size(450, 20);
            this.txtLocalPath.TabIndex = 5;
            // 
            // txtRemotePath
            // 
            this.txtRemotePath.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtRemotePath.Location = new System.Drawing.Point(0, 145);
            this.txtRemotePath.Name = "txtRemotePath";
            this.txtRemotePath.Size = new System.Drawing.Size(450, 20);
            this.txtRemotePath.TabIndex = 5;
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(468, 100);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(75, 23);
            this.btnDownload.TabIndex = 6;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(468, 129);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(75, 23);
            this.btnUpload.TabIndex = 7;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(468, 158);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnRename
            // 
            this.btnRename.Location = new System.Drawing.Point(468, 187);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(75, 23);
            this.btnRename.TabIndex = 9;
            this.btnRename.Text = "Rename";
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // txtNewName
            // 
            this.txtNewName.Location = new System.Drawing.Point(549, 189);
            this.txtNewName.Name = "txtNewName";
            this.txtNewName.Size = new System.Drawing.Size(100, 20);
            this.txtNewName.TabIndex = 10;
            // 
            // btnCreateDirectory
            // 
            this.btnCreateDirectory.Location = new System.Drawing.Point(468, 216);
            this.btnCreateDirectory.Name = "btnCreateDirectory";
            this.btnCreateDirectory.Size = new System.Drawing.Size(75, 23);
            this.btnCreateDirectory.TabIndex = 11;
            this.btnCreateDirectory.Text = "Create Dir";
            this.btnCreateDirectory.UseVisualStyleBackColor = true;
            this.btnCreateDirectory.Click += new System.EventHandler(this.btnCreateDirectory_Click);
            // 
            // txtNewDir
            // 
            this.txtNewDir.Location = new System.Drawing.Point(549, 218);
            this.txtNewDir.Name = "txtNewDir";
            this.txtNewDir.Size = new System.Drawing.Size(100, 20);
            this.txtNewDir.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 450);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.txtNewDir);
            this.Controls.Add(this.btnCreateDirectory);
            this.Controls.Add(this.txtNewName);
            this.Controls.Add(this.btnRename);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtHost);
            this.Name = "Form1";
            this.Text = "FTP Client";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView localTreeView;
        private System.Windows.Forms.TreeView remoteTreeView;
        private System.Windows.Forms.TextBox txtLocalPath;
        private System.Windows.Forms.TextBox txtRemotePath;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRename;
        private System.Windows.Forms.TextBox txtNewName;
        private System.Windows.Forms.Button btnCreateDirectory;
        private System.Windows.Forms.TextBox txtNewDir;
    }
}
