using System;
using System.Windows.Forms;
using System.Text.RegularExpressions; // For email validation
// using MySql.Data.MySqlClient;

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
            // TODO: 根据 this.currentUserId 从数据库加载用户信息 (UserName, Gender, Email)
            // 用户名通常不允许修改，所以加载后显示在 Label 中
            // 密码不直接显示，只提供修改选项
            // 示例:
            // using (MySqlConnection conn = new MySqlConnection(connectionString))
            // {
            //     try
            //     {
            //         conn.Open();
            //         string query = "SELECT UserName, Gender, Email FROM Users WHERE UserId = @UserId";
            //         MySqlCommand cmd = new MySqlCommand(query, conn);
            //         cmd.Parameters.AddWithValue("@UserId", this.currentUserId);
            //         MySqlDataReader reader = cmd.ExecuteReader();
            //         if (reader.Read())
            //         {
            //             lblCurrentUsername.Text = reader["UserName"].ToString();
            //             txtChangeEmail.Text = reader["Email"].ToString();
            //             string gender = reader["Gender"].ToString();
            //             if (gender == "男") rbChangeMale.Checked = true;
            //             else if (gender == "女") rbChangeFemale.Checked = true;
            //         }
            //         else
            //         {
            //              MessageBox.Show("无法加载用户信息。", "错误");
            //              this.Close();
            //         }
            //     }
            //     catch (Exception ex)
            //     {
            //         MessageBox.Show("加载用户信息失败: " + ex.Message);
            //         this.Close();
            //     }
            // }
            MessageBox.Show("LoadUserInfo 功能暂未实现数据库连接。UserID: " + this.currentUserId, "提示");
            // 模拟加载
            if (this.currentUserId != -1) {
                lblCurrentUsername.Text = "User_" + this.currentUserId; // 模拟用户名
                txtChangeEmail.Text = "user"+this.currentUserId+"@example.com";
                rbChangeMale.Checked = true; 
            } else {
                lblCurrentUsername.Text = "(无效用户)";
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

            // 密码修改验证 (仅当输入了新密码时)
            if (!string.IsNullOrEmpty(newPassword) || !string.IsNullOrEmpty(confirmNewPassword))
            {
                if (newPassword != confirmNewPassword)
                {
                    MessageBox.Show("两次输入的新密码不一致!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtChangePassword.Focus();
                    return;
                }
                 if (string.IsNullOrEmpty(newPassword)) // 如果确认密码有值但新密码没有
                {
                    MessageBox.Show("请输入新密码!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtChangePassword.Focus();
                    return;
                }
            }

            // 邮箱格式验证
            if (string.IsNullOrEmpty(newEmail) || !IsValidEmail(newEmail))
            {
                MessageBox.Show("请输入有效的邮箱地址!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtChangeEmail.Focus();
                return;
            }

            // TODO: 更新数据库 Users 表 (PSW, Gender, Email) for this.currentUserId
            // 如果 newPassword 为空，则不更新密码
            // 示例:
            // using (MySqlConnection conn = new MySqlConnection(connectionString))
            // {
            //     try
            //     {
            //         conn.Open();
            //         string query;
            //         if (!string.IsNullOrEmpty(newPassword))
            //         {
            //             query = "UPDATE Users SET PSW = @PSW, Gender = @Gender, Email = @Email WHERE UserId = @UserId";
            //         }
            //         else
            //         {
            //             query = "UPDATE Users SET Gender = @Gender, Email = @Email WHERE UserId = @UserId";
            //         }
            //         MySqlCommand cmd = new MySqlCommand(query, conn);
            //         if (!string.IsNullOrEmpty(newPassword))
            //         {
            //             cmd.Parameters.AddWithValue("@PSW", newPassword); // 实际应用中应加密
            //         }
            //         cmd.Parameters.AddWithValue("@Gender", newGender);
            //         cmd.Parameters.AddWithValue("@Email", newEmail);
            //         cmd.Parameters.AddWithValue("@UserId", this.currentUserId);
            //         int rowsAffected = cmd.ExecuteNonQuery();
            //         if (rowsAffected > 0)
            //         {
            //             MessageBox.Show("用户信息更新成功!", "成功");
            //             if (!string.IsNullOrEmpty(newPassword)) { // 如果修改了密码，清空密码框
            //                 txtChangePassword.Clear();
            //                 txtConfirmNewPassword.Clear();
            //             }
            //         }
            //         else { MessageBox.Show("用户信息更新失败或没有更改。", "提示"); }
            //     }
            //     catch (Exception ex)
            //     {
            //         MessageBox.Show("更新用户信息失败: " + ex.Message);
            //     }
            // }
            MessageBox.Show("保存更改功能暂未实现数据库连接。将更新 Gender, Email，及可选的 Password。", "提示");
             if (!string.IsNullOrEmpty(newPassword)) { 
                txtChangePassword.Clear();
                txtConfirmNewPassword.Clear();
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