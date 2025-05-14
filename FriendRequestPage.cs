using System;
using System.Data;
using System.Windows.Forms;
// using MySql.Data.MySqlClient;

namespace QQChat
{
    public partial class FriendRequestPage : Form
    {
        // private string connectionString = "...";
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
            // TODO: 从数据库加载 FriendRequests 表中 ReceiveId = currentUserId 且 RequestStatus = '申请中' 的记录
            // 需要 JOIN Users 表以获取发送者的 UserName
            // 显示 RequestId, SenderUserName (Users.UserName), RequestDate
            // 示例:
            // DataTable dt = new DataTable();
            // using (MySqlConnection conn = new MySqlConnection(connectionString))
            // {
            //     try
            //     {
            //         conn.Open();
            //         string query = "SELECT fr.RequestId, u.UserName AS SenderUserName, fr.RequestDate " +
            //                        "FROM FriendRequests fr JOIN Users u ON fr.SendId = u.UserId " +
            //                        "WHERE fr.ReceiveId = @CurrentUserId AND fr.RequestStatus = '申请中' ORDER BY fr.RequestDate DESC";
            //         MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
            //         da.SelectCommand.Parameters.AddWithValue("@CurrentUserId", this.currentUserId);
            //         da.Fill(dt);
            //         dgvFriendRequestsReceived.DataSource = dt;
            //         // 配置列名等
            //     }
            //     catch (Exception ex)
            //     {
            //         MessageBox.Show("加载好友申请列表失败: " + ex.Message);
            //     }
            // }
            MessageBox.Show("LoadReceivedFriendRequests 功能暂未实现数据库连接。UserID: " + this.currentUserId, "提示");
            DataTable dt = new DataTable();
            dt.Columns.Add("RequestId", typeof(int));
            dt.Columns.Add("SenderUserName", typeof(string));
            dt.Columns.Add("RequestDate", typeof(DateTime));
            dt.Rows.Add(20001, "userC", DateTime.Now.AddDays(-1));
            dt.Rows.Add(20002, "userD", DateTime.Now);
            dgvFriendRequestsReceived.DataSource = dt;
        }

        private void ProcessFriendRequest(int requestId, string newStatus)
        {
            // TODO: 更新 FriendRequests 表中对应 RequestId 的 RequestStatus
            // 如果接受 ('已接受'), 则还需要在 FriendShips 表中添加一条新记录 (UserId1, UserId2)
            // UserId1 和 UserId2 的顺序可以固定，例如总是较小的ID在前，或根据 SendId 和 ReceiveId
            // 示例:
            // using (MySqlConnection conn = new MySqlConnection(connectionString))
            // {
            //     conn.Open();
            //     MySqlTransaction transaction = conn.BeginTransaction(); // 使用事务确保原子性
            //     try
            //     {
            //         // 1. 更新 FriendRequests 表
            //         string updateReqQuery = "UPDATE FriendRequests SET RequestStatus = @NewStatus WHERE RequestId = @RequestId";
            //         MySqlCommand updateReqCmd = new MySqlCommand(updateReqQuery, conn, transaction);
            //         updateReqCmd.Parameters.AddWithValue("@NewStatus", newStatus);
            //         updateReqCmd.Parameters.AddWithValue("@RequestId", requestId);
            //         updateReqCmd.ExecuteNonQuery();

            //         // 2. 如果是接受，则添加好友关系
            //         if (newStatus == "已接受")
            //         {
            //             // 首先获取 SendId
            //             string getSendIdQuery = "SELECT SendId FROM FriendRequests WHERE RequestId = @RequestId";
            //             MySqlCommand getSendIdCmd = new MySqlCommand(getSendIdQuery, conn, transaction);
            //             getSendIdCmd.Parameters.AddWithValue("@RequestId", requestId);
            //             int senderId = Convert.ToInt32(getSendIdCmd.ExecuteScalar());

            //             // 添加到 FriendShips (确保不重复添加，或处理已存在的情况)
            //             // 可以约定 UserId1 < UserId2
            //             int userId1 = Math.Min(this.currentUserId, senderId);
            //             int userId2 = Math.Max(this.currentUserId, senderId);
            //             string insertFriendQuery = "INSERT INTO FriendShips (UserId1, UserId2) VALUES (@UserId1, @UserId2)";
            //             // 可先查询是否存在，避免重复: SELECT COUNT(*) FROM FriendShips WHERE (UserId1 = @UserId1 AND UserId2 = @UserId2) OR (UserId1 = @UserId2 AND UserId2 = @UserId1)
            //             MySqlCommand insertFriendCmd = new MySqlCommand(insertFriendQuery, conn, transaction);
            //             insertFriendCmd.Parameters.AddWithValue("@UserId1", userId1);
            //             insertFriendCmd.Parameters.AddWithValue("@UserId2", userId2);
            //             insertFriendCmd.ExecuteNonQuery();
            //         }
            //         transaction.Commit();
            //         MessageBox.Show("好友请求已" + newStatus + "!");
            //         LoadReceivedFriendRequests(); // 刷新
            //     }
            //     catch (Exception ex)
            //     {
            //         transaction.Rollback();
            //         MessageBox.Show("处理好友请求失败: " + ex.Message);
            //     }
            // }
            MessageBox.Show("处理好友申请(" + newStatus + ") 功能暂未实现数据库连接。RequestID: " + requestId, "提示");
            LoadReceivedFriendRequests(); // 模拟刷新
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