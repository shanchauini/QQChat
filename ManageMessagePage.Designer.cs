namespace QQChat
{
    partial class ManageMessagePage
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
            this.lblSearchContent = new System.Windows.Forms.Label();
            this.txtSearchContent = new System.Windows.Forms.TextBox();
            this.lblSearchSenderId = new System.Windows.Forms.Label();
            this.txtSearchSenderId = new System.Windows.Forms.TextBox();
            this.btnSearchMessages = new System.Windows.Forms.Button();
            this.dgvMessages = new System.Windows.Forms.DataGridView();
            this.btnDeleteMessage = new System.Windows.Forms.Button();
            this.btnRefreshMessageList = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMessages)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSearchContent
            // 
            this.lblSearchContent.AutoSize = true;
            this.lblSearchContent.Location = new System.Drawing.Point(12, 15);
            this.lblSearchContent.Name = "lblSearchContent";
            this.lblSearchContent.TabIndex = 0;
            this.lblSearchContent.Text = "消息内容:";
            // 
            // txtSearchContent
            // 
            this.txtSearchContent.Location = new System.Drawing.Point(77, 12);
            this.txtSearchContent.Name = "txtSearchContent";
            this.txtSearchContent.Size = new System.Drawing.Size(150, 20);
            this.txtSearchContent.TabIndex = 1;
            // 
            // lblSearchSenderId
            // 
            this.lblSearchSenderId.AutoSize = true;
            this.lblSearchSenderId.Location = new System.Drawing.Point(240, 15);
            this.lblSearchSenderId.Name = "lblSearchSenderId";
            this.lblSearchSenderId.TabIndex = 2;
            this.lblSearchSenderId.Text = "发送者ID:";
            // 
            // txtSearchSenderId
            // 
            this.txtSearchSenderId.Location = new System.Drawing.Point(305, 12);
            this.txtSearchSenderId.Name = "txtSearchSenderId";
            this.txtSearchSenderId.Size = new System.Drawing.Size(100, 20);
            this.txtSearchSenderId.TabIndex = 3;
            // 
            // btnSearchMessages
            // 
            this.btnSearchMessages.Location = new System.Drawing.Point(420, 10);
            this.btnSearchMessages.Name = "btnSearchMessages";
            this.btnSearchMessages.Size = new System.Drawing.Size(75, 23);
            this.btnSearchMessages.TabIndex = 4;
            this.btnSearchMessages.Text = "搜索消息";
            this.btnSearchMessages.UseVisualStyleBackColor = true;
            this.btnSearchMessages.Click += new System.EventHandler(this.btnSearchMessages_Click);
            // 
            // dgvMessages
            // 
            this.dgvMessages.AllowUserToAddRows = false;
            this.dgvMessages.AllowUserToDeleteRows = false;
            this.dgvMessages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMessages.Location = new System.Drawing.Point(12, 45);
            this.dgvMessages.MultiSelect = false;
            this.dgvMessages.Name = "dgvMessages";
            this.dgvMessages.ReadOnly = true;
            this.dgvMessages.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMessages.Size = new System.Drawing.Size(776, 317);
            this.dgvMessages.TabIndex = 5;
            // 
            // btnDeleteMessage
            // 
            this.btnDeleteMessage.Location = new System.Drawing.Point(12, 380);
            this.btnDeleteMessage.Name = "btnDeleteMessage";
            this.btnDeleteMessage.Size = new System.Drawing.Size(100, 30);
            this.btnDeleteMessage.TabIndex = 6;
            this.btnDeleteMessage.Text = "删除选中消息";
            this.btnDeleteMessage.UseVisualStyleBackColor = true;
            this.btnDeleteMessage.Click += new System.EventHandler(this.btnDeleteMessage_Click);
            // 
            // btnRefreshMessageList
            // 
            this.btnRefreshMessageList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshMessageList.Location = new System.Drawing.Point(688, 380);
            this.btnRefreshMessageList.Name = "btnRefreshMessageList";
            this.btnRefreshMessageList.Size = new System.Drawing.Size(100, 30);
            this.btnRefreshMessageList.TabIndex = 7;
            this.btnRefreshMessageList.Text = "刷新列表";
            this.btnRefreshMessageList.UseVisualStyleBackColor = true;
            this.btnRefreshMessageList.Click += new System.EventHandler(this.btnRefreshMessageList_Click);
            // 
            // ManageMessagePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRefreshMessageList);
            this.Controls.Add(this.btnDeleteMessage);
            this.Controls.Add(this.dgvMessages);
            this.Controls.Add(this.btnSearchMessages);
            this.Controls.Add(this.txtSearchSenderId);
            this.Controls.Add(this.lblSearchSenderId);
            this.Controls.Add(this.txtSearchContent);
            this.Controls.Add(this.lblSearchContent);
            this.Name = "ManageMessagePage";
            this.Text = "管理交流信息";
            this.Load += new System.EventHandler(this.ManageMessagePage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMessages)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblSearchContent;
        private System.Windows.Forms.TextBox txtSearchContent;
        private System.Windows.Forms.Label lblSearchSenderId;
        private System.Windows.Forms.TextBox txtSearchSenderId;
        private System.Windows.Forms.Button btnSearchMessages;
        private System.Windows.Forms.DataGridView dgvMessages;
        private System.Windows.Forms.Button btnDeleteMessage;
        private System.Windows.Forms.Button btnRefreshMessageList;
    }
} 