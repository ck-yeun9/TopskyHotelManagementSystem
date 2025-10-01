namespace EOM.TSHotelManagement.FormUI
{
    partial class FrmLogin
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            label2 = new Label();
            txtAccount = new AntdUI.Input();
            txtWorkerPwd = new AntdUI.Input();
            picLogin = new AntdUI.Button();
            avatar1 = new AntdUI.Avatar();
            avatar2 = new AntdUI.Avatar();
            label1 = new AntdUI.Label();
            btnMinimize = new AntdUI.Button();
            btnClose = new AntdUI.Button();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("宋体", 15F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label2.Location = new Point(368, 199);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(29, 20);
            label2.TabIndex = 5;
            label2.Text = "  ";
            // 
            // txtAccount
            // 
            txtAccount.BackColor = Color.White;
            txtAccount.Font = new Font("Noto Sans SC", 12F);
            txtAccount.Location = new Point(648, 190);
            txtAccount.Name = "txtAccount";
            txtAccount.PlaceholderText = "";
            txtAccount.Size = new Size(238, 52);
            txtAccount.TabIndex = 32;
            txtAccount.Text = "WK010";
            // 
            // txtWorkerPwd
            // 
            txtWorkerPwd.BackColor = Color.White;
            txtWorkerPwd.Font = new Font("Noto Sans SC", 12F);
            txtWorkerPwd.Location = new Point(648, 264);
            txtWorkerPwd.Name = "txtWorkerPwd";
            txtWorkerPwd.PasswordChar = '*';
            txtWorkerPwd.PasswordCopy = true;
            txtWorkerPwd.PlaceholderColorExtend = "";
            txtWorkerPwd.PlaceholderText = "";
            txtWorkerPwd.Size = new Size(238, 52);
            txtWorkerPwd.TabIndex = 33;
            txtWorkerPwd.Text = "WK010";
            // 
            // picLogin
            // 
            picLogin.Font = new Font("Noto Sans SC", 12F);
            picLogin.Location = new Point(658, 342);
            picLogin.Name = "picLogin";
            picLogin.Shape = AntdUI.TShape.Round;
            picLogin.Size = new Size(191, 57);
            picLogin.TabIndex = 34;
            picLogin.Text = "登      录";
            picLogin.Type = AntdUI.TTypeMini.Primary;
            picLogin.Click += picLogin_Click;
            // 
            // avatar1
            // 
            avatar1.Image = (Image)resources.GetObject("avatar1.Image");
            avatar1.ImageFit = AntdUI.TFit.None;
            avatar1.Location = new Point(605, 195);
            avatar1.Name = "avatar1";
            avatar1.Size = new Size(45, 43);
            avatar1.TabIndex = 38;
            avatar1.Text = "a";
            // 
            // avatar2
            // 
            avatar2.Image = (Image)resources.GetObject("avatar2.Image");
            avatar2.ImageFit = AntdUI.TFit.None;
            avatar2.Location = new Point(605, 268);
            avatar2.Name = "avatar2";
            avatar2.Size = new Size(45, 43);
            avatar2.TabIndex = 39;
            avatar2.Text = "a";
            // 
            // label1
            // 
            label1.Font = new Font("Noto Sans SC", 14F);
            label1.Location = new Point(648, 72);
            label1.Name = "label1";
            label1.Size = new Size(222, 83);
            label1.TabIndex = 40;
            label1.Text = "欢迎登录";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnMinimize
            // 
            btnMinimize.Anchor = AnchorStyles.Right;
            btnMinimize.BackColor = Color.FromArgb(22, 119, 255);
            btnMinimize.DisplayStyle = AntdUI.TButtonDisplayStyle.Text;
            btnMinimize.Font = new Font("Noto Sans SC", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnMinimize.Location = new Point(832, 2);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Shape = AntdUI.TShape.Round;
            btnMinimize.Size = new Size(38, 38);
            btnMinimize.TabIndex = 143;
            btnMinimize.Type = AntdUI.TTypeMini.Info;
            btnMinimize.Click += picMin_Click;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.BackColor = Color.FromArgb(22, 119, 255);
            btnClose.DisplayStyle = AntdUI.TButtonDisplayStyle.Text;
            btnClose.Font = new Font("Noto Sans SC", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClose.Location = new Point(876, 2);
            btnClose.Name = "btnClose";
            btnClose.Shape = AntdUI.TShape.Round;
            btnClose.Size = new Size(38, 38);
            btnClose.TabIndex = 142;
            btnClose.Type = AntdUI.TTypeMini.Info;
            btnClose.Click += picClose_Click;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(235, 243, 255);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(916, 510);
            Controls.Add(btnMinimize);
            Controls.Add(btnClose);
            Controls.Add(label1);
            Controls.Add(avatar2);
            Controls.Add(avatar1);
            Controls.Add(picLogin);
            Controls.Add(txtWorkerPwd);
            Controls.Add(txtAccount);
            Controls.Add(label2);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "FrmLogin";
            Resizable = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TS酒店管理系统";
            Load += FrmLogin_Load;
            MouseDown += FrmLogin_MouseDown;
            MouseMove += FrmLogin_MouseMove;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label label2;
        private AntdUI.Input txtAccount;
        private AntdUI.Input txtWorkerPwd;
        private AntdUI.Button picLogin;
        private AntdUI.Avatar avatar1;
        private AntdUI.Avatar avatar2;
        private AntdUI.Label label1;
        private AntdUI.Button btnMinimize;
        private AntdUI.Button btnClose;
    }
}

