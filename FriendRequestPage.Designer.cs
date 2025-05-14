namespace QQChat
{
    partial class FriendRequestPage
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
            this.dgvFriendRequestsReceived = new System.Windows.Forms.DataGridView();
            this.btnAcceptRequest = new System.Windows.Forms.Button();
            this.btnDeclineRequest = new System.Windows.Forms.Button();
            this.btnRefreshRequests = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFriendRequestsReceived)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvFriendRequestsReceived
            // 
            this.dgvFriendRequestsReceived.AllowUserToAddRows = false;
            this.dgvFriendRequestsReceived.AllowUserToDeleteRows = false;
            this.dgvFriendRequestsReceived.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFriendRequestsReceived.Location = new System.Drawing.Point(12, 12);
            this.dgvFriendRequestsReceived.MultiSelect = false;
            this.dgvFriendRequestsReceived.Name = "dgvFriendRequestsReceived";
            this.dgvFriendRequestsReceived.ReadOnly = true;
            this.dgvFriendRequestsReceived.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFriendRequestsReceived.Size = new System.Drawing.Size(776, 350);
            this.dgvFriendRequestsReceived.TabIndex = 0;
            // 
            // btnAcceptRequest
            // 
            this.btnAcceptRequest.Location = new System.Drawing.Point(12, 380);
            this.btnAcceptRequest.Name = "btnAcceptRequest";
            this.btnAcceptRequest.Size = new System.Drawing.Size(100, 30);
            this.btnAcceptRequest.TabIndex = 1;
            this.btnAcceptRequest.Text = "接受申请";
            this.btnAcceptRequest.UseVisualStyleBackColor = true;
            this.btnAcceptRequest.Click += new System.EventHandler(this.btnAcceptRequest_Click);
            // 
            // btnDeclineRequest
            // 
            this.btnDeclineRequest.Location = new System.Drawing.Point(132, 380);
            this.btnDeclineRequest.Name = "btnDeclineRequest";
            this.btnDeclineRequest.Size = new System.Drawing.Size(100, 30);
            this.btnDeclineRequest.TabIndex = 2;
            this.btnDeclineRequest.Text = "拒绝申请";
            this.btnDeclineRequest.UseVisualStyleBackColor = true;
            this.btnDeclineRequest.Click += new System.EventHandler(this.btnDeclineRequest_Click);
            // 
            // btnRefreshRequests
            // 
            this.btnRefreshRequests.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshRequests.Location = new System.Drawing.Point(688, 380);
            this.btnRefreshRequests.Name = "btnRefreshRequests";
            this.btnRefreshRequests.Size = new System.Drawing.Size(100, 30);
            this.btnRefreshRequests.TabIndex = 3;
            this.btnRefreshRequests.Text = "刷新列表";
            this.btnRefreshRequests.UseVisualStyleBackColor = true;
            this.btnRefreshRequests.Click += new System.EventHandler(this.btnRefreshRequests_Click);
            // 
            // FriendRequestPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRefreshRequests);
            this.Controls.Add(this.btnDeclineRequest);
            this.Controls.Add(this.btnAcceptRequest);
            this.Controls.Add(this.dgvFriendRequestsReceived);
            this.Name = "FriendRequestPage";
            this.Text = "收到的好友申请";
            this.Load += new System.EventHandler(this.FriendRequestPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFriendRequestsReceived)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvFriendRequestsReceived;
        private System.Windows.Forms.Button btnAcceptRequest;
        private System.Windows.Forms.Button btnDeclineRequest;
        private System.Windows.Forms.Button btnRefreshRequests;
    }
} 