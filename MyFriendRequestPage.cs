using System;
using System.Data;
using System.Windows.Forms;
// using MySql.Data.MySqlClient;

namespace QQChat
{
    public partial class MyFriendRequestPage : Form
    {
        // private string connectionString = "...";
        private int currentUserId; // 当前登录用户ID

        public MyFriendRequestPage(int userId)
        {
            InitializeComponent();
            this.currentUserId = userId;
        }
        public MyFriendRequestPage() // 为设计器保留
        {
            InitializeComponent();
            this.currentUserId = -1; 
        }

        private void MyFriendRequestPage_Load(object sender, EventArgs e)
        {
             if (currentUserId == -1 && !(this.DesignMode)){
                 MessageBox.Show("错误：无法加载我的申请，未指定用户ID。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 this.Close();
                 return;
            }
            LoadMySentRequests();
        }

        private void LoadMySentRequests()
        {
            // TODO: 从数据库加载 FriendRequests 表中 SendId = currentUserId 的记录
            // 需要 JOIN Users 表以获取接收者的 UserName
            // 显示 RequestId, ReceiverUserName (Users.UserName), RequestStatus, RequestDate
            // 示例:
            // DataTable dt = new DataTable();
            // using (MySqlConnection conn = new MySqlConnection(connectionString))
            // {
            //     try
            //     {
            //         conn.Open();
            //         string query = "SELECT fr.RequestId, u.UserName AS ReceiverUserName, fr.RequestStatus, fr.RequestDate " +
            //                        "FROM FriendRequests fr JOIN Users u ON fr.ReceiveId = u.UserId " +
            //                        "WHERE fr.SendId = @CurrentUserId ORDER BY fr.RequestDate DESC";
            //         MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
            //         da.SelectCommand.Parameters.AddWithValue("@CurrentUserId", this.currentUserId);
            //         da.Fill(dt);
            //         dgvMySentRequests.DataSource = dt;
            //     }
            //     catch (Exception ex)
            //     {
            //         MessageBox.Show("加载我发送的申请列表失败: " + ex.Message);
            //     }
            // }
            MessageBox.Show("LoadMySentRequests 功能暂未实现数据库连接。UserID: " + this.currentUserId, "提示");
            DataTable dt = new DataTable();
            dt.Columns.Add("RequestId", typeof(int));
            dt.Columns.Add("ReceiverUserName", typeof(string));
            dt.Columns.Add("RequestStatus", typeof(string));
            dt.Columns.Add("RequestDate", typeof(DateTime));
            dt.Rows.Add(20003, "userA", "申请中", DateTime.Now.AddMinutes(-30));
            dt.Rows.Add(20004, "userB", "已接受", DateTime.Now.AddDays(-2));
            dgvMySentRequests.DataSource = dt;

        }

        private void btnSearchAndAddUser_Click(object sender, EventArgs e)
        {
            string searchInput = txtSearchUserIdForRequest.Text.Trim();
            if (string.IsNullOrEmpty(searchInput))
            {
                MessageBox.Show("请输入要搜索的用户ID或用户名。", "提示");
                return;
            }

            if (!int.TryParse(searchInput, out int targetUserId))
            {
                MessageBox.Show("请输入有效的用户ID (数字)。", "提示"); // 当前设计是按ID搜索添加
                return;
            }

            if (targetUserId == this.currentUserId)
            {
                MessageBox.Show("不能添加自己为好友。", "提示");
                return;
            }

            // TODO: 
            // 1. 检查 targetUserId 是否存在于 Users 表且已批准 (IsApproved = true) 且未禁用 (IsBanned = false)。
            // 2. 检查是否已经是好友 (FriendShips 表中是否存在 currentUserId 和 targetUserId 的记录)。
            // 3. 检查是否已发送过申请且状态为 '申请中' (FriendRequests 表)。
            // 4. 如果都通过，则向 FriendRequests 表插入一条新记录 (SendId=currentUserId, ReceiveId=targetUserId, RequestStatus='申请中')
            // 示例 (部分逻辑):
            // using (MySqlConnection conn = new MySqlConnection(connectionString))
            // {
            //     try
            //     {
            //         conn.Open();
            //         // 检查用户是否存在且有效
            //         string userCheckQuery = "SELECT COUNT(*) FROM Users WHERE UserId = @TargetUserId AND IsApproved = true AND IsBanned = false";
            //         MySqlCommand userCheckCmd = new MySqlCommand(userCheckQuery, conn);
            //         userCheckCmd.Parameters.AddWithValue("@TargetUserId", targetUserId);
            //         if (Convert.ToInt32(userCheckCmd.ExecuteScalar()) == 0) { MessageBox.Show("用户不存在或无效用户。", "错误"); return; }

            //         // 检查是否已是好友
            //         string friendCheckQuery = "SELECT COUNT(*) FROM FriendShips WHERE (UserId1 = @Uid1 AND UserId2 = @Uid2) OR (UserId1 = @Uid2 AND UserId2 = @Uid1)";
            //         MySqlCommand friendCheckCmd = new MySqlCommand(friendCheckQuery, conn);
            //         friendCheckCmd.Parameters.AddWithValue("@Uid1", this.currentUserId);
            //         friendCheckCmd.Parameters.AddWithValue("@Uid2", targetUserId);
            //         if (Convert.ToInt32(friendCheckCmd.ExecuteScalar()) > 0) { MessageBox.Show("你们已经是好友了。", "提示"); return; }

            //         // 检查是否已发送过申请
            //         string requestCheckQuery = "SELECT COUNT(*) FROM FriendRequests WHERE SendId = @SendId AND ReceiveId = @ReceiveId AND RequestStatus = '申请中'";
            //         MySqlCommand requestCheckCmd = new MySqlCommand(requestCheckQuery, conn);
            //         requestCheckCmd.Parameters.AddWithValue("@SendId", this.currentUserId);
            //         requestCheckCmd.Parameters.AddWithValue("@ReceiveId", targetUserId);
            //         if (Convert.ToInt32(requestCheckCmd.ExecuteScalar()) > 0) { MessageBox.Show("已发送过好友申请，请等待对方处理。", "提示"); return; }

            //         // 发送申请
            //         string insertRequestQuery = "INSERT INTO FriendRequests (SendId, ReceiveId, RequestStatus) VALUES (@SendId, @ReceiveId, '申请中')";
            //         MySqlCommand insertCmd = new MySqlCommand(insertRequestQuery, conn);
            //         insertCmd.Parameters.AddWithValue("@SendId", this.currentUserId);
            //         insertCmd.Parameters.AddWithValue("@ReceiveId", targetUserId);
            //         insertCmd.ExecuteNonQuery();
            //         MessageBox.Show("好友申请已发送!", "成功");
            //         LoadMySentRequests(); // 刷新列表
            //         txtSearchUserIdForRequest.Clear();
            //     }
            //     catch (Exception ex)
            //     {
            //         MessageBox.Show("发送好友申请失败: " + ex.Message);
            //     }
            // }
            MessageBox.Show("发送好友申请功能暂未实现数据库连接。TargetUserID: " + targetUserId, "提示");
            LoadMySentRequests(); // 模拟刷新
            txtSearchUserIdForRequest.Clear();
        }

        private void btnRefreshMySentRequests_Click(object sender, EventArgs e)
        {
            LoadMySentRequests();
        }
    }
} 