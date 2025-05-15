using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace QQChat
{
    public partial class HistoryMessagePage : Form
    {
        // private string connectionString = "...";
        private int currentUserId;

        public HistoryMessagePage(int userId)
        {
            InitializeComponent();
            this.currentUserId = userId;
        }
        public HistoryMessagePage() // 设计器兼容
        {
            InitializeComponent();
            this.currentUserId = -1;
        }

        private void HistoryMessagePage_Load(object sender, EventArgs e)
        {
            if (currentUserId == -1 && !(this.DesignMode))
            {
                MessageBox.Show("错误：未指定用户ID，无法加载历史消息。", "错误");
                this.Close();
                return;
            }
            dtpStartTime.Value = DateTime.Now.AddDays(-7);
            dtpEndTime.Value = DateTime.Now;
            LoadHistoryMessages();
        }

        private void LoadHistoryMessages(string content = null, DateTime? start = null, DateTime? end = null, string senderId = null, string receiverId = null)
        {
            string sql = "SELECT MessageId, SendId, ReceiveId, Content, SendTime FROM Messages WHERE (SendId=@currentUserId OR ReceiveId=@currentUserId)";
            var paramList = new System.Collections.Generic.List<MySqlParameter> {
                new MySqlParameter("@currentUserId", currentUserId)
            };
            if (!string.IsNullOrEmpty(content))
            {
                sql += " AND Content LIKE @Content";
                paramList.Add(new MySqlParameter("@Content", "%" + content + "%"));
            }
            if (start.HasValue)
            {
                sql += " AND SendTime >= @StartTime";
                paramList.Add(new MySqlParameter("@StartTime", start.Value));
            }
            if (end.HasValue)
            {
                sql += " AND SendTime <= @EndTime";
                paramList.Add(new MySqlParameter("@EndTime", end.Value));
            }
            if (!string.IsNullOrEmpty(senderId))
            {
                sql += " AND SendId = @SenderId";
                paramList.Add(new MySqlParameter("@SenderId", senderId));
            }
            if (!string.IsNullOrEmpty(receiverId))
            {
                sql += " AND ReceiveId = @ReceiverId";
                paramList.Add(new MySqlParameter("@ReceiverId", receiverId));
            }
            sql += " ORDER BY SendTime DESC";
            DataTable dt = DataAccess.ExecuteQuery(sql, paramList.ToArray());
            dgvHistoryMessages.DataSource = dt;
        }

        private void btnSearchHistory_Click(object sender, EventArgs e)
        {
            LoadHistoryMessages(
                txtSearchContent.Text.Trim(),
                dtpStartTime.Value,
                dtpEndTime.Value,
                txtSearchSenderId.Text.Trim(),
                txtSearchReceiverId.Text.Trim()
            );
        }

        private void btnDeleteHistoryMessage_Click(object sender, EventArgs e)
        {
            if (dgvHistoryMessages.SelectedRows.Count > 0)
            {
                int messageId = Convert.ToInt32(dgvHistoryMessages.SelectedRows[0].Cells["MessageId"].Value);
                if (MessageBox.Show("确定要删除选中的消息吗？", "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    // TODO: 从数据库删除消息
                    LoadHistoryMessages();
                }
            }
            else
            {
                MessageBox.Show("请先选择一条消息。", "提示");
            }
        }

        private void btnRefreshHistoryList_Click(object sender, EventArgs e)
        {
            txtSearchContent.Clear();
            txtSearchSenderId.Clear();
            txtSearchReceiverId.Clear();
            dtpStartTime.Value = DateTime.Now.AddDays(-7);
            dtpEndTime.Value = DateTime.Now;
            LoadHistoryMessages();
        }
    }
} 