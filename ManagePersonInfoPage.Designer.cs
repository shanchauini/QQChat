namespace QQChat
{
    partial class ManagePersonInfoPage
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblUsernameLabel = new System.Windows.Forms.Label();
            this.lblCurrentUsername = new System.Windows.Forms.Label();
            this.lblChangePassword = new System.Windows.Forms.Label();
            this.txtChangePassword = new System.Windows.Forms.TextBox();
            this.lblConfirmNewPassword = new System.Windows.Forms.Label();
            this.txtConfirmNewPassword = new System.Windows.Forms.TextBox();
            this.gbChangeGender = new System.Windows.Forms.GroupBox();
            this.rbChangeFemale = new System.Windows.Forms.RadioButton();
            this.rbChangeMale = new System.Windows.Forms.RadioButton();
            this.lblChangeEmail = new System.Windows.Forms.Label();
            this.txtChangeEmail = new System.Windows.Forms.TextBox();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.btnCancelChanges = new System.Windows.Forms.Button();
            this.gbChangeGender.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUsernameLabel
            // 
            this.lblUsernameLabel.AutoSize = true;
            this.lblUsernameLabel.Location = new System.Drawing.Point(50, 50);
            this.lblUsernameLabel.Name = "lblUsernameLabel";
            this.lblUsernameLabel.TabIndex = 0;
            this.lblUsernameLabel.Text = "用户名:";
            // 
            // lblCurrentUsername
            // 
            this.lblCurrentUsername.AutoSize = true;
            this.lblCurrentUsername.Location = new System.Drawing.Point(150, 50);
            this.lblCurrentUsername.Name = "lblCurrentUsername";
            this.lblCurrentUsername.TabIndex = 1;
            this.lblCurrentUsername.Text = "(当前用户名)"; // 将由代码加载
            // 
            // lblChangePassword
            // 
            this.lblChangePassword.AutoSize = true;
            this.lblChangePassword.Location = new System.Drawing.Point(50, 90);
            this.lblChangePassword.Name = "lblChangePassword";
            this.lblChangePassword.TabIndex = 2;
            this.lblChangePassword.Text = "修改密码:";
            // 
            // txtChangePassword
            // 
            this.txtChangePassword.Location = new System.Drawing.Point(150, 87);
            this.txtChangePassword.Name = "txtChangePassword";
            this.txtChangePassword.PasswordChar = '*';
            this.txtChangePassword.Size = new System.Drawing.Size(200, 20);
            this.txtChangePassword.TabIndex = 3;
            // 
            // lblConfirmNewPassword
            // 
            this.lblConfirmNewPassword.AutoSize = true;
            this.lblConfirmNewPassword.Location = new System.Drawing.Point(50, 130);
            this.lblConfirmNewPassword.Name = "lblConfirmNewPassword";
            this.lblConfirmNewPassword.TabIndex = 4;
            this.lblConfirmNewPassword.Text = "确认新密码:";
            // 
            // txtConfirmNewPassword
            // 
            this.txtConfirmNewPassword.Location = new System.Drawing.Point(150, 127);
            this.txtConfirmNewPassword.Name = "txtConfirmNewPassword";
            this.txtConfirmNewPassword.PasswordChar = '*';
            this.txtConfirmNewPassword.Size = new System.Drawing.Size(200, 20);
            this.txtConfirmNewPassword.TabIndex = 5;
            // 
            // gbChangeGender
            // 
            this.gbChangeGender.Controls.Add(this.rbChangeFemale);
            this.gbChangeGender.Controls.Add(this.rbChangeMale);
            this.gbChangeGender.Location = new System.Drawing.Point(50, 170);
            this.gbChangeGender.Name = "gbChangeGender";
            this.gbChangeGender.Size = new System.Drawing.Size(300, 50);
            this.gbChangeGender.TabIndex = 6;
            this.gbChangeGender.TabStop = false;
            this.gbChangeGender.Text = "修改性别";
            // 
            // rbChangeFemale
            // 
            this.rbChangeFemale.AutoSize = true;
            this.rbChangeFemale.Location = new System.Drawing.Point(180, 20);
            this.rbChangeFemale.Name = "rbChangeFemale";
            this.rbChangeFemale.TabIndex = 1;
            this.rbChangeFemale.Text = "女";
            this.rbChangeFemale.UseVisualStyleBackColor = true;
            // 
            // rbChangeMale
            // 
            this.rbChangeMale.AutoSize = true;
            this.rbChangeMale.Location = new System.Drawing.Point(100, 20);
            this.rbChangeMale.Name = "rbChangeMale";
            this.rbChangeMale.TabIndex = 0;
            this.rbChangeMale.TabStop = true;
            this.rbChangeMale.Text = "男";
            this.rbChangeMale.UseVisualStyleBackColor = true;
            // 
            // lblChangeEmail
            // 
            this.lblChangeEmail.AutoSize = true;
            this.lblChangeEmail.Location = new System.Drawing.Point(50, 240);
            this.lblChangeEmail.Name = "lblChangeEmail";
            this.lblChangeEmail.TabIndex = 7;
            this.lblChangeEmail.Text = "修改邮箱:";
            // 
            // txtChangeEmail
            // 
            this.txtChangeEmail.Location = new System.Drawing.Point(150, 237);
            this.txtChangeEmail.Name = "txtChangeEmail";
            this.txtChangeEmail.Size = new System.Drawing.Size(200, 20);
            this.txtChangeEmail.TabIndex = 8;
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Location = new System.Drawing.Point(150, 280);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(100, 30);
            this.btnSaveChanges.TabIndex = 9;
            this.btnSaveChanges.Text = "保存更改";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // btnCancelChanges
            // 
            this.btnCancelChanges.Location = new System.Drawing.Point(270, 280);
            this.btnCancelChanges.Name = "btnCancelChanges";
            this.btnCancelChanges.Size = new System.Drawing.Size(100, 30);
            this.btnCancelChanges.TabIndex = 10;
            this.btnCancelChanges.Text = "取消/重置";
            this.btnCancelChanges.UseVisualStyleBackColor = true;
            this.btnCancelChanges.Click += new System.EventHandler(this.btnCancelChanges_Click);
            // 
            // ManagePersonInfoPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCancelChanges);
            this.Controls.Add(this.btnSaveChanges);
            this.Controls.Add(this.txtChangeEmail);
            this.Controls.Add(this.lblChangeEmail);
            this.Controls.Add(this.gbChangeGender);
            this.Controls.Add(this.txtConfirmNewPassword);
            this.Controls.Add(this.lblConfirmNewPassword);
            this.Controls.Add(this.txtChangePassword);
            this.Controls.Add(this.lblChangePassword);
            this.Controls.Add(this.lblCurrentUsername);
            this.Controls.Add(this.lblUsernameLabel);
            this.Name = "ManagePersonInfoPage";
            this.Text = "个人信息管理";
            this.Load += new System.EventHandler(this.ManagePersonInfoPage_Load);
            this.gbChangeGender.ResumeLayout(false);
            this.gbChangeGender.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblUsernameLabel;
        private System.Windows.Forms.Label lblCurrentUsername;
        private System.Windows.Forms.Label lblChangePassword;
        private System.Windows.Forms.TextBox txtChangePassword;
        private System.Windows.Forms.Label lblConfirmNewPassword;
        private System.Windows.Forms.TextBox txtConfirmNewPassword;
        private System.Windows.Forms.GroupBox gbChangeGender;
        private System.Windows.Forms.RadioButton rbChangeFemale;
        private System.Windows.Forms.RadioButton rbChangeMale;
        private System.Windows.Forms.Label lblChangeEmail;
        private System.Windows.Forms.TextBox txtChangeEmail;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.Button btnCancelChanges;
    }
} 