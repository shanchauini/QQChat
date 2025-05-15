using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace QQChat
{
    public partial class ManageMessagePage : Form
    {
        // private string connectionString = "...";

        public ManageMessagePage()
        {
            InitializeComponent();
        }

        private void ManageMessagePage_Load(object sender, EventArgs e)
        {
            LoadMessages();
        }

        private void LoadMessages(string contentFilter = null, string senderIdFilter = null)
        {
            string sql = "SELECT MessageId, SendId, ReceiveId, ReceiveType, Content, SendTime, FileId, MessageType FROM Messages WHERE 1=1";
            var paramList = new System.Collections.Generic.List<MySqlParameter>();
            if (!string.IsNullOrEmpty(contentFilter))
            {
                sql += " AND Content LIKE @ContentFilter";
                paramList.Add(new MySqlParameter("@ContentFilter", "%" + contentFilter + "%"));
            }
            if (!string.IsNullOrEmpty(senderIdFilter))
            {
                sql += " AND SendId = @SenderId";
                paramList.Add(new MySqlParameter("@SenderId", senderIdFilter));
            }
            sql += " ORDER BY SendTime DESC";
            DataTable dt = DataAccess.ExecuteQuery(sql, paramList.ToArray());
            dgvMessages.DataSource = dt;
        }

        private void btnSearchMessages_Click(object sender, EventArgs e)
        {
            LoadMessages(txtSearchContent.Text.Trim(), txtSearchSenderId.Text.Trim());
        }

        private void btnDeleteMessage_Click(object sender, EventArgs e)
        {
            if (dgvMessages.SelectedRows.Count > 0)
            {
                int messageId = Convert.ToInt32(dgvMessages.SelectedRows[0].Cells["MessageId"].Value);
                string sql = "DELETE FROM Messages WHERE MessageId = @MessageId";
                var param = new MySqlParameter("@MessageId", messageId);
                DataAccess.ExecuteNonQuery(sql, param);
                LoadMessages(txtSearchContent.Text.Trim(), txtSearchSenderId.Text.Trim());
            }
            else
            {
                MessageBox.Show("请先选择一条消息进行删除。", "提示");
            }
        }

        private void btnRefreshMessageList_Click(object sender, EventArgs e)
        {
            txtSearchContent.Clear();
            txtSearchSenderId.Clear();
            LoadMessages();
        }
    }
} 