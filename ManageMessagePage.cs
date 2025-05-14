using System;
using System.Data;
using System.Windows.Forms;
// using MySql.Data.MySqlClient;

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
            // TODO: 从数据库加载消息，根据提供的筛选条件
            // 示例:
            // DataTable dt = new DataTable();
            // using (MySqlConnection conn = new MySqlConnection(connectionString))
            // {
            //     try
            //     {
            //         conn.Open();
            //         string query = "SELECT MessageId, SendId, ReceiveId, ReceiveType, Content, SendTime, FileId, MessageType FROM Messages WHERE 1=1";
            //         if (!string.IsNullOrEmpty(contentFilter))
            //         {
            //             query += " AND Content LIKE @ContentFilter";
            //         }
            //         if (!string.IsNullOrEmpty(senderIdFilter) && int.TryParse(senderIdFilter, out int sid))
            //         {
            //             query += " AND SendId = @SenderId";
            //         }
            //         query += " ORDER BY SendTime DESC"; // 按发送时间降序排列

            //         MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
            //         if (!string.IsNullOrEmpty(contentFilter))
            //         {
            //             da.SelectCommand.Parameters.AddWithValue("@ContentFilter", "%" + contentFilter + "%");
            //         }
            //         if (!string.IsNullOrEmpty(senderIdFilter) && int.TryParse(senderIdFilter, out int senderId))
            //         {
            //             da.SelectCommand.Parameters.AddWithValue("@SenderId", senderId);
            //         }
            //         da.Fill(dt);
            //         dgvMessages.DataSource = dt;
            //         // 配置列名等...
            //     }
            //     catch (Exception ex)
            //     {
            //         MessageBox.Show("加载消息列表失败: " + ex.Message);
            //     }
            // }
            MessageBox.Show("LoadMessages 功能暂未实现数据库连接。内容筛选: " + contentFilter + ", 发送者ID筛选: " + senderIdFilter, "提示");
            DataTable dt = new DataTable();
            dt.Columns.Add("MessageId", typeof(int));
            dt.Columns.Add("SendId", typeof(int));
            dt.Columns.Add("ReceiveId", typeof(int));
            dt.Columns.Add("ReceiveType", typeof(string));
            dt.Columns.Add("Content", typeof(string));
            dt.Columns.Add("SendTime", typeof(DateTime));
            dt.Columns.Add("FileId", typeof(int));
            dt.Columns.Add("MessageType", typeof(string));

            dt.Rows.Add(50001, 10001, 10002, "普通用户", "你好，userB", DateTime.Now.AddHours(-2), null, "Text");
            dt.Rows.Add(50002, 10002, 10001, "普通用户", "你好，userA，收到！", DateTime.Now.AddHours(-1), null, "Text");
            dt.Rows.Add(50003, 10001, 10002, "普通用户", "这是一个文件消息", DateTime.Now, 70001, "File");

            DataView dv = dt.DefaultView;
            string rowFilter = "1=1";
            if (!string.IsNullOrEmpty(contentFilter)){
                rowFilter += string.Format(" AND Content LIKE '%{0}%'", contentFilter);
            }
            if(!string.IsNullOrEmpty(senderIdFilter)){
                 rowFilter += string.Format(" AND SendId = {0}", senderIdFilter);
            }
            dv.RowFilter = rowFilter;
            dgvMessages.DataSource = dv.ToTable();
        }

        private void btnSearchMessages_Click(object sender, EventArgs e)
        {
            LoadMessages(txtSearchContent.Text.Trim(), txtSearchSenderId.Text.Trim());
        }

        private void btnDeleteMessage_Click(object sender, EventArgs e)
        {
            if (dgvMessages.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("确定要删除选中的消息吗？此操作不可恢复。", "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    int messageId = Convert.ToInt32(dgvMessages.SelectedRows[0].Cells["MessageId"].Value);
                    // TODO: 从数据库删除 Messages 表中对应 MessageId 的记录
                    // 还需要考虑如果消息是文件类型，是否要删除 Files 表中的对应记录以及实际文件 (根据需求)
                    // 示例:
                    // using (MySqlConnection conn = new MySqlConnection(connectionString))
                    // {
                    //     try
                    //     {
                    //         conn.Open();
                    //         // 可选：先检查消息类型，如果是文件，获取FileId，后续可能要删除文件
                    //         // string getFileIdQuery = "SELECT FileId FROM Messages WHERE MessageId = @MessageId AND MessageType = 'File'";
                    //         // MySqlCommand getFileCmd = new MySqlCommand(getFileIdQuery, conn);
                    //         // getFileCmd.Parameters.AddWithValue("@MessageId", messageId);
                    //         // object fileIdObj = getFileCmd.ExecuteScalar();

                    //         string deleteQuery = "DELETE FROM Messages WHERE MessageId = @MessageId";
                    //         MySqlCommand cmd = new MySqlCommand(deleteQuery, conn);
                    //         cmd.Parameters.AddWithValue("@MessageId", messageId);
                    //         int rowsAffected = cmd.ExecuteNonQuery();
                    //         if (rowsAffected > 0)
                    //         {
                    //             MessageBox.Show("消息已删除!");
                    //             // if (fileIdObj != null && fileIdObj != DBNull.Value) { /* 删除关联文件记录和物理文件 */ }
                    //             LoadMessages(txtSearchContent.Text.Trim(), txtSearchSenderId.Text.Trim()); // 刷新列表
                    //         }
                    //     }
                    //     catch (Exception ex)
                    //     {
                    //         MessageBox.Show("删除消息失败: " + ex.Message);
                    //     }
                    // }
                    MessageBox.Show("删除消息功能暂未实现数据库连接。消息ID: " + messageId, "提示");
                    LoadMessages(txtSearchContent.Text.Trim(), txtSearchSenderId.Text.Trim()); // 模拟刷新
                }
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