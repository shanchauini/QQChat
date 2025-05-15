using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace QQChat
{
    public partial class FriendRequestPage : Form
    {
        private int currentUserId; // 当前登录用户ID

        public FriendRequestPage(int userId)
        {
            InitializeComponent();
            this.currentUserId = userId;
        }
        public FriendRequestPage() // 为设计器保留
        {
            InitializeComponent();
            this.currentUserId = -1; // 示例ID，实际应由登录用户确定
        }

        private void FriendRequestPage_Load(object sender, EventArgs e)
        {
            if (currentUserId == -1 && !(this.DesignMode)){
                 MessageBox.Show("错误：无法加载好友申请，未指定用户ID。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 this.Close();
                 return;
            }
            LoadReceivedFriendRequests();
        }

        private void LoadReceivedFriendRequests()
        {
            string sql = @"SELECT fr.RequestId, u.UserName AS SenderUserName, fr.RequestDate FROM FriendRequests fr JOIN Users u ON fr.SendId = u.UserId WHERE fr.ReceiveId = @CurrentUserId AND fr.RequestStatus = '申请中' ORDER BY fr.RequestDate DESC";
            var param = new MySqlParameter("@CurrentUserId", currentUserId);
            DataTable dt = DataAccess.ExecuteQuery(sql, param);
            dgvFriendRequestsReceived.DataSource = dt;
        }

        private void ProcessFriendRequest(int requestId, string newStatus)
        {
            string sql = "UPDATE FriendRequests SET RequestStatus = @NewStatus WHERE RequestId = @RequestId";
            var p1 = new MySqlParameter("@NewStatus", newStatus);
            var p2 = new MySqlParameter("@RequestId", requestId);
            DataAccess.ExecuteNonQuery(sql, p1, p2);
            if (newStatus == "已接受")
            {
                string getSendIdSql = "SELECT SendId FROM FriendRequests WHERE RequestId = @RequestId";
                DataTable dt = DataAccess.ExecuteQuery(getSendIdSql, p2);
                if (dt.Rows.Count > 0)
                {
                    int senderId = Convert.ToInt32(dt.Rows[0]["SendId"]);
                    int userId1 = Math.Min(this.currentUserId, senderId);
                    int userId2 = Math.Max(this.currentUserId, senderId);
                    string insertFriendSql = "INSERT INTO FriendShips (UserId1, UserId2) VALUES (@UserId1, @UserId2)";
                    var p3 = new MySqlParameter("@UserId1", userId1);
                    var p4 = new MySqlParameter("@UserId2", userId2);
                    DataAccess.ExecuteNonQuery(insertFriendSql, p3, p4);
                }
            }
            LoadReceivedFriendRequests();
        }

        private void btnAcceptRequest_Click(object sender, EventArgs e)
        {
            if (dgvFriendRequestsReceived.SelectedRows.Count > 0)
            {
                int requestId = Convert.ToInt32(dgvFriendRequestsReceived.SelectedRows[0].Cells["RequestId"].Value);
                ProcessFriendRequest(requestId, "已接受");
            }
            else
            {
                MessageBox.Show("请先选择一个好友申请。", "提示");
            }
        }

        private void btnDeclineRequest_Click(object sender, EventArgs e)
        {
            if (dgvFriendRequestsReceived.SelectedRows.Count > 0)
            {
                int requestId = Convert.ToInt32(dgvFriendRequestsReceived.SelectedRows[0].Cells["RequestId"].Value);
                ProcessFriendRequest(requestId, "已拒绝");
            }
            else
            {
                MessageBox.Show("请先选择一个好友申请。", "提示");
            }
        }

        private void btnRefreshRequests_Click(object sender, EventArgs e)
        {
            LoadReceivedFriendRequests();
        }
    }
} 