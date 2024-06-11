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
            txtHost = new TextBox();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            btnConnect = new Button();
            localTreeView = new TreeView();
            txtLocalPath = new TextBox();
            remoteTreeView = new TreeView();
            txtRemotePath = new TextBox();
            btnDownload = new Button();
            btnUpload = new Button();
            btnDelete = new Button();
            btnRename = new Button();
            txtNewName = new TextBox();
            btnCreateDirectory = new Button();
            txtNewDir = new TextBox();
            btnRefresh = new Button();
            btnDisconnect = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            lvLocal = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            lvRemote = new ListView();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            columnHeader8 = new ColumnHeader();
            pnConnect = new Panel();
            pnFeatures = new Panel();
            pnConnect.SuspendLayout();
            pnFeatures.SuspendLayout();
            SuspendLayout();
            // 
            // txtHost
            // 
            txtHost.Location = new Point(75, 6);
            txtHost.Margin = new Padding(4);
            txtHost.Name = "txtHost";
            txtHost.Size = new Size(233, 23);
            txtHost.TabIndex = 0;
            txtHost.Text = "127.0.0.1";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(75, 41);
            txtUsername.Margin = new Padding(4);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(233, 23);
            txtUsername.TabIndex = 1;
            txtUsername.Text = "test1";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(74, 74);
            txtPassword.Margin = new Padding(4);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(233, 23);
            txtPassword.TabIndex = 2;
            txtPassword.Text = "1234";
            txtPassword.UseSystemPasswordChar = true;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(14, 34);
            btnConnect.Margin = new Padding(4);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(140, 44);
            btnConnect.TabIndex = 3;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // localTreeView
            // 
            localTreeView.Location = new Point(12, 146);
            localTreeView.Margin = new Padding(4);
            localTreeView.Name = "localTreeView";
            localTreeView.Size = new Size(530, 177);
            localTreeView.TabIndex = 4;
            localTreeView.BeforeExpand += localTreeView_BeforeExpand;
            localTreeView.AfterSelect += localTreeView_AfterSelect;
            // 
            // txtLocalPath
            // 
            txtLocalPath.Location = new Point(14, 116);
            txtLocalPath.Margin = new Padding(4);
            txtLocalPath.Name = "txtLocalPath";
            txtLocalPath.ReadOnly = true;
            txtLocalPath.Size = new Size(526, 23);
            txtLocalPath.TabIndex = 5;
            // 
            // remoteTreeView
            // 
            remoteTreeView.Location = new Point(551, 146);
            remoteTreeView.Margin = new Padding(4);
            remoteTreeView.Name = "remoteTreeView";
            remoteTreeView.Size = new Size(530, 177);
            remoteTreeView.TabIndex = 6;
            remoteTreeView.BeforeExpand += remoteTreeView_BeforeExpand;
            remoteTreeView.AfterSelect += remoteTreeView_AfterSelect;
            // 
            // txtRemotePath
            // 
            txtRemotePath.Location = new Point(551, 116);
            txtRemotePath.Margin = new Padding(4);
            txtRemotePath.Name = "txtRemotePath";
            txtRemotePath.ReadOnly = true;
            txtRemotePath.Size = new Size(530, 23);
            txtRemotePath.TabIndex = 7;
            // 
            // btnDownload
            // 
            btnDownload.Location = new Point(22, 10);
            btnDownload.Margin = new Padding(4);
            btnDownload.Name = "btnDownload";
            btnDownload.Size = new Size(150, 35);
            btnDownload.TabIndex = 8;
            btnDownload.Text = "Download";
            btnDownload.UseVisualStyleBackColor = true;
            btnDownload.Click += btnDownload_Click;
            // 
            // btnUpload
            // 
            btnUpload.Location = new Point(22, 57);
            btnUpload.Margin = new Padding(4);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(150, 35);
            btnUpload.TabIndex = 9;
            btnUpload.Text = "Upload";
            btnUpload.UseVisualStyleBackColor = true;
            btnUpload.Click += btnUpload_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(191, 31);
            btnDelete.Margin = new Padding(4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(150, 35);
            btnDelete.TabIndex = 10;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnRename
            // 
            btnRename.Location = new Point(365, 57);
            btnRename.Margin = new Padding(4);
            btnRename.Name = "btnRename";
            btnRename.Size = new Size(150, 35);
            btnRename.TabIndex = 11;
            btnRename.Text = "Rename";
            btnRename.UseVisualStyleBackColor = true;
            btnRename.Click += btnRename_Click;
            // 
            // txtNewName
            // 
            txtNewName.Location = new Point(523, 64);
            txtNewName.Margin = new Padding(4);
            txtNewName.Name = "txtNewName";
            txtNewName.Size = new Size(164, 23);
            txtNewName.TabIndex = 12;
            // 
            // btnCreateDirectory
            // 
            btnCreateDirectory.Location = new Point(365, 5);
            btnCreateDirectory.Margin = new Padding(4);
            btnCreateDirectory.Name = "btnCreateDirectory";
            btnCreateDirectory.Size = new Size(150, 35);
            btnCreateDirectory.TabIndex = 13;
            btnCreateDirectory.Text = "Create Dir";
            btnCreateDirectory.UseVisualStyleBackColor = true;
            btnCreateDirectory.Click += btnCreateDirectory_Click;
            // 
            // txtNewDir
            // 
            txtNewDir.Location = new Point(523, 12);
            txtNewDir.Margin = new Padding(4);
            txtNewDir.Name = "txtNewDir";
            txtNewDir.Size = new Size(164, 23);
            txtNewDir.TabIndex = 14;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(500, 38);
            btnRefresh.Margin = new Padding(4);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(142, 43);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnDisconnect
            // 
            btnDisconnect.Location = new Point(14, 34);
            btnDisconnect.Margin = new Padding(4);
            btnDisconnect.Name = "btnDisconnect";
            btnDisconnect.Size = new Size(140, 44);
            btnDisconnect.TabIndex = 3;
            btnDisconnect.Text = "Disconnect";
            btnDisconnect.UseVisualStyleBackColor = true;
            btnDisconnect.Visible = false;
            btnDisconnect.Click += btnDisconnect_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 9);
            label1.Name = "label1";
            label1.Size = new Size(35, 15);
            label1.TabIndex = 15;
            label1.Text = "Host:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 43);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 15;
            label2.Text = "Username:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 77);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 15;
            label3.Text = "Password:";
            // 
            // lvLocal
            // 
            lvLocal.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4 });
            lvLocal.Location = new Point(12, 328);
            lvLocal.Name = "lvLocal";
            lvLocal.Size = new Size(530, 248);
            lvLocal.TabIndex = 16;
            lvLocal.UseCompatibleStateImageBehavior = false;
            lvLocal.View = View.Details;
            lvLocal.ItemActivate += lvLocal_ItemActivate;
            lvLocal.SelectedIndexChanged += lvLocal_SelectedIndexChanged;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Filename";
            columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Filesize";
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Filetype";
            columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Last modified";
            columnHeader4.Width = 150;
            // 
            // lvRemote
            // 
            lvRemote.Columns.AddRange(new ColumnHeader[] { columnHeader5, columnHeader6, columnHeader7, columnHeader8 });
            lvRemote.Location = new Point(551, 328);
            lvRemote.Name = "lvRemote";
            lvRemote.Size = new Size(530, 248);
            lvRemote.TabIndex = 17;
            lvRemote.UseCompatibleStateImageBehavior = false;
            lvRemote.View = View.Details;
            lvRemote.ItemActivate += lvRemote_ItemActivate;
            lvRemote.SelectedIndexChanged += lvRemote_SelectedIndexChanged;
            lvRemote.Click += lvRemote_Click;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Filename";
            columnHeader5.Width = 200;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Filesize";
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "Filetype";
            columnHeader7.Width = 100;
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "Last modified";
            columnHeader8.Width = 150;
            // 
            // pnConnect
            // 
            pnConnect.Controls.Add(label1);
            pnConnect.Controls.Add(txtHost);
            pnConnect.Controls.Add(txtUsername);
            pnConnect.Controls.Add(label3);
            pnConnect.Controls.Add(txtPassword);
            pnConnect.Controls.Add(label2);
            pnConnect.Location = new Point(171, 9);
            pnConnect.Name = "pnConnect";
            pnConnect.Size = new Size(323, 101);
            pnConnect.TabIndex = 18;
            // 
            // pnFeatures
            // 
            pnFeatures.Controls.Add(btnDownload);
            pnFeatures.Controls.Add(txtNewDir);
            pnFeatures.Controls.Add(btnCreateDirectory);
            pnFeatures.Controls.Add(txtNewName);
            pnFeatures.Controls.Add(btnRename);
            pnFeatures.Controls.Add(btnDelete);
            pnFeatures.Controls.Add(btnUpload);
            pnFeatures.Location = new Point(213, 8);
            pnFeatures.Name = "pnFeatures";
            pnFeatures.Size = new Size(691, 102);
            pnFeatures.TabIndex = 19;
            pnFeatures.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1095, 589);
            Controls.Add(pnFeatures);
            Controls.Add(pnConnect);
            Controls.Add(lvRemote);
            Controls.Add(lvLocal);
            Controls.Add(localTreeView);
            Controls.Add(txtLocalPath);
            Controls.Add(remoteTreeView);
            Controls.Add(txtRemotePath);
            Controls.Add(btnRefresh);
            Controls.Add(btnDisconnect);
            Controls.Add(btnConnect);
            Margin = new Padding(4);
            Name = "Form1";
            Text = "FTP Client";
            Load += Form1_Load;
            pnConnect.ResumeLayout(false);
            pnConnect.PerformLayout();
            pnFeatures.ResumeLayout(false);
            pnFeatures.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnConnect;
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
        private Button btnRefresh;
        private Button btnDisconnect;
        private Label label1;
        private Label label2;
        private Label label3;
        private ListView lvLocal;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ListView lvRemote;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private Panel pnConnect;
        private Panel pnFeatures;
    }
}
