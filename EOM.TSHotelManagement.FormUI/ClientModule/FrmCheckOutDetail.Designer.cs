namespace EOM.TSHotelManagement.FormUI
{
    partial class FrmCheckOutDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCheckOutDetail));
            dtpCheckTime = new AntdUI.Input();
            label24 = new Label();
            txtRoomNo = new AntdUI.Input();
            label27 = new Label();
            CustoName = new AntdUI.Input();
            label28 = new Label();
            CustoNo = new AntdUI.Input();
            lblChange = new Label();
            btnBalance = new AntdUI.Button();
            label25 = new Label();
            txtReceipts = new AntdUI.Input();
            label21 = new Label();
            btnPg = new AntdUI.Pagination();
            lblVIP = new Label();
            dgvSpendList = new AntdUI.Table();
            label29 = new Label();
            lblGetReceipts = new Label();
            lblVIPPrice = new Label();
            lable00 = new Label();
            label18 = new Label();
            label1 = new Label();
            label15 = new Label();
            lblDay = new Label();
            label17 = new Label();
            ucWindowHeader1 = new ucWindowHeader();
            SuspendLayout();
            // 
            // dtpCheckTime
            // 
            dtpCheckTime.Font = new Font("Noto Sans SC", 12F);
            dtpCheckTime.Location = new Point(408, 51);
            dtpCheckTime.Name = "dtpCheckTime";
            dtpCheckTime.PlaceholderText = "";
            dtpCheckTime.ReadOnly = true;
            dtpCheckTime.Round = true;
            dtpCheckTime.Size = new Size(180, 42);
            dtpCheckTime.TabIndex = 185;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new Font("Noto Sans SC", 14.2499981F);
            label24.Location = new Point(18, 61);
            label24.Name = "label24";
            label24.Size = new Size(85, 19);
            label24.TabIndex = 172;
            label24.Text = "客户编号";
            // 
            // txtRoomNo
            // 
            txtRoomNo.Font = new Font("Noto Sans SC", 12F);
            txtRoomNo.Location = new Point(408, 102);
            txtRoomNo.Name = "txtRoomNo";
            txtRoomNo.PlaceholderText = "";
            txtRoomNo.ReadOnly = true;
            txtRoomNo.Round = true;
            txtRoomNo.Size = new Size(180, 42);
            txtRoomNo.TabIndex = 184;
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Font = new Font("Noto Sans SC", 14.2499981F);
            label27.Location = new Point(323, 113);
            label27.Name = "label27";
            label27.Size = new Size(85, 19);
            label27.TabIndex = 175;
            label27.Text = "房间编号";
            // 
            // CustoName
            // 
            CustoName.Font = new Font("Noto Sans SC", 12F);
            CustoName.Location = new Point(103, 102);
            CustoName.Name = "CustoName";
            CustoName.PlaceholderText = "";
            CustoName.ReadOnly = true;
            CustoName.Round = true;
            CustoName.Size = new Size(214, 42);
            CustoName.TabIndex = 183;
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Font = new Font("Noto Sans SC", 14.2499981F);
            label28.Location = new Point(323, 61);
            label28.Name = "label28";
            label28.Size = new Size(85, 19);
            label28.TabIndex = 174;
            label28.Text = "入住时间";
            // 
            // CustoNo
            // 
            CustoNo.Font = new Font("Noto Sans SC", 12F);
            CustoNo.Location = new Point(103, 51);
            CustoNo.Name = "CustoNo";
            CustoNo.PlaceholderText = "";
            CustoNo.ReadOnly = true;
            CustoNo.Round = true;
            CustoNo.Size = new Size(214, 42);
            CustoNo.TabIndex = 182;
            // 
            // lblChange
            // 
            lblChange.AutoSize = true;
            lblChange.Font = new Font("Noto Sans SC", 11.9999981F);
            lblChange.Location = new Point(605, 445);
            lblChange.Name = "lblChange";
            lblChange.Size = new Size(38, 17);
            lblChange.TabIndex = 167;
            lblChange.Text = "0.00";
            // 
            // btnBalance
            // 
            btnBalance.Font = new Font("Noto Sans SC", 12F);
            btnBalance.Location = new Point(544, 533);
            btnBalance.Name = "btnBalance";
            btnBalance.Shape = AntdUI.TShape.Round;
            btnBalance.Size = new Size(132, 48);
            btnBalance.TabIndex = 181;
            btnBalance.Text = "结        算";
            btnBalance.Type = AntdUI.TTypeMini.Primary;
            btnBalance.Click += btnBalance_Click;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Font = new Font("Noto Sans SC", 11.9999981F);
            label25.Location = new Point(323, 444);
            label25.Name = "label25";
            label25.Size = new Size(88, 17);
            label25.TabIndex = 168;
            label25.Text = "会员折扣：";
            // 
            // txtReceipts
            // 
            txtReceipts.Font = new Font("Noto Sans SC", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtReceipts.HandCursor = Cursors.IBeam;
            txtReceipts.Location = new Point(404, 468);
            txtReceipts.Name = "txtReceipts";
            txtReceipts.PlaceholderText = "";
            txtReceipts.Round = true;
            txtReceipts.Size = new Size(201, 36);
            txtReceipts.TabIndex = 180;
            txtReceipts.TextChanged += txtReceipts_TextChanged;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Noto Sans SC", 11.9999981F);
            label21.Location = new Point(517, 445);
            label21.Name = "label21";
            label21.Size = new Size(88, 17);
            label21.TabIndex = 166;
            label21.Text = "找        零：";
            // 
            // btnPg
            // 
            btnPg.Font = new Font("Noto Sans SC", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPg.Location = new Point(12, 365);
            btnPg.Name = "btnPg";
            btnPg.PageSize = 15;
            btnPg.ShowSizeChanger = true;
            btnPg.Size = new Size(654, 32);
            btnPg.TabIndex = 179;
            btnPg.Total = 1000000;
            btnPg.ValueChanged += btnPg_ValueChanged;
            btnPg.ShowTotalChanged += btnPg_ShowTotalChanged;
            // 
            // lblVIP
            // 
            lblVIP.AutoSize = true;
            lblVIP.Font = new Font("Noto Sans SC", 11.9999981F);
            lblVIP.Location = new Point(412, 444);
            lblVIP.Name = "lblVIP";
            lblVIP.Size = new Size(72, 17);
            lblVIP.TabIndex = 169;
            lblVIP.Text = "不  打  折";
            // 
            // dgvSpendList
            // 
            dgvSpendList.Font = new Font("Noto Sans SC", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvSpendList.Gap = 12;
            dgvSpendList.Location = new Point(12, 148);
            dgvSpendList.Name = "dgvSpendList";
            dgvSpendList.Size = new Size(654, 208);
            dgvSpendList.TabIndex = 178;
            dgvSpendList.Text = "table1";
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Font = new Font("Noto Sans SC", 14.2499981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label29.Location = new Point(591, 61);
            label29.Name = "label29";
            label29.Size = new Size(85, 19);
            label29.TabIndex = 176;
            label29.Text = "已住天数";
            // 
            // lblGetReceipts
            // 
            lblGetReceipts.AutoSize = true;
            lblGetReceipts.Font = new Font("Noto Sans SC", 11.9999981F);
            lblGetReceipts.Location = new Point(413, 412);
            lblGetReceipts.Name = "lblGetReceipts";
            lblGetReceipts.Size = new Size(38, 17);
            lblGetReceipts.TabIndex = 165;
            lblGetReceipts.Text = "0.00";
            // 
            // lblVIPPrice
            // 
            lblVIPPrice.AutoSize = true;
            lblVIPPrice.Font = new Font("Noto Sans SC", 11.9999981F);
            lblVIPPrice.Location = new Point(605, 413);
            lblVIPPrice.Name = "lblVIPPrice";
            lblVIPPrice.Size = new Size(38, 17);
            lblVIPPrice.TabIndex = 171;
            lblVIPPrice.Text = "0.00";
            // 
            // lable00
            // 
            lable00.AutoSize = true;
            lable00.Font = new Font("Noto Sans SC", 11.9999981F);
            lable00.Location = new Point(517, 413);
            lable00.Name = "lable00";
            lable00.Size = new Size(88, 17);
            lable00.TabIndex = 170;
            lable00.Text = "应付金额：";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Noto Sans SC", 11.9999981F);
            label18.Location = new Point(323, 412);
            label18.Name = "label18";
            label18.Size = new Size(88, 17);
            label18.TabIndex = 164;
            label18.Text = "消费总额：";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Noto Sans SC", 14.2499981F);
            label1.Location = new Point(18, 113);
            label1.Name = "label1";
            label1.Size = new Size(85, 19);
            label1.TabIndex = 173;
            label1.Text = "客户姓名";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Noto Sans SC Medium", 10.499999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label15.ForeColor = Color.Red;
            label15.Location = new Point(12, 567);
            label15.Name = "label15";
            label15.Size = new Size(251, 14);
            label15.TabIndex = 162;
            label15.Text = "Tips：请提醒客人不要忘记带齐行李哦~";
            // 
            // lblDay
            // 
            lblDay.AutoSize = true;
            lblDay.Font = new Font("Noto Sans SC", 14.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDay.Location = new Point(608, 112);
            lblDay.Name = "lblDay";
            lblDay.Size = new Size(45, 20);
            lblDay.TabIndex = 177;
            lblDay.Text = "Null";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Noto Sans SC", 11.9999981F);
            label17.Location = new Point(323, 479);
            label17.Name = "label17";
            label17.Size = new Size(88, 17);
            label17.TabIndex = 163;
            label17.Text = "实收金额：";
            // 
            // ucWindowHeader1
            // 
            ucWindowHeader1.Location = new Point(-1, 0);
            ucWindowHeader1.Name = "ucWindowHeader1";
            ucWindowHeader1.Size = new Size(690, 35);
            ucWindowHeader1.TabIndex = 186;
            // 
            // FrmCheckOutDetail
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(235, 243, 255);
            ClientSize = new Size(689, 590);
            Controls.Add(ucWindowHeader1);
            Controls.Add(dtpCheckTime);
            Controls.Add(label24);
            Controls.Add(txtRoomNo);
            Controls.Add(label27);
            Controls.Add(CustoName);
            Controls.Add(label28);
            Controls.Add(CustoNo);
            Controls.Add(lblChange);
            Controls.Add(btnBalance);
            Controls.Add(label25);
            Controls.Add(txtReceipts);
            Controls.Add(label21);
            Controls.Add(btnPg);
            Controls.Add(lblVIP);
            Controls.Add(dgvSpendList);
            Controls.Add(label29);
            Controls.Add(lblGetReceipts);
            Controls.Add(lblVIPPrice);
            Controls.Add(lable00);
            Controls.Add(label18);
            Controls.Add(label1);
            Controls.Add(label15);
            Controls.Add(lblDay);
            Controls.Add(label17);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmCheckOutDetail";
            Resizable = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmCheckOutDetail";
            Load += FrmCheckOutDetail_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private AntdUI.Input dtpCheckTime;
        private Label label24;
        private AntdUI.Input txtRoomNo;
        private Label label27;
        private AntdUI.Input CustoName;
        private Label label28;
        private AntdUI.Input CustoNo;
        private Label lblChange;
        private AntdUI.Button btnBalance;
        private Label label25;
        private AntdUI.Input txtReceipts;
        private Label label21;
        private AntdUI.Pagination btnPg;
        private Label lblVIP;
        private AntdUI.Table dgvSpendList;
        private Label label29;
        private Label lblGetReceipts;
        private Label lblVIPPrice;
        private Label lable00;
        private Label label18;
        private Label label1;
        private Label label15;
        private Label lblDay;
        private Label label17;
        private ucWindowHeader ucWindowHeader1;
    }
}