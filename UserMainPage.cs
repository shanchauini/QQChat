using System;
using System.Windows.Forms;

namespace QQChat
{
    public partial class UserMainPage : Form
    {
        private int currentUserId;

        public UserMainPage(int userId)
        {
            InitializeComponent();
            this.currentUserId = userId;
        }

        public UserMainPage()
        {
            InitializeComponent();
            this.currentUserId = -1;
        }

        private void miManageInfo_Click(object sender, EventArgs e)
        {
            var manageInfoPage = new ManagePersonInfoPage(currentUserId);
            manageInfoPage.Show();
        }

        private void miFriendRequests_Click(object sender, EventArgs e)
        {
            var friendRequestPage = new FriendRequestPage(currentUserId);
            friendRequestPage.Show();
        }

        private void miMyRequests_Click(object sender, EventArgs e)
        {
            var myFriendRequestPage = new MyFriendRequestPage(currentUserId);
            myFriendRequestPage.Show();
        }

        private void miFriendList_Click(object sender, EventArgs e)
        {
            var friendListPage = new FriendListPage(currentUserId);
            friendListPage.Show();
        }

        private void miHistoryMessages_Click(object sender, EventArgs e)
        {
            var historyMessagePage = new HistoryMessagePage(currentUserId);
            historyMessagePage.Show();
        }

        private void miLogout_Click(object sender, EventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
            this.Close();
        }

        private void UserMainPage_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
        }

        private void UserMainPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
} 