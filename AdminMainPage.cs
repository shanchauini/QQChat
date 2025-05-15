using System;
using System.Windows.Forms;

namespace QQChat
{
    public partial class AdminMainPage : Form
    {
        public AdminMainPage()
        {
            InitializeComponent();
        }

        private void miReviewRegistration_Click(object sender, EventArgs e)
        {
            var reviewPage = new ReviewRegistrationPage();
            reviewPage.Show();
        }

        private void miBanAccount_Click(object sender, EventArgs e)
        {
            var banPage = new BanAccountPage();
            banPage.Show();
        }

        private void miManageMessages_Click(object sender, EventArgs e)
        {
            var manageMessagePage = new ManageMessagePage();
            manageMessagePage.Show();
        }

        private void miLogout_Click(object sender, EventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
            this.Close();
        }

        // 为了使 MdiParent 生效, AdminMainPage 需要设置 IsMdiContainer = true
        // 这通常在窗体的构造函数或者 Load 事件中设置，或者直接在设计器中设置其属性
        private void AdminMainPage_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
        }

        private void AdminMainPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
} 