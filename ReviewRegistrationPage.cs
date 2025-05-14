using System;
using System.Data;
using System.Windows.Forms;
// using MySql.Data.MySqlClient; // 稍后需要

namespace QQChat
{
    public partial class ReviewRegistrationPage : Form
    {
        // private string connectionString = "..."; // 数据库连接字符串

        public ReviewRegistrationPage()
        {
            InitializeComponent();
        }

        private void ReviewRegistrationPage_Load(object sender, EventArgs e)
        {
            LoadPendingRegistrations();
        }

        private void LoadPendingRegistrations()
        {
            // TODO: 从数据库加载 IsApproved = false 的用户
            // 示例:
            // DataTable dt = new DataTable();
            // using (MySqlConnection conn = new MySqlConnection(connectionString))
            // {
            //     try
            //     {
            //         conn.Open();
            //         string query = "SELECT UserId, UserName, Email, Gender FROM Users WHERE IsApproved = false AND IsBanned = false";
            //         MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
            //         da.Fill(dt);
            //         dgvPendingRegistrations.DataSource = dt;
            //         // 设置列名等
            //         if (dgvPendingRegistrations.Columns.Contains("UserId"))
            //             dgvPendingRegistrations.Columns["UserId"].HeaderText = "用户ID";
            //         if (dgvPendingRegistrations.Columns.Contains("UserName"))
            //            dgvPendingRegistrations.Columns["UserName"].HeaderText = "用户名";
            //         // ... 其他列
            //     }
            //     catch (Exception ex)
            //     {
            //         MessageBox.Show("加载待审核列表失败: " + ex.Message);
            //     }
            // }
            MessageBox.Show("LoadPendingRegistrations 功能暂未实现数据库连接。", "提示");
            // 模拟数据
            DataTable dt = new DataTable();
            dt.Columns.Add("UserId", typeof(int));
            dt.Columns.Add("UserName", typeof(string));
            dt.Columns.Add("Email", typeof(string));
            dt.Columns.Add("Gender", typeof(string));
            dt.Rows.Add(10003, "testuser1", "test1@example.com", "男");
            dt.Rows.Add(10004, "testuser2", "test2@example.com", "女");
            dgvPendingRegistrations.DataSource = dt;
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (dgvPendingRegistrations.SelectedRows.Count > 0)
            {
                // 获取选中的 UserId
                // int userId = Convert.ToInt32(dgvPendingRegistrations.SelectedRows[0].Cells["UserId"].Value);
                // TODO: 更新数据库，设置 IsApproved = true for userId
                // 示例:
                // using (MySqlConnection conn = new MySqlConnection(connectionString))
                // {
                //     try
                //     {
                //         conn.Open();
                //         string query = "UPDATE Users SET IsApproved = true WHERE UserId = @UserId";
                //         MySqlCommand cmd = new MySqlCommand(query, conn);
                //         cmd.Parameters.AddWithValue("@UserId", userId);
                //         int rowsAffected = cmd.ExecuteNonQuery();
                //         if (rowsAffected > 0)
                //         {
                //             MessageBox.Show("用户已批准!");
                //             LoadPendingRegistrations(); // 刷新列表
                //         }
                //     }
                //     catch (Exception ex)
                //     {
                //         MessageBox.Show("批准用户失败: " + ex.Message);
                //     }
                // }
                MessageBox.Show("批准用户功能暂未实现数据库连接。选中的用户ID: " + dgvPendingRegistrations.SelectedRows[0].Cells["UserId"].Value, "提示");
                LoadPendingRegistrations(); // 模拟刷新
            }
            else
            {
                MessageBox.Show("请先选择一个用户进行批准。", "提示");
            }
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            if (dgvPendingRegistrations.SelectedRows.Count > 0)
            {
                // 获取选中的 UserId
                // int userId = Convert.ToInt32(dgvPendingRegistrations.SelectedRows[0].Cells["UserId"].Value);
                // TODO: 从数据库中删除该用户记录，或者标记为已拒绝 (根据需求，当前数据库设计是直接删除或不处理)
                // 如果是删除：
                // using (MySqlConnection conn = new MySqlConnection(connectionString))
                // {
                //     try
                //     {
                //         conn.Open();
                //         string query = "DELETE FROM Users WHERE UserId = @UserId AND IsApproved = false"; // 确保只删除未批准的
                //         MySqlCommand cmd = new MySqlCommand(query, conn);
                //         cmd.Parameters.AddWithValue("@UserId", userId);
                //         int rowsAffected = cmd.ExecuteNonQuery();
                //         if (rowsAffected > 0)
                //         {
                //             MessageBox.Show("用户申请已驳回 (用户已删除)!");
                //             LoadPendingRegistrations(); // 刷新列表
                //         }
                //     }
                //     catch (Exception ex)
                //     {
                //         MessageBox.Show("驳回用户申请失败: " + ex.Message);
                //     }
                // }
                MessageBox.Show("驳回用户功能暂未实现数据库连接。选中的用户ID: " + dgvPendingRegistrations.SelectedRows[0].Cells["UserId"].Value, "提示");
                LoadPendingRegistrations(); // 模拟刷新
            }
            else
            {
                MessageBox.Show("请先选择一个用户进行驳回操作。", "提示");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadPendingRegistrations();
        }
    }
} 