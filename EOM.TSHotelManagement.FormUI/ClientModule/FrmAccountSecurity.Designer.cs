namespace EOM.TSHotelManagement.FormUI
{
    partial class FrmAccountSecurity
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAccountSecurity));
            avatar3 = new AntdUI.Avatar();
            txtOldPassword = new AntdUI.Input();
            lblEmployeeId = new AntdUI.Label();
            avatar2 = new AntdUI.Avatar();
            avatar1 = new AntdUI.Avatar();
            btnUpdatePassword = new AntdUI.Button();
            txtNewPassword = new AntdUI.Input();
            ucWindowHeader1 = new ucWindowHeader();
            SuspendLayout();
            // 
            // avatar3
            // 
            avatar3.Image = (Image)resources.GetObject("avatar3.Image");
            avatar3.ImageFit = AntdUI.TFit.None;
            avatar3.Location = new Point(16, 135);
            avatar3.Name = "avatar3";
            avatar3.Size = new Size(45, 43);
            avatar3.TabIndex = 54;
            avatar3.Text = "a";
            // 
            // txtOldPassword
            // 
            txtOldPassword.BackColor = Color.White;
            txtOldPassword.Font = new Font("Noto Sans SC", 14F);
            txtOldPassword.Location = new Point(59, 132);
            txtOldPassword.Name = "txtOldPassword";
            txtOldPassword.PasswordChar = '*';
            txtOldPassword.PasswordCopy = true;
            txtOldPassword.PlaceholderColorExtend = "";
            txtOldPassword.PlaceholderText = "";
            txtOldPassword.Round = true;
            txtOldPassword.Size = new Size(238, 52);
            txtOldPassword.TabIndex = 53;
            // 
            // lblEmployeeId
            // 
            lblEmployeeId.Font = new Font("Noto Sans SC", 14F);
            lblEmployeeId.Location = new Point(59, 62);
            lblEmployeeId.Name = "lblEmployeeId";
            lblEmployeeId.Size = new Size(238, 43);
            lblEmployeeId.TabIndex = 52;
            lblEmployeeId.Text = "";
            lblEmployeeId.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // avatar2
            // 
            avatar2.Image = (Image)resources.GetObject("avatar2.Image");
            avatar2.ImageFit = AntdUI.TFit.None;
            avatar2.Location = new Point(16, 215);
            avatar2.Name = "avatar2";
            avatar2.Size = new Size(45, 43);
            avatar2.TabIndex = 51;
            avatar2.Text = "a";
            // 
            // avatar1
            // 
            avatar1.Image = (Image)resources.GetObject("avatar1.Image");
            avatar1.ImageFit = AntdUI.TFit.None;
            avatar1.Location = new Point(16, 62);
            avatar1.Name = "avatar1";
            avatar1.Size = new Size(45, 43);
            avatar1.TabIndex = 50;
            avatar1.Text = "a";
            // 
            // btnUpdatePassword
            // 
            btnUpdatePassword.Font = new Font("Noto Sans SC", 12F);
            btnUpdatePassword.Location = new Point(76, 289);
            btnUpdatePassword.Name = "btnUpdatePassword";
            btnUpdatePassword.Shape = AntdUI.TShape.Round;
            btnUpdatePassword.Size = new Size(161, 51);
            btnUpdatePassword.TabIndex = 49;
            btnUpdatePassword.Text = "修改密码";
            btnUpdatePassword.Type = AntdUI.TTypeMini.Primary;
            btnUpdatePassword.Click += btnUpdatePassword_Click;
            // 
            // txtNewPassword
            // 
            txtNewPassword.BackColor = Color.White;
            txtNewPassword.Font = new Font("Noto Sans SC", 14F);
            txtNewPassword.Location = new Point(59, 211);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.PasswordChar = '*';
            txtNewPassword.PasswordCopy = true;
            txtNewPassword.PlaceholderColorExtend = "";
            txtNewPassword.PlaceholderText = "";
            txtNewPassword.Round = true;
            txtNewPassword.Size = new Size(238, 52);
            txtNewPassword.TabIndex = 48;
            // 
            // ucWindowHeader1
            // 
            ucWindowHeader1.Location = new Point(-1, -1);
            ucWindowHeader1.Name = "ucWindowHeader1";
            ucWindowHeader1.Size = new Size(313, 33);
            ucWindowHeader1.TabIndex = 55;
            // 
            // FrmAccountSecurity
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(235, 243, 255);
            ClientSize = new Size(312, 353);
            Controls.Add(ucWindowHeader1);
            Controls.Add(avatar3);
            Controls.Add(txtOldPassword);
            Controls.Add(lblEmployeeId);
            Controls.Add(avatar2);
            Controls.Add(avatar1);
            Controls.Add(btnUpdatePassword);
            Controls.Add(txtNewPassword);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmAccountSecurity";
            Resizable = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "账号安全";
            Load += FrmAccountSecurity_Load;
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Avatar avatar3;
        private AntdUI.Input txtOldPassword;
        private AntdUI.Label lblEmployeeId;
        private AntdUI.Avatar avatar2;
        private AntdUI.Avatar avatar1;
        private AntdUI.Button btnUpdatePassword;
        private AntdUI.Input txtNewPassword;
        private ucWindowHeader ucWindowHeader1;
    }
}