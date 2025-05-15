using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace QQChat
{
    public partial class FriendListPage : Form
    {
        private int currentUserId;

        public FriendListPage(int userId)
        {
            InitializeComponent();
            this.currentUserId = userId;
        }
        public FriendListPage() { InitializeComponent(); this.currentUserId = -1; }

        private void FriendListPage_Load(object sender, EventArgs e)
        {
            if (currentUserId == -1 && !(this.DesignMode))
            {
                MessageBox.Show("错误：未指定用户ID，无法加载好友列表。", "错误");
                this.Close();
                return;
            }
            LoadFriendList();
        }

        private void LoadFriendList()
        {
            string sql = @"SELECT u.UserId, u.UserName, u.Gender, u.Email FROM FriendShips f JOIN Users u ON (u.UserId = CASE WHEN f.UserId1 = @UserId THEN f.UserId2 ELSE f.UserId1 END) WHERE f.UserId1 = @UserId OR f.UserId2 = @UserId";
            var param = new MySqlParameter("@UserId", currentUserId);
            DataTable dt = DataAccess.ExecuteQuery(sql, param);
            dgvFriendList.DataSource = dt;
        }

        private void btnDeleteFriend_Click(object sender, EventArgs e)
        {
            if (dgvFriendList.SelectedRows.Count > 0)
            {
                int friendId = Convert.ToInt32(dgvFriendList.SelectedRows[0].Cells["UserId"].Value);
                if (MessageBox.Show("确定要删除该好友关系吗？", "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string sql = "DELETE FROM FriendShips WHERE (UserId1 = @Uid1 AND UserId2 = @Uid2) OR (UserId1 = @Uid2 AND UserId2 = @Uid1)";
                    var p1 = new MySqlParameter("@Uid1", currentUserId);
                    var p2 = new MySqlParameter("@Uid2", friendId);
                    DataAccess.ExecuteNonQuery(sql, p1, p2);
                    LoadFriendList();
                }
            }
            else
            {
                MessageBox.Show("请先选择一个好友。", "提示");
            }
        }

        private void btnChatWithFriend_Click(object sender, EventArgs e)
        {
            if (dgvFriendList.SelectedRows.Count > 0)
            {
                int friendId = Convert.ToInt32(dgvFriendList.SelectedRows[0].Cells["UserId"].Value);
                string friendName = dgvFriendList.SelectedRows[0].Cells["UserName"].Value.ToString();
                UserConversationPage chatPage = new UserConversationPage(this.currentUserId, friendId, friendName);
                chatPage.Show();
            }
            else
            {
                MessageBox.Show("请先选择一个好友。", "提示");
            }
        }

        private void btnRefreshFriendList_Click(object sender, EventArgs e)
        {
            LoadFriendList();
        }
    }
} 