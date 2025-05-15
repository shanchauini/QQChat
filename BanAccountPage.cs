using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace QQChat
{
    public partial class BanAccountPage : Form
    {
        private int currentUserId;
        public BanAccountPage() { InitializeComponent(); }

        private void BanAccountPage_Load(object sender, EventArgs e)
        {
            LoadAllUsers();
        }

        private void LoadAllUsers(string searchTerm = null)
        {
            string sql = "SELECT UserId, UserName, Email, IsApproved, IsBanned FROM Users WHERE UserName != '0000'";
            var paramList = new System.Collections.Generic.List<MySqlParameter>();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                sql += " AND (CAST(UserId AS CHAR) LIKE @SearchTerm OR UserName LIKE @SearchTerm)";
                paramList.Add(new MySqlParameter("@SearchTerm", "%" + searchTerm + "%"));
            }
            DataTable dt = DataAccess.ExecuteQuery(sql, paramList.ToArray());
            dgvUsers.DataSource = dt;
        }

        private void btnSearchUser_Click(object sender, EventArgs e)
        {
            LoadAllUsers(txtSearchUser.Text.Trim());
        }

        private void UpdateUserBanStatus(bool banStatus)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                int userId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["UserId"].Value);
                if (userId.ToString() == "0000")
                {
                    MessageBox.Show("不能操作管理员账号。", "错误");
                    return;
                }
                string sql = "UPDATE Users SET IsBanned = @IsBanned WHERE UserId = @UserId";
                var p1 = new MySqlParameter("@IsBanned", banStatus);
                var p2 = new MySqlParameter("@UserId", userId);
                DataAccess.ExecuteNonQuery(sql, p1, p2);
                LoadAllUsers(txtSearchUser.Text.Trim());
            }
            else
            {
                MessageBox.Show("请先选择一个用户。", "提示");
            }
        }

        private void btnBanUser_Click(object sender, EventArgs e)
        {
            UpdateUserBanStatus(true);
        }

        private void btnUnbanUser_Click(object sender, EventArgs e)
        {
            UpdateUserBanStatus(false);
        }

        private void btnRefreshUserList_Click(object sender, EventArgs e)
        {
            txtSearchUser.Clear();
            LoadAllUsers();
        }
    }
} 