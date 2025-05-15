namespace QQChat
{
    partial class AdminMainPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStripAdmin = new System.Windows.Forms.MenuStrip();
            this.miReviewRegistration = new System.Windows.Forms.ToolStripMenuItem();
            this.miBanAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.miManageMessages = new System.Windows.Forms.ToolStripMenuItem();
            this.miLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripAdmin.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripAdmin
            // 
            this.menuStripAdmin.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStripAdmin.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStripAdmin.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miReviewRegistration,
            this.miBanAccount,
            this.miManageMessages,
            this.miLogout});
            this.menuStripAdmin.Location = new System.Drawing.Point(0, 0);
            this.menuStripAdmin.Name = "menuStripAdmin";
            this.menuStripAdmin.Size = new System.Drawing.Size(1510, 48);
            this.menuStripAdmin.TabIndex = 0;
            this.menuStripAdmin.Text = "menuStrip1";
            // 
            // miReviewRegistration
            // 
            this.miReviewRegistration.Name = "miReviewRegistration";
            this.miReviewRegistration.Size = new System.Drawing.Size(130, 44);
            this.miReviewRegistration.Text = "审核注册";
            this.miReviewRegistration.Click += new System.EventHandler(this.miReviewRegistration_Click);
            // 
            // miBanAccount
            // 
            this.miBanAccount.Name = "miBanAccount";
            this.miBanAccount.Size = new System.Drawing.Size(130, 44);
            this.miBanAccount.Text = "账号管理";
            this.miBanAccount.Click += new System.EventHandler(this.miBanAccount_Click);
            // 
            // miManageMessages
            // 
            this.miManageMessages.Name = "miManageMessages";
            this.miManageMessages.Size = new System.Drawing.Size(130, 44);
            this.miManageMessages.Text = "消息管理";
            this.miManageMessages.Click += new System.EventHandler(this.miManageMessages_Click);
            // 
            // miLogout
            // 
            this.miLogout.Name = "miLogout";
            this.miLogout.Size = new System.Drawing.Size(130, 44);
            this.miLogout.Text = "退出登录";
            this.miLogout.Click += new System.EventHandler(this.miLogout_Click);
            // 
            // AdminMainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1510, 933);
            this.Controls.Add(this.menuStripAdmin);
            this.MainMenuStrip = this.menuStripAdmin;
            this.Name = "AdminMainPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "管理员主页";
            this.menuStripAdmin.ResumeLayout(false);
            this.menuStripAdmin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripAdmin;
        private System.Windows.Forms.ToolStripMenuItem miReviewRegistration;
        private System.Windows.Forms.ToolStripMenuItem miBanAccount;
        private System.Windows.Forms.ToolStripMenuItem miManageMessages;
        private System.Windows.Forms.ToolStripMenuItem miLogout;
    }
} 