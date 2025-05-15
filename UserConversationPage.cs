using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace QQChat
{
    public partial class UserConversationPage : Form
    {
        private int currentUserId;
        private int friendId;
        private string friendName;

        public UserConversationPage(int userId, int friendId, string friendName)
        {
            InitializeComponent();
            this.currentUserId = userId;
            this.friendId = friendId;
            this.friendName = friendName;
        }
        public UserConversationPage() // 设计器兼容
        {
            InitializeComponent();
            this.currentUserId = -1;
            this.friendId = -1;
            this.friendName = "[好友]";
        }

        private void UserConversationPage_Load(object sender, EventArgs e)
        {
            lblChatWith.Text = $"与 {friendName} 聊天";
            LoadChatHistory();
            LoadFileList();
        }

        private void LoadChatHistory()
        {
            // 从数据库加载当前用户与好友的聊天记录
            string sql = @"SELECT SendId, Content, SendTime FROM Messages WHERE ((SendId=@currentUserId AND ReceiveId=@friendId) OR (SendId=@friendId AND ReceiveId=@currentUserId)) AND ReceiveType='普通用户' ORDER BY SendTime";
            var p1 = new MySqlParameter("@currentUserId", currentUserId);
            var p2 = new MySqlParameter("@friendId", friendId);
            var dt = DataAccess.ExecuteQuery(sql, p1, p2);
            rtbChatHistory.Clear();
            foreach (System.Data.DataRow row in dt.Rows)
            {
                int sendId = Convert.ToInt32(row["SendId"]);
                string sender = sendId == currentUserId ? "我" : friendName;
                string content = row["Content"].ToString();
                DateTime sendTime = Convert.ToDateTime(row["SendTime"]);
                rtbChatHistory.AppendText($"{sender} [{sendTime:yyyy-MM-dd HH:mm:ss}]: {content}\n");
            }
        }

        private void LoadFileList()
        {
            // TODO: 从数据库加载当前会话的文件消息
            lstFiles.Items.Clear();
            // 不再添加任何示例文件
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            string msg = txtMessage.Text.Trim();
            if (string.IsNullOrEmpty(msg))
            {
                MessageBox.Show("请输入要发送的消息。", "提示");
                return;
            }
            // 插入消息到数据库
            string sql = "INSERT INTO Messages (SendId, ReceiveId, ReceiveType, Content, MessageType, SendTime) VALUES (@SendId, @ReceiveId, '普通用户', @Content, 'Text', NOW())";
            var p1 = new MySqlParameter("@SendId", currentUserId);
            var p2 = new MySqlParameter("@ReceiveId", friendId);
            var p3 = new MySqlParameter("@Content", msg);
            int result = DataAccess.ExecuteNonQuery(sql, p1, p2, p3);
            if (result > 0)
            {
                LoadChatHistory(); // 刷新聊天记录
                txtMessage.Clear();
            }
            else
            {
                MessageBox.Show("消息发送失败!", "错误");
            }
        }

        private void btnSendFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string fileName = Path.GetFileName(filePath);
                // TODO: 保存文件到服务器/指定目录，并插入 Files 和 Messages 表
                // 示例：INSERT INTO Files (FileName, FilePath) ... 然后 INSERT INTO Messages (..., FileId, MessageType='File')
                rtbChatHistory.AppendText($"我: 发送了文件 [文件: {fileName}]\n");
                lstFiles.Items.Add(fileName);
            }
        }

        private void lstFiles_DoubleClick(object sender, EventArgs e)
        {
            if (lstFiles.SelectedItem != null)
            {
                string fileName = lstFiles.SelectedItem.ToString();
                // TODO: 获取文件路径并打开
                // 示例：SELECT FilePath FROM Files WHERE FileName = @fileName
                MessageBox.Show($"模拟打开文件: {fileName}", "提示");
                // 实际可用 System.Diagnostics.Process.Start(filePath);
            }
        }
    }
} 