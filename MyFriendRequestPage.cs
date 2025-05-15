using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

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
            string sql = @"SELECT fr.RequestId, u.UserName AS ReceiverUserName, fr.RequestStatus, fr.RequestDate FROM FriendRequests fr JOIN Users u ON fr.ReceiveId = u.UserId WHERE fr.SendId = @CurrentUserId ORDER BY fr.RequestDate DESC";
            var param = new MySqlParameter("@CurrentUserId", currentUserId);
            DataTable dt = DataAccess.ExecuteQuery(sql, param);
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
                MessageBox.Show("请输入有效的用户ID (数字)。", "提示");
                return;
            }
            if (targetUserId == this.currentUserId)
            {
                MessageBox.Show("不能添加自己为好友。", "提示");
                return;
            }
            // 检查用户是否存在且有效
            string userCheckSql = "SELECT COUNT(*) FROM Users WHERE UserId = @TargetUserId AND IsApproved = true AND IsBanned = false";
            var pUser = new MySqlParameter("@TargetUserId", targetUserId);
            var dtUser = DataAccess.ExecuteQuery(userCheckSql, pUser);
            if (Convert.ToInt32(dtUser.Rows[0][0]) == 0)
            {
                MessageBox.Show("用户不存在或无效用户。", "错误");
                return;
            }
            // 检查是否已是好友
            string friendCheckSql = "SELECT COUNT(*) FROM FriendShips WHERE (UserId1 = @Uid1 AND UserId2 = @Uid2) OR (UserId1 = @Uid2 AND UserId2 = @Uid1)";
            var pF1 = new MySqlParameter("@Uid1", this.currentUserId);
            var pF2 = new MySqlParameter("@Uid2", targetUserId);
            var dtFriend = DataAccess.ExecuteQuery(friendCheckSql, pF1, pF2);
            if (Convert.ToInt32(dtFriend.Rows[0][0]) > 0)
            {
                MessageBox.Show("你们已经是好友了。", "提示");
                return;
            }
            // 检查是否已发送过申请
            string requestCheckSql = "SELECT COUNT(*) FROM FriendRequests WHERE SendId = @SendId AND ReceiveId = @ReceiveId AND RequestStatus = '申请中'";
            var pR1 = new MySqlParameter("@SendId", this.currentUserId);
            var pR2 = new MySqlParameter("@ReceiveId", targetUserId);
            var dtRequest = DataAccess.ExecuteQuery(requestCheckSql, pR1, pR2);
            if (Convert.ToInt32(dtRequest.Rows[0][0]) > 0)
            {
                MessageBox.Show("已发送过好友申请，请等待对方处理。", "提示");
                return;
            }
            // 发送申请
            string insertRequestSql = "INSERT INTO FriendRequests (SendId, ReceiveId, RequestStatus, RequestDate) VALUES (@SendId, @ReceiveId, '申请中', NOW())";
            int result = DataAccess.ExecuteNonQuery(insertRequestSql, pR1, pR2);
            if (result > 0)
            {
                MessageBox.Show("好友申请已发送!", "成功");
                LoadMySentRequests(); // 刷新列表
                txtSearchUserIdForRequest.Clear();
            }
            else
            {
                MessageBox.Show("发送好友申请失败!", "错误");
            }
        }

        private void btnRefreshMySentRequests_Click(object sender, EventArgs e)
        {
            LoadMySentRequests();
        }
    }
} 