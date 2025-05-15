using System;
using System.Windows.Forms;
using System.Text.RegularExpressions; // For email validation
using MySql.Data.MySqlClient;

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

            // 检查用户名是否已存在
            string checkUserSql = "SELECT COUNT(*) FROM Users WHERE UserName = @UserName";
            var pCheck = new MySqlParameter("@UserName", username);
            var dt = DataAccess.ExecuteQuery(checkUserSql, pCheck);
            if (Convert.ToInt32(dt.Rows[0][0]) > 0)
            {
                MessageBox.Show("用户名已存在，请更换其他用户名!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRegUsername.Focus();
                return;
            }

            // 插入新用户
            string insertSql = "INSERT INTO Users (UserName, PSW, Gender, Email, IsApproved, IsBanned) VALUES (@UserName, @PSW, @Gender, @Email, false, false)";
            var p1 = new MySqlParameter("@UserName", username);
            var p2 = new MySqlParameter("@PSW", password);
            var p3 = new MySqlParameter("@Gender", gender);
            var p4 = new MySqlParameter("@Email", email);
            int result = DataAccess.ExecuteNonQuery(insertSql, p1, p2, p3, p4);
            if (result > 0)
            {
                MessageBox.Show("注册申请已提交，请等待管理员审核!", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("注册失败，请稍后再试。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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