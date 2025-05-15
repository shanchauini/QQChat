using System;
using System.Windows.Forms;
using System.Text.RegularExpressions; // For email validation
using MySql.Data.MySqlClient;

namespace QQChat
{
    public partial class ManagePersonInfoPage : Form
    {
        // private string connectionString = "...";
        private int currentUserId; // 假设从登录时获取并传递过来

        // 构造函数接收当前用户ID
        public ManagePersonInfoPage(int userId)
        {
            InitializeComponent();
            this.currentUserId = userId;
        }
        // 如果没有用户ID传入，可以提供一个默认构造函数，但功能会受限或应提示错误
        public ManagePersonInfoPage()
        {
            InitializeComponent();
            // MessageBox.Show("错误：未指定用户信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            // this.Close(); 
            // 为了设计器兼容，保留一个无参构造函数，但在实际运行时应使用带userId的构造函数
            // 在实际应用中，通常 UserMainPage 在打开此页面时传递 UserId
             this.currentUserId = -1; // 表示无效用户
        }


        private void ManagePersonInfoPage_Load(object sender, EventArgs e)
        {
            if (currentUserId == -1 && !(this.DesignMode)){
                 MessageBox.Show("错误：无法加载用户信息，未指定用户ID。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 this.Close();
                 return;
            }
            LoadUserInfo();
        }

        private void LoadUserInfo()
        {
            string sql = "SELECT UserName, Gender, Email FROM Users WHERE UserId = @UserId";
            var p1 = new MySqlParameter("@UserId", this.currentUserId);
            var dt = DataAccess.ExecuteQuery(sql, p1);
            if (dt.Rows.Count > 0)
            {
                lblCurrentUsername.Text = dt.Rows[0]["UserName"].ToString();
                txtChangeEmail.Text = dt.Rows[0]["Email"].ToString();
                string gender = dt.Rows[0]["Gender"].ToString();
                if (gender == "男") rbChangeMale.Checked = true;
                else if (gender == "女") rbChangeFemale.Checked = true;
            }
            else
            {
                MessageBox.Show("无法加载用户信息。", "错误");
                this.Close();
            }
            txtChangePassword.Clear();
            txtConfirmNewPassword.Clear();
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            string newPassword = txtChangePassword.Text;
            string confirmNewPassword = txtConfirmNewPassword.Text;
            string newEmail = txtChangeEmail.Text.Trim();
            string newGender = rbChangeMale.Checked ? "男" : "女";
            if (!string.IsNullOrEmpty(newPassword) || !string.IsNullOrEmpty(confirmNewPassword))
            {
                if (newPassword != confirmNewPassword)
                {
                    MessageBox.Show("两次输入的新密码不一致!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtChangePassword.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(newPassword))
                {
                    MessageBox.Show("请输入新密码!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtChangePassword.Focus();
                    return;
                }
            }
            if (string.IsNullOrEmpty(newEmail) || !IsValidEmail(newEmail))
            {
                MessageBox.Show("请输入有效的邮箱地址!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtChangeEmail.Focus();
                return;
            }
            string sql;
            if (!string.IsNullOrEmpty(newPassword))
            {
                sql = "UPDATE Users SET PSW = @PSW, Gender = @Gender, Email = @Email WHERE UserId = @UserId";
            }
            else
            {
                sql = "UPDATE Users SET Gender = @Gender, Email = @Email WHERE UserId = @UserId";
            }
            var p1 = new MySqlParameter("@Gender", newGender);
            var p2 = new MySqlParameter("@Email", newEmail);
            var p3 = new MySqlParameter("@UserId", this.currentUserId);
            int rowsAffected = 0;
            if (!string.IsNullOrEmpty(newPassword))
            {
                var p4 = new MySqlParameter("@PSW", newPassword);
                rowsAffected = DataAccess.ExecuteNonQuery(sql, p4, p1, p2, p3);
            }
            else
            {
                rowsAffected = DataAccess.ExecuteNonQuery(sql, p1, p2, p3);
            }
            if (rowsAffected > 0)
            {
                MessageBox.Show("用户信息更新成功!", "成功");
                if (!string.IsNullOrEmpty(newPassword))
                {
                    txtChangePassword.Clear();
                    txtConfirmNewPassword.Clear();
                }
            }
            else
            {
                MessageBox.Show("用户信息更新失败或没有更改。", "提示");
            }
        }

        private void btnCancelChanges_Click(object sender, EventArgs e)
        {
            // 重新加载用户信息，放弃未保存的更改
            LoadUserInfo();
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;
            try
            {
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