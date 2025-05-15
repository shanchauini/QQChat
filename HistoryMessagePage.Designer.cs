namespace QQChat
{
    partial class HistoryMessagePage
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
            this.lblSearchTime = new System.Windows.Forms.Label();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.lblSearchSender = new System.Windows.Forms.Label();
            this.txtSearchSenderId = new System.Windows.Forms.TextBox();
            this.lblSearchReceiver = new System.Windows.Forms.Label();
            this.txtSearchReceiverId = new System.Windows.Forms.TextBox();
            this.btnSearchHistory = new System.Windows.Forms.Button();
            this.dgvHistoryMessages = new System.Windows.Forms.DataGridView();
            this.btnDeleteHistoryMessage = new System.Windows.Forms.Button();
            this.btnRefreshHistoryList = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistoryMessages)).BeginInit();
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
            this.txtSearchContent.Size = new System.Drawing.Size(100, 20);
            this.txtSearchContent.TabIndex = 1;
            // 
            // lblSearchTime
            // 
            this.lblSearchTime.AutoSize = true;
            this.lblSearchTime.Location = new System.Drawing.Point(190, 15);
            this.lblSearchTime.Name = "lblSearchTime";
            this.lblSearchTime.TabIndex = 2;
            this.lblSearchTime.Text = "发送时间:";
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartTime.Location = new System.Drawing.Point(255, 12);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.Size = new System.Drawing.Size(90, 20);
            this.dtpStartTime.TabIndex = 3;
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndTime.Location = new System.Drawing.Point(355, 12);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Size = new System.Drawing.Size(90, 20);
            this.dtpEndTime.TabIndex = 4;
            // 
            // lblSearchSender
            // 
            this.lblSearchSender.AutoSize = true;
            this.lblSearchSender.Location = new System.Drawing.Point(460, 15);
            this.lblSearchSender.Name = "lblSearchSender";
            this.lblSearchSender.TabIndex = 5;
            this.lblSearchSender.Text = "发送者ID:";
            // 
            // txtSearchSenderId
            // 
            this.txtSearchSenderId.Location = new System.Drawing.Point(525, 12);
            this.txtSearchSenderId.Name = "txtSearchSenderId";
            this.txtSearchSenderId.Size = new System.Drawing.Size(60, 20);
            this.txtSearchSenderId.TabIndex = 6;
            // 
            // lblSearchReceiver
            // 
            this.lblSearchReceiver.AutoSize = true;
            this.lblSearchReceiver.Location = new System.Drawing.Point(600, 15);
            this.lblSearchReceiver.Name = "lblSearchReceiver";
            this.lblSearchReceiver.TabIndex = 7;
            this.lblSearchReceiver.Text = "接收者ID:";
            // 
            // txtSearchReceiverId
            // 
            this.txtSearchReceiverId.Location = new System.Drawing.Point(665, 12);
            this.txtSearchReceiverId.Name = "txtSearchReceiverId";
            this.txtSearchReceiverId.Size = new System.Drawing.Size(60, 20);
            this.txtSearchReceiverId.TabIndex = 8;
            // 
            // btnSearchHistory
            // 
            this.btnSearchHistory.Location = new System.Drawing.Point(740, 10);
            this.btnSearchHistory.Name = "btnSearchHistory";
            this.btnSearchHistory.Size = new System.Drawing.Size(50, 23);
            this.btnSearchHistory.TabIndex = 9;
            this.btnSearchHistory.Text = "查询";
            this.btnSearchHistory.UseVisualStyleBackColor = true;
            this.btnSearchHistory.Click += new System.EventHandler(this.btnSearchHistory_Click);
            // 
            // dgvHistoryMessages
            // 
            this.dgvHistoryMessages.AllowUserToAddRows = false;
            this.dgvHistoryMessages.AllowUserToDeleteRows = false;
            this.dgvHistoryMessages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistoryMessages.Location = new System.Drawing.Point(12, 45);
            this.dgvHistoryMessages.MultiSelect = false;
            this.dgvHistoryMessages.Name = "dgvHistoryMessages";
            this.dgvHistoryMessages.ReadOnly = true;
            this.dgvHistoryMessages.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistoryMessages.Size = new System.Drawing.Size(776, 317);
            this.dgvHistoryMessages.TabIndex = 10;
            // 
            // btnDeleteHistoryMessage
            // 
            this.btnDeleteHistoryMessage.Location = new System.Drawing.Point(12, 380);
            this.btnDeleteHistoryMessage.Name = "btnDeleteHistoryMessage";
            this.btnDeleteHistoryMessage.Size = new System.Drawing.Size(100, 30);
            this.btnDeleteHistoryMessage.TabIndex = 11;
            this.btnDeleteHistoryMessage.Text = "删除选中消息";
            this.btnDeleteHistoryMessage.UseVisualStyleBackColor = true;
            this.btnDeleteHistoryMessage.Click += new System.EventHandler(this.btnDeleteHistoryMessage_Click);
            // 
            // btnRefreshHistoryList
            // 
            this.btnRefreshHistoryList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshHistoryList.Location = new System.Drawing.Point(688, 380);
            this.btnRefreshHistoryList.Name = "btnRefreshHistoryList";
            this.btnRefreshHistoryList.Size = new System.Drawing.Size(100, 30);
            this.btnRefreshHistoryList.TabIndex = 12;
            this.btnRefreshHistoryList.Text = "刷新列表";
            this.btnRefreshHistoryList.UseVisualStyleBackColor = true;
            this.btnRefreshHistoryList.Click += new System.EventHandler(this.btnRefreshHistoryList_Click);
            // 
            // HistoryMessagePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRefreshHistoryList);
            this.Controls.Add(this.btnDeleteHistoryMessage);
            this.Controls.Add(this.dgvHistoryMessages);
            this.Controls.Add(this.btnSearchHistory);
            this.Controls.Add(this.txtSearchReceiverId);
            this.Controls.Add(this.lblSearchReceiver);
            this.Controls.Add(this.txtSearchSenderId);
            this.Controls.Add(this.lblSearchSender);
            this.Controls.Add(this.dtpEndTime);
            this.Controls.Add(this.dtpStartTime);
            this.Controls.Add(this.lblSearchTime);
            this.Controls.Add(this.txtSearchContent);
            this.Controls.Add(this.lblSearchContent);
            this.Name = "HistoryMessagePage";
            this.Text = "历史消息";
            this.Load += new System.EventHandler(this.HistoryMessagePage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistoryMessages)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblSearchContent;
        private System.Windows.Forms.TextBox txtSearchContent;
        private System.Windows.Forms.Label lblSearchTime;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.Label lblSearchSender;
        private System.Windows.Forms.TextBox txtSearchSenderId;
        private System.Windows.Forms.Label lblSearchReceiver;
        private System.Windows.Forms.TextBox txtSearchReceiverId;
        private System.Windows.Forms.Button btnSearchHistory;
        private System.Windows.Forms.DataGridView dgvHistoryMessages;
        private System.Windows.Forms.Button btnDeleteHistoryMessage;
        private System.Windows.Forms.Button btnRefreshHistoryList;
    }
} 