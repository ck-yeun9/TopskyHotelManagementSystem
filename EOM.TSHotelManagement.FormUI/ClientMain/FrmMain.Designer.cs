namespace EOM.TSHotelManagement.FormUI
{
    partial class FrmMain
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            lblSoftName = new Label();
            pnlMID = new Panel();
            niClientIcon = new NotifyIcon(components);
            linkLabel1 = new LinkLabel();
            tmrFont = new System.Windows.Forms.Timer(components);
            lbHello = new Label();
            pnlCheckInfo = new Panel();
            lblCheckDay = new AntdUI.Label();
            lblClose = new Label();
            label4 = new Label();
            label2 = new Label();
            picLogo = new PictureBox();
            muNavBar = new AntdUI.Menu();
            btnSetting = new AntdUI.Button();
            cpUITheme = new AntdUI.ColorPicker();
            lblScroll = new AntdUI.Label();
            ltNow = new AntdUI.LabelTime();
            btnMinimize = new AntdUI.Button();
            btnClose = new AntdUI.Button();
            pnlCheckInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // lblSoftName
            // 
            lblSoftName.BackColor = Color.Transparent;
            lblSoftName.FlatStyle = FlatStyle.Flat;
            lblSoftName.Font = new Font("Noto Sans SC", 14.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSoftName.Location = new Point(328, 7);
            lblSoftName.Margin = new Padding(4, 0, 4, 0);
            lblSoftName.Name = "lblSoftName";
            lblSoftName.Size = new Size(547, 36);
            lblSoftName.TabIndex = 14;
            lblSoftName.Text = "TS酒店管理系统";
            lblSoftName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlMID
            // 
            pnlMID.BackColor = Color.Transparent;
            pnlMID.BackgroundImageLayout = ImageLayout.Stretch;
            pnlMID.Location = new Point(4, 225);
            pnlMID.Margin = new Padding(4);
            pnlMID.Name = "pnlMID";
            pnlMID.Size = new Size(1072, 490);
            pnlMID.TabIndex = 23;
            // 
            // niClientIcon
            // 
            niClientIcon.Icon = (Icon)resources.GetObject("niClientIcon.Icon");
            niClientIcon.Text = "TS酒店管理系统";
            niClientIcon.Visible = true;
            niClientIcon.BalloonTipClosed += niClientIcon_BalloonTipClosed;
            niClientIcon.MouseClick += niClientIcon_MouseClick;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.BackColor = Color.Transparent;
            linkLabel1.Font = new Font("Noto Sans SC", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabel1.LinkBehavior = LinkBehavior.HoverUnderline;
            linkLabel1.Location = new Point(214, 25);
            linkLabel1.Margin = new Padding(4, 0, 4, 0);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(49, 14);
            linkLabel1.TabIndex = 26;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "未打卡";
            linkLabel1.VisitedLinkColor = Color.Green;
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // tmrFont
            // 
            tmrFont.Enabled = true;
            tmrFont.Interval = 1000;
            tmrFont.Tick += tmrFont_Tick;
            // 
            // lbHello
            // 
            lbHello.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lbHello.AutoSize = true;
            lbHello.BackColor = Color.Transparent;
            lbHello.FlatStyle = FlatStyle.Flat;
            lbHello.Font = new Font("Noto Sans SC", 14.2499981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbHello.Location = new Point(5, 198);
            lbHello.Margin = new Padding(4, 0, 4, 0);
            lbHello.Name = "lbHello";
            lbHello.Size = new Size(53, 19);
            lbHello.TabIndex = 30;
            lbHello.Text = "Hello";
            // 
            // pnlCheckInfo
            // 
            pnlCheckInfo.BackColor = Color.Transparent;
            pnlCheckInfo.BackgroundImage = Properties.Resources.打卡2;
            pnlCheckInfo.BackgroundImageLayout = ImageLayout.Stretch;
            pnlCheckInfo.Controls.Add(lblCheckDay);
            pnlCheckInfo.Controls.Add(lblClose);
            pnlCheckInfo.Controls.Add(label4);
            pnlCheckInfo.Controls.Add(label2);
            pnlCheckInfo.Location = new Point(208, 58);
            pnlCheckInfo.Margin = new Padding(4);
            pnlCheckInfo.Name = "pnlCheckInfo";
            pnlCheckInfo.Size = new Size(103, 103);
            pnlCheckInfo.TabIndex = 27;
            pnlCheckInfo.Visible = false;
            // 
            // lblCheckDay
            // 
            lblCheckDay.Font = new Font("Noto Sans SC", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCheckDay.Location = new Point(7, 42);
            lblCheckDay.Name = "lblCheckDay";
            lblCheckDay.Size = new Size(50, 23);
            lblCheckDay.TabIndex = 4;
            lblCheckDay.Text = "365";
            lblCheckDay.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblClose
            // 
            lblClose.AutoSize = true;
            lblClose.Font = new Font("Microsoft Sans Serif", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lblClose.Location = new Point(77, 7);
            lblClose.Margin = new Padding(4, 0, 4, 0);
            lblClose.Name = "lblClose";
            lblClose.Size = new Size(16, 17);
            lblClose.TabIndex = 3;
            lblClose.Text = "×";
            lblClose.Click += lblClose_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Noto Sans SC", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(21, 68);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(21, 14);
            label4.TabIndex = 2;
            label4.Text = "天";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Noto Sans SC", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(6, 11);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(65, 12);
            label2.TabIndex = 0;
            label2.Text = "您已打卡：";
            // 
            // picLogo
            // 
            picLogo.BackColor = Color.Transparent;
            picLogo.BackgroundImage = (Image)resources.GetObject("picLogo.BackgroundImage");
            picLogo.BackgroundImageLayout = ImageLayout.Stretch;
            picLogo.Cursor = Cursors.Hand;
            picLogo.Location = new Point(5, 7);
            picLogo.Margin = new Padding(4);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(165, 111);
            picLogo.TabIndex = 15;
            picLogo.TabStop = false;
            // 
            // muNavBar
            // 
            muNavBar.Font = new Font("Noto Sans SC", 14.2499981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            muNavBar.Location = new Point(311, 172);
            muNavBar.Mode = AntdUI.TMenuMode.Horizontal;
            muNavBar.Name = "muNavBar";
            muNavBar.Size = new Size(765, 45);
            muNavBar.TabIndex = 39;
            muNavBar.Text = "menu1";
            muNavBar.SelectChanged += muNavBar_SelectChanged;
            // 
            // btnSetting
            // 
            btnSetting.BackColor = Color.FromArgb(22, 119, 255);
            btnSetting.Font = new Font("Noto Sans SC", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSetting.Location = new Point(946, 4);
            btnSetting.Name = "btnSetting";
            btnSetting.Shape = AntdUI.TShape.Round;
            btnSetting.Size = new Size(41, 38);
            btnSetting.TabIndex = 42;
            btnSetting.Type = AntdUI.TTypeMini.Info;
            btnSetting.MouseClick += btnSetting_MouseClick;
            // 
            // cpUITheme
            // 
            cpUITheme.Location = new Point(899, 4);
            cpUITheme.Name = "cpUITheme";
            cpUITheme.Round = true;
            cpUITheme.Size = new Size(41, 38);
            cpUITheme.TabIndex = 43;
            cpUITheme.Text = "col";
            cpUITheme.Value = Color.FromArgb(22, 119, 255);
            cpUITheme.ValueChanged += cpUITheme_ValueChanged;
            // 
            // lblScroll
            // 
            lblScroll.Font = new Font("Noto Sans SC", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblScroll.Location = new Point(328, 49);
            lblScroll.Name = "lblScroll";
            lblScroll.Size = new Size(745, 39);
            lblScroll.TabIndex = 44;
            lblScroll.Text = "";
            lblScroll.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ltNow
            // 
            ltNow.AutoWidth = true;
            ltNow.Font = new Font("Noto Sans SC", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ltNow.Location = new Point(5, 142);
            ltNow.Name = "ltNow";
            ltNow.Size = new Size(127, 35);
            ltNow.TabIndex = 45;
            // 
            // btnMinimize
            // 
            btnMinimize.Anchor = AnchorStyles.Right;
            btnMinimize.BackColor = Color.FromArgb(22, 119, 255);
            btnMinimize.DisplayStyle = AntdUI.TButtonDisplayStyle.Text;
            btnMinimize.Font = new Font("Noto Sans SC", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnMinimize.Location = new Point(993, 4);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Shape = AntdUI.TShape.Round;
            btnMinimize.Size = new Size(38, 38);
            btnMinimize.TabIndex = 145;
            btnMinimize.Type = AntdUI.TTypeMini.Info;
            btnMinimize.Click += picFormSize_Click;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.BackColor = Color.FromArgb(22, 119, 255);
            btnClose.DisplayStyle = AntdUI.TButtonDisplayStyle.Text;
            btnClose.Font = new Font("Noto Sans SC", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClose.Location = new Point(1037, 4);
            btnClose.Name = "btnClose";
            btnClose.Shape = AntdUI.TShape.Round;
            btnClose.Size = new Size(38, 38);
            btnClose.TabIndex = 144;
            btnClose.Type = AntdUI.TTypeMini.Info;
            btnClose.Click += picClose_Click;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.Disable;
            BackColor = Color.FromArgb(235, 243, 255);
            CausesValidation = false;
            ClientSize = new Size(1080, 721);
            Controls.Add(btnMinimize);
            Controls.Add(btnClose);
            Controls.Add(ltNow);
            Controls.Add(lblScroll);
            Controls.Add(cpUITheme);
            Controls.Add(btnSetting);
            Controls.Add(muNavBar);
            Controls.Add(lbHello);
            Controls.Add(pnlCheckInfo);
            Controls.Add(linkLabel1);
            Controls.Add(pnlMID);
            Controls.Add(picLogo);
            Controls.Add(lblSoftName);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "FrmMain";
            Resizable = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TS酒店管理系统";
            FormClosing += FrmMain_FormClosing;
            FormClosed += FrmMain_FormClosed;
            Load += FrmMain_Load;
            MouseDown += FrmMain_MouseDown;
            MouseMove += FrmMain_MouseMove;
            pnlCheckInfo.ResumeLayout(false);
            pnlCheckInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label lblSoftName;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Panel pnlMID;
        private System.Windows.Forms.ToolStripMenuItem tsmiCheckUpdate;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Panel pnlCheckInfo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblClose;
        public System.Windows.Forms.NotifyIcon niClientIcon;
        private System.Windows.Forms.Timer tmrFont;
        private System.Windows.Forms.Label lbHello;
        private AntdUI.Menu muNavBar;
        private AntdUI.Button btnSetting;
        private AntdUI.ColorPicker cpUITheme;
        private AntdUI.Label lblCheckDay;
        private AntdUI.Label lblScroll;
        private AntdUI.LabelTime ltNow;
        private AntdUI.Button btnMinimize;
        private AntdUI.Button btnClose;
    }
}