using System;
using System.Windows.Forms;
using System.Text.RegularExpressions; // For email validation
// using MySql.Data.MySqlClient; // 稍后需要取消注释并添加 MySQL Connector/NET 引用

namespace QQChat
{
    public partial class RegisterPage : Form
    {
        // private string connectionString = "Server=your_server;Database=your_database;Uid=your_user;Pwd=your_password;"; // 替换为你的数据库连接字符串

        public RegisterPage()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtRegUsername.Text.Trim();
            string password = txtRegPassword.Text;
            string confirmPassword = txtRegConfirmPassword.Text;
            string gender = rbMale.Checked ? "男" : "女";
            string email = txtRegEmail.Text.Trim();

            // 基本验证
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("所有字段均为必填项!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("两次输入的密码不一致!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRegPassword.Focus();
                return;
            }

            // 简单邮箱格式验证
            if (!IsValidEmail(email))
            {
                MessageBox.Show("请输入有效的邮箱地址!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRegEmail.Focus();
                return;
            }

            // 此处需要数据库操作逻辑，将用户信息插入 Users 表
            // IsApproved 默认为 false, IsBanned 默认为 false
            // 示例:
            // using (MySqlConnection connection = new MySqlConnection(connectionString))
            // {
            //     try
            //     {
            //         connection.Open();
            //         // 首先检查用户名是否已存在
            //         string checkUserQuery = "SELECT COUNT(*) FROM Users WHERE UserName = @UserName";
            //         MySqlCommand checkUserCmd = new MySqlCommand(checkUserQuery, connection);
            //         checkUserCmd.Parameters.AddWithValue("@UserName", username);
            //         int userCount = Convert.ToInt32(checkUserCmd.ExecuteScalar());

            //         if (userCount > 0)
            //         {
            //             MessageBox.Show("用户名已存在，请更换其他用户名!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //             txtRegUsername.Focus();
            //             return;
            //         }

            //         // 插入新用户
            //         string insertQuery = "INSERT INTO Users (UserName, PSW, Gender, Email, IsApproved, IsBanned) VALUES (@UserName, @PSW, @Gender, @Email, false, false)";
            //         MySqlCommand insertCmd = new MySqlCommand(insertQuery, connection);
            //         insertCmd.Parameters.AddWithValue("@UserName", username);
            //         insertCmd.Parameters.AddWithValue("@PSW", password); // 实际应用中密码应加密存储
            //         insertCmd.Parameters.AddWithValue("@Gender", gender);
            //         insertCmd.Parameters.AddWithValue("@Email", email);
            //         
            //         int result = insertCmd.ExecuteNonQuery();
            //         if (result > 0)
            //         {
            //             MessageBox.Show("注册申请已提交，请等待管理员审核!", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //             this.Close(); // 关闭注册窗口
            //             // 可以考虑自动打开登录窗口并填写用户名
            //         }
            //         else
            //         {
            //             MessageBox.Show("注册失败，请稍后再试。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //         }
            //     }
            //     catch (Exception ex)
            //     {
            //         MessageBox.Show("数据库操作失败: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //     }
            // }
            MessageBox.Show("注册申请已提交 (模拟，未连接数据库)，请等待管理员审核!", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close(); 
        }

        private void llblBackToLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close(); // 关闭当前注册窗口，登录窗口应该还在后面
            // 如果登录窗口被隐藏了，需要找到它并显示，或者重新创建一个 LoginPage 实例
            // Application.OpenForms["LoginPage"]?.Show(); 
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;
            try
            {
                // 使用正则表达式进行基本邮箱格式验证
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
    }
} 