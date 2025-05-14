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
            ReviewRegistrationPage reviewPage = new ReviewRegistrationPage();
            reviewPage.MdiParent = this; // 如果希望子窗口在主窗口内打开
            reviewPage.Show();
        }

        private void miBanAccount_Click(object sender, EventArgs e)
        {
            BanAccountPage banPage = new BanAccountPage();
            banPage.MdiParent = this; // 如果希望子窗口在主窗口内打开
            banPage.Show();
        }

        private void miManageMessages_Click(object sender, EventArgs e)
        {
            ManageMessagePage manageMessagePage = new ManageMessagePage();
            manageMessagePage.MdiParent = this; // 如果希望子窗口在主窗口内打开
            manageMessagePage.Show();
        }

        // 为了使 MdiParent 生效, AdminMainPage 需要设置 IsMdiContainer = true
        // 这通常在窗体的构造函数或者 Load 事件中设置，或者直接在设计器中设置其属性
        private void AdminMainPage_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
        }
    }
} 