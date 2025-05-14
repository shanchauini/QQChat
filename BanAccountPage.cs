using System;
using System.Data;
using System.Windows.Forms;
// using MySql.Data.MySqlClient;

namespace QQChat
{
    public partial class BanAccountPage : Form
    {
        // private string connectionString = "...";

        public BanAccountPage()
        {
            InitializeComponent();
        }

        private void BanAccountPage_Load(object sender, EventArgs e)
        {
            LoadAllUsers();
        }

        private void LoadAllUsers(string searchTerm = null)
        {
            // TODO: 从数据库加载所有（或符合搜索条件的）已批准的用户信息 (UserId, UserName, IsBanned)
            // 排除管理员账号 '0000'
            // 示例:
            // DataTable dt = new DataTable();
            // using (MySqlConnection conn = new MySqlConnection(connectionString))
            // {
            //     try
            //     {
            //         conn.Open();
            //         string query = "SELECT UserId, UserName, Email, Gender, IsApproved, IsBanned FROM Users WHERE UserName != '0000'"; //不显示管理员
            //         if (!string.IsNullOrEmpty(searchTerm))
            //         {
            //             query += " AND (CAST(UserId AS CHAR) LIKE @SearchTerm OR UserName LIKE @SearchTerm)";
            //         }
            //         MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
            //         if (!string.IsNullOrEmpty(searchTerm))
            //         {
            //             da.SelectCommand.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");
            //         }
            //         da.Fill(dt);
            //         dgvUsers.DataSource = dt;
            //         // 配置列显示，如 UserId, UserName, IsBanned
            //     }
            //     catch (Exception ex)
            //     {
            //         MessageBox.Show("加载用户列表失败: " + ex.Message);
            //     }
            // }
            MessageBox.Show("LoadAllUsers 功能暂未实现数据库连接。搜索词: " + searchTerm, "提示");
            DataTable dt = new DataTable();
            dt.Columns.Add("UserId", typeof(int));
            dt.Columns.Add("UserName", typeof(string));
            dt.Columns.Add("Email", typeof(string));
            dt.Columns.Add("IsApproved", typeof(bool));
            dt.Columns.Add("IsBanned", typeof(bool));
            dt.Rows.Add(10001, "userA", "usera@example.com", true, false);
            dt.Rows.Add(10002, "userB", "userb@example.com", true, true);
            dt.Rows.Add(10003, "testuser1", "test1@example.com", false, false); // 假设这个是刚批准的
 
            if (!string.IsNullOrEmpty(searchTerm)) {
                DataView dv = dt.DefaultView;
                dv.RowFilter = string.Format("CONVERT(UserId, System.String) LIKE '%{0}%' OR UserName LIKE '%{0}%'", searchTerm);
                dgvUsers.DataSource = dv.ToTable();
            } else {
                 dgvUsers.DataSource = dt;
            }
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
                // 不能禁止或解禁管理员自己
                if (userId.ToString() == "0000") {
                     MessageBox.Show("不能操作管理员账号。", "错误");
                     return;
                }

                // TODO: 更新数据库 Users 表中对应 UserId 的 IsBanned 状态
                // 示例:
                // using (MySqlConnection conn = new MySqlConnection(connectionString))
                // {
                //     try
                //     {
                //         conn.Open();
                //         string query = "UPDATE Users SET IsBanned = @IsBanned WHERE UserId = @UserId";
                //         MySqlCommand cmd = new MySqlCommand(query, conn);
                //         cmd.Parameters.AddWithValue("@IsBanned", banStatus);
                //         cmd.Parameters.AddWithValue("@UserId", userId);
                //         int rowsAffected = cmd.ExecuteNonQuery();
                //         if (rowsAffected > 0)
                //         {
                //             MessageBox.Show(banStatus ? "用户已禁止!" : "用户已解禁!");
                //             LoadAllUsers(txtSearchUser.Text.Trim()); // 刷新列表
                //         }
                //     }
                //     catch (Exception ex)
                //     {
                //         MessageBox.Show("操作失败: " + ex.Message);
                //     }
                // }
                MessageBox.Show((banStatus ? "禁止" : "解禁") + "用户功能暂未实现数据库连接。用户ID: " + userId, "提示");
                LoadAllUsers(txtSearchUser.Text.Trim()); // 模拟刷新
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