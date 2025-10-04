namespace EOM.TSHotelManagement.FormUI
{
    partial class FrmLoading
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLoading));
            lblTips = new AntdUI.Label();
            lbInternetSoftwareVersion = new AntdUI.Label();
            lblLocalSoftwareVersion = new AntdUI.Label();
            label2 = new AntdUI.Label();
            label1 = new AntdUI.Label();
            fbdSavePath = new FolderBrowserDialog();
            rtbReleaseLog = new RichTextBox();
            btnGo = new AntdUI.Button();
            btnExit = new AntdUI.Button();
            label4 = new AntdUI.Label();
            SuspendLayout();
            // 
            // lblTips
            // 
            lblTips.Font = new Font("Noto Sans SC", 9F);
            lblTips.Location = new Point(12, 48);
            lblTips.Name = "lblTips";
            lblTips.Size = new Size(311, 23);
            lblTips.TabIndex = 3;
            lblTips.Text = "检测新版本中，请让计算机保持联网状态.....";
            lblTips.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbInternetSoftwareVersion
            // 
            lbInternetSoftwareVersion.BackColor = Color.Transparent;
            lbInternetSoftwareVersion.Font = new Font("Noto Sans SC", 9F);
            lbInternetSoftwareVersion.Location = new Point(152, 106);
            lbInternetSoftwareVersion.Name = "lbInternetSoftwareVersion";
            lbInternetSoftwareVersion.Size = new Size(140, 23);
            lbInternetSoftwareVersion.TabIndex = 7;
            lbInternetSoftwareVersion.Text = "";
            lbInternetSoftwareVersion.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblLocalSoftwareVersion
            // 
            lblLocalSoftwareVersion.BackColor = Color.Transparent;
            lblLocalSoftwareVersion.Font = new Font("Noto Sans SC", 9F);
            lblLocalSoftwareVersion.Location = new Point(152, 77);
            lblLocalSoftwareVersion.Name = "lblLocalSoftwareVersion";
            lblLocalSoftwareVersion.Size = new Size(140, 23);
            lblLocalSoftwareVersion.TabIndex = 6;
            lblLocalSoftwareVersion.Text = "";
            lblLocalSoftwareVersion.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Noto Sans SC", 9F);
            label2.Location = new Point(43, 106);
            label2.Name = "label2";
            label2.Size = new Size(103, 23);
            label2.TabIndex = 5;
            label2.Text = "最新程序版本：";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Noto Sans SC", 9F);
            label1.Location = new Point(43, 77);
            label1.Name = "label1";
            label1.Size = new Size(103, 23);
            label1.TabIndex = 4;
            label1.Text = "本地程序版本：";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // rtbReleaseLog
            // 
            rtbReleaseLog.BackColor = Color.FromArgb(243, 249, 255);
            rtbReleaseLog.BorderStyle = BorderStyle.None;
            rtbReleaseLog.Location = new Point(12, 167);
            rtbReleaseLog.Name = "rtbReleaseLog";
            rtbReleaseLog.ReadOnly = true;
            rtbReleaseLog.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtbReleaseLog.Size = new Size(311, 205);
            rtbReleaseLog.TabIndex = 8;
            rtbReleaseLog.Text = "";
            // 
            // btnGo
            // 
            btnGo.Font = new Font("Noto Sans SC", 12F);
            btnGo.Location = new Point(12, 378);
            btnGo.Name = "btnGo";
            btnGo.Shape = AntdUI.TShape.Round;
            btnGo.Size = new Size(111, 38);
            btnGo.TabIndex = 35;
            btnGo.Text = "进入系统";
            btnGo.Type = AntdUI.TTypeMini.Primary;
            btnGo.Click += btnGo_Click;
            // 
            // btnExit
            // 
            btnExit.Font = new Font("Noto Sans SC", 12F);
            btnExit.Location = new Point(212, 378);
            btnExit.Name = "btnExit";
            btnExit.Shape = AntdUI.TShape.Round;
            btnExit.Size = new Size(111, 38);
            btnExit.TabIndex = 36;
            btnExit.Text = "退出系统";
            btnExit.Type = AntdUI.TTypeMini.Primary;
            btnExit.Click += btnExit_Click;
            // 
            // label4
            // 
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Noto Sans SC", 9F);
            label4.Location = new Point(43, 135);
            label4.Name = "label4";
            label4.Size = new Size(103, 23);
            label4.TabIndex = 37;
            label4.Text = "程序更新日志：";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FrmLoading
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(243, 249, 255);
            ClientSize = new Size(335, 424);
            Controls.Add(label4);
            Controls.Add(btnExit);
            Controls.Add(btnGo);
            Controls.Add(rtbReleaseLog);
            Controls.Add(lbInternetSoftwareVersion);
            Controls.Add(lblLocalSoftwareVersion);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblTips);
            Font = new Font("Noto Sans SC", 9F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmLoading";
            Resizable = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmLoading";
            Load += FrmLoading_Load;
            ResumeLayout(false);
        }

        #endregion
        private AntdUI.Label lblTips;
        private AntdUI.Label lbInternetSoftwareVersion;
        private AntdUI.Label lblLocalSoftwareVersion;
        private AntdUI.Label label2;
        private AntdUI.Label label1;
        private AntdUI.Label label3;
        private FolderBrowserDialog fbdSavePath;
        private RichTextBox rtbReleaseLog;
        private AntdUI.Button btnGo;
        private AntdUI.Button btnExit;
        private AntdUI.Label label4;
    }
}