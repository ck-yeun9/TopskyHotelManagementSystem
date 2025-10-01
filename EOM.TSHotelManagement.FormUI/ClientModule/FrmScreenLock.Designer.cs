namespace EOM.TSHotelManagement.FormUI
{
    partial class FrmScreenLock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmScreenLock));
            txtPassword = new AntdUI.Input();
            btnUnlock = new AntdUI.Button();
            SuspendLayout();
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Noto Sans SC", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(212, 334);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.PasswordCopy = true;
            txtPassword.PlaceholderColor = Color.Gray;
            txtPassword.PlaceholderText = "请输入当前登录账号密码...";
            txtPassword.Prefix = Properties.Resources._lock;
            txtPassword.Round = true;
            txtPassword.Size = new Size(285, 45);
            txtPassword.TabIndex = 0;
            txtPassword.TextAlign = HorizontalAlignment.Center;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // btnUnlock
            // 
            btnUnlock.Font = new Font("Noto Sans SC", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnUnlock.Location = new Point(503, 334);
            btnUnlock.Name = "btnUnlock";
            btnUnlock.Shape = AntdUI.TShape.Round;
            btnUnlock.Size = new Size(85, 45);
            btnUnlock.TabIndex = 1;
            btnUnlock.Text = "解   锁";
            btnUnlock.Type = AntdUI.TTypeMini.Primary;
            btnUnlock.Click += btnUnlock_Click;
            // 
            // FrmScreenLock
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(235, 243, 255);
            BackgroundImage = Properties.Resources.lock_screen;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(btnUnlock);
            Controls.Add(txtPassword);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmScreenLock";
            Resizable = false;
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "系统已锁定";
            TopMost = true;
            Load += FrmScreenLock_Load;
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Input txtPassword;
        private AntdUI.Button btnUnlock;
    }
}