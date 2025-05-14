using System;
using System.Windows.Forms;

namespace QQChat
{
    public partial class UserMainPage : Form
    {
        public UserMainPage()
        {
            InitializeComponent();
        }

        private void miManageInfo_Click(object sender, EventArgs e)
        {
            ManagePersonInfoPage manageInfoPage = new ManagePersonInfoPage();
            manageInfoPage.MdiParent = this;
            manageInfoPage.Show();
        }

        private void miFriendRequests_Click(object sender, EventArgs e)
        {
            FriendRequestPage friendRequestPage = new FriendRequestPage();
            friendRequestPage.MdiParent = this;
            friendRequestPage.Show();
        }

        private void miMyRequests_Click(object sender, EventArgs e)
        {
            MyFriendRequestPage myFriendRequestPage = new MyFriendRequestPage();
            myFriendRequestPage.MdiParent = this;
            myFriendRequestPage.Show();
        }

        private void miFriendList_Click(object sender, EventArgs e)
        {
            FriendListPage friendListPage = new FriendListPage();
            friendListPage.MdiParent = this;
            friendListPage.Show();
        }

        private void miHistoryMessages_Click(object sender, EventArgs e)
        {
            HistoryMessagePage historyMessagePage = new HistoryMessagePage();
            historyMessagePage.MdiParent = this;
            historyMessagePage.Show();
        }

        private void UserMainPage_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
        }
    }
} 