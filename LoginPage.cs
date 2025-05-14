using System;
using System.Windows.Forms;
// using MySql.Data.MySqlClient; // 稍后需要取消注释并添加 MySQL Connector/NET 引用

namespace QQChat
{
    public partial class LoginPage : Form
    {
        // private string connectionString = "Server=your_server;Database=your_database;Uid=your_user;Pwd=your_password;"; // 替换为你的数据库连接字符串

        public LoginPage()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("账号和密码不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (rbAdmin.Checked) // 管理员登录
            {
                if (username == "0000" && password == "1234")
                {
                    MessageBox.Show("管理员登录成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AdminMainPage adminMainPage = new AdminMainPage();
                    adminMainPage.Show();
                    this.Hide(); // 或者 this.Close(); 根据需求
                }
                else
                {
                    MessageBox.Show("管理员账号或密码错误!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else // 普通用户登录
            {
                // 此处需要数据库验证逻辑
                // 示例: 
                // using (MySqlConnection connection = new MySqlConnection(connectionString))
                // {
                //     try
                //     {
                //         connection.Open();
                //         string query = "SELECT IsApproved, IsBanned FROM Users WHERE UserName = @UserName AND PSW = @PSW";
                //         MySqlCommand command = new MySqlCommand(query, connection);
                //         command.Parameters.AddWithValue("@UserName", username);
                //         command.Parameters.AddWithValue("@PSW", password); // 注意：实际应用中密码应加密存储和比较
                //         MySqlDataReader reader = command.ExecuteReader();
                //         if (reader.Read())
                //         {
                //             bool isApproved = reader.GetBoolean("IsApproved");
                //             bool isBanned = reader.GetBoolean("IsBanned");
                //             if (!isApproved)
                //             {
                //                 MessageBox.Show("账号尚待管理员审核，请耐心等待。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //             }
                //             else if (isBanned)
                //             {
                //                 MessageBox.Show("该账号已被禁用，请联系管理员。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //             }
                //             else
                //             {
                //                 MessageBox.Show("用户登录成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //                 UserMainPage userMainPage = new UserMainPage(); // 传递用户信息
                //                 userMainPage.Show();
                //                 this.Hide();
                //             }
                //         }
                //         else
                //         {
                //             MessageBox.Show("用户名或密码错误!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //         }
                //     }
                //     catch (Exception ex)
                //     {
                //         MessageBox.Show("数据库连接失败: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //     }
                // }
                MessageBox.Show("用户登录功能暂未实现数据库连接。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void llblRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterPage registerPage = new RegisterPage();
            registerPage.Show();
            // 可以选择关闭登录窗口或隐藏，取决于产品设计
            // this.Hide(); 
        }
    }
} 