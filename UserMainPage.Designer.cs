namespace QQChat
{
    partial class UserMainPage
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
            this.menuStripUser = new System.Windows.Forms.MenuStrip();
            this.miManageInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.miFriendRequests = new System.Windows.Forms.ToolStripMenuItem();
            this.miMyRequests = new System.Windows.Forms.ToolStripMenuItem();
            this.miFriendList = new System.Windows.Forms.ToolStripMenuItem();
            this.miHistoryMessages = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripUser
            // 
            this.menuStripUser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miManageInfo,
            this.miFriendRequests,
            this.miMyRequests,
            this.miFriendList,
            this.miHistoryMessages});
            this.menuStripUser.Location = new System.Drawing.Point(0, 0);
            this.menuStripUser.Name = "menuStripUser";
            this.menuStripUser.Size = new System.Drawing.Size(800, 24);
            this.menuStripUser.TabIndex = 0;
            this.menuStripUser.Text = "menuStrip1";
            // 
            // miManageInfo
            // 
            this.miManageInfo.Name = "miManageInfo";
            this.miManageInfo.Size = new System.Drawing.Size(68, 20);
            this.miManageInfo.Text = "个人信息";
            this.miManageInfo.Click += new System.EventHandler(this.miManageInfo_Click);
            // 
            // miFriendRequests
            // 
            this.miFriendRequests.Name = "miFriendRequests";
            this.miFriendRequests.Size = new System.Drawing.Size(92, 20);
            this.miFriendRequests.Text = "查看好友申请";
            this.miFriendRequests.Click += new System.EventHandler(this.miFriendRequests_Click);
            // 
            // miMyRequests
            // 
            this.miMyRequests.Name = "miMyRequests";
            this.miMyRequests.Size = new System.Drawing.Size(92, 20);
            this.miMyRequests.Text = "我的好友申请";
            this.miMyRequests.Click += new System.EventHandler(this.miMyRequests_Click);
            // 
            // miFriendList
            // 
            this.miFriendList.Name = "miFriendList";
            this.miFriendList.Size = new System.Drawing.Size(68, 20);
            this.miFriendList.Text = "好友列表";
            this.miFriendList.Click += new System.EventHandler(this.miFriendList_Click);
            // 
            // miHistoryMessages
            // 
            this.miHistoryMessages.Name = "miHistoryMessages";
            this.miHistoryMessages.Size = new System.Drawing.Size(68, 20);
            this.miHistoryMessages.Text = "历史消息";
            this.miHistoryMessages.Click += new System.EventHandler(this.miHistoryMessages_Click);
            // 
            // UserMainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStripUser);
            this.MainMenuStrip = this.menuStripUser;
            this.Name = "UserMainPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户主页";
            this.menuStripUser.ResumeLayout(false);
            this.menuStripUser.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripUser;
        private System.Windows.Forms.ToolStripMenuItem miManageInfo;
        private System.Windows.Forms.ToolStripMenuItem miFriendRequests;
        private System.Windows.Forms.ToolStripMenuItem miMyRequests;
        private System.Windows.Forms.ToolStripMenuItem miFriendList;
        private System.Windows.Forms.ToolStripMenuItem miHistoryMessages;
    }
} 