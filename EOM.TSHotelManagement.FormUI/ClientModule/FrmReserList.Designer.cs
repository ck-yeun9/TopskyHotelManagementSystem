namespace EOM.TSHotelManagement.FormUI
{
    partial class FrmReserList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReserList));
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            dgvReserList = new AntdUI.Table();
            btnPg = new AntdUI.Pagination();
            ucWindowHeader1 = new ucWindowHeader();
            btnOk = new AntdUI.Button();
            txtCustomerName = new AntdUI.Input();
            txtCustomerId = new AntdUI.Input();
            txtCustomerAddress = new AntdUI.Input();
            txtCustomerTel = new AntdUI.Input();
            txtCustomerCardID = new AntdUI.Input();
            dtpDateOfBirth = new AntdUI.DatePicker();
            cboCustomerType = new AntdUI.Select();
            cboPassportType = new AntdUI.Select();
            cboGender = new AntdUI.Select();
            SuspendLayout();
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Noto Sans SC", 14.2499981F);
            label10.Location = new Point(30, 508);
            label10.Name = "label10";
            label10.Size = new Size(85, 19);
            label10.TabIndex = 122;
            label10.Text = "居住地址";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Noto Sans SC", 14.2499981F);
            label9.Location = new Point(408, 457);
            label9.Name = "label9";
            label9.Size = new Size(85, 19);
            label9.TabIndex = 121;
            label9.Text = "联系方式";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Noto Sans SC", 14.2499981F);
            label8.Location = new Point(408, 404);
            label8.Name = "label8";
            label8.Size = new Size(85, 19);
            label8.TabIndex = 120;
            label8.Text = "证件号码";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Noto Sans SC", 14.2499981F);
            label7.Location = new Point(408, 354);
            label7.Name = "label7";
            label7.Size = new Size(85, 19);
            label7.TabIndex = 119;
            label7.Text = "证件类型";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Noto Sans SC", 14.2499981F);
            label6.Location = new Point(408, 304);
            label6.Name = "label6";
            label6.Size = new Size(85, 19);
            label6.TabIndex = 118;
            label6.Text = "客户类型";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Noto Sans SC", 14.2499981F);
            label5.Location = new Point(28, 457);
            label5.Name = "label5";
            label5.Size = new Size(85, 19);
            label5.TabIndex = 117;
            label5.Text = "出生日期";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Noto Sans SC", 14.2499981F);
            label4.Location = new Point(38, 406);
            label4.Name = "label4";
            label4.Size = new Size(77, 19);
            label4.TabIndex = 116;
            label4.Text = "性      别";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Noto Sans SC", 14.2499981F);
            label3.Location = new Point(30, 355);
            label3.Name = "label3";
            label3.Size = new Size(85, 19);
            label3.TabIndex = 115;
            label3.Text = "客户姓名";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Noto Sans SC", 14.2499981F);
            label2.Location = new Point(30, 304);
            label2.Name = "label2";
            label2.Size = new Size(85, 19);
            label2.TabIndex = 114;
            label2.Text = "客户编号";
            // 
            // dgvReserList
            // 
            dgvReserList.Font = new Font("Noto Sans SC", 9F);
            dgvReserList.Gap = 12;
            dgvReserList.Location = new Point(14, 87);
            dgvReserList.Name = "dgvReserList";
            dgvReserList.Size = new Size(735, 156);
            dgvReserList.TabIndex = 136;
            dgvReserList.Text = "table1";
            dgvReserList.CellClick += dgvReserList_CellClick;
            // 
            // btnPg
            // 
            btnPg.Font = new Font("Noto Sans SC", 9F);
            btnPg.Location = new Point(14, 253);
            btnPg.Name = "btnPg";
            btnPg.PageSize = 15;
            btnPg.ShowSizeChanger = true;
            btnPg.Size = new Size(735, 31);
            btnPg.TabIndex = 137;
            btnPg.Total = 1000000;
            btnPg.ValueChanged += btnPg_ValueChanged;
            btnPg.ShowTotalChanged += btnPg_ShowTotalChanged;
            // 
            // ucWindowHeader1
            // 
            ucWindowHeader1.Location = new Point(1, 1);
            ucWindowHeader1.Name = "ucWindowHeader1";
            ucWindowHeader1.Size = new Size(761, 35);
            ucWindowHeader1.TabIndex = 138;
            // 
            // btnOk
            // 
            btnOk.Font = new Font("Noto Sans SC", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnOk.Location = new Point(14, 36);
            btnOk.Name = "btnOk";
            btnOk.Shape = AntdUI.TShape.Round;
            btnOk.Size = new Size(135, 45);
            btnOk.TabIndex = 139;
            btnOk.Text = "入住并注册";
            btnOk.Type = AntdUI.TTypeMini.Info;
            btnOk.Click += btnSelect_Click;
            // 
            // txtCustomerName
            // 
            txtCustomerName.Font = new Font("Noto Sans SC", 12F);
            txtCustomerName.Location = new Point(121, 343);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.Round = true;
            txtCustomerName.Size = new Size(252, 45);
            txtCustomerName.TabIndex = 155;
            // 
            // txtCustomerId
            // 
            txtCustomerId.Font = new Font("Noto Sans SC", 12F);
            txtCustomerId.Location = new Point(121, 290);
            txtCustomerId.Name = "txtCustomerId";
            txtCustomerId.ReadOnly = true;
            txtCustomerId.Round = true;
            txtCustomerId.Size = new Size(252, 45);
            txtCustomerId.TabIndex = 154;
            // 
            // txtCustomerAddress
            // 
            txtCustomerAddress.Font = new Font("Noto Sans SC", 12F);
            txtCustomerAddress.Location = new Point(121, 496);
            txtCustomerAddress.Name = "txtCustomerAddress";
            txtCustomerAddress.Round = true;
            txtCustomerAddress.Size = new Size(628, 45);
            txtCustomerAddress.TabIndex = 157;
            // 
            // txtCustomerTel
            // 
            txtCustomerTel.Font = new Font("Noto Sans SC", 12F);
            txtCustomerTel.Location = new Point(501, 444);
            txtCustomerTel.Name = "txtCustomerTel";
            txtCustomerTel.Round = true;
            txtCustomerTel.Size = new Size(250, 43);
            txtCustomerTel.TabIndex = 158;
            // 
            // txtCustomerCardID
            // 
            txtCustomerCardID.Font = new Font("Noto Sans SC", 12F);
            txtCustomerCardID.Location = new Point(501, 394);
            txtCustomerCardID.Name = "txtCustomerCardID";
            txtCustomerCardID.Round = true;
            txtCustomerCardID.Size = new Size(250, 45);
            txtCustomerCardID.TabIndex = 159;
            txtCustomerCardID.Validated += txtCardID_Validated;
            // 
            // dtpDateOfBirth
            // 
            dtpDateOfBirth.Font = new Font("Noto Sans SC", 10F);
            dtpDateOfBirth.Location = new Point(120, 444);
            dtpDateOfBirth.Name = "dtpDateOfBirth";
            dtpDateOfBirth.Round = true;
            dtpDateOfBirth.Size = new Size(252, 43);
            dtpDateOfBirth.TabIndex = 162;
            // 
            // cboCustomerType
            // 
            cboCustomerType.Font = new Font("Noto Sans SC", 12F);
            cboCustomerType.List = true;
            cboCustomerType.ListAutoWidth = true;
            cboCustomerType.Location = new Point(501, 293);
            cboCustomerType.Name = "cboCustomerType";
            cboCustomerType.Placement = AntdUI.TAlignFrom.Bottom;
            cboCustomerType.Round = true;
            cboCustomerType.Size = new Size(251, 45);
            cboCustomerType.TabIndex = 178;
            // 
            // cboPassportType
            // 
            cboPassportType.Font = new Font("Noto Sans SC", 12F);
            cboPassportType.List = true;
            cboPassportType.ListAutoWidth = true;
            cboPassportType.Location = new Point(501, 343);
            cboPassportType.Name = "cboPassportType";
            cboPassportType.Placement = AntdUI.TAlignFrom.Bottom;
            cboPassportType.Round = true;
            cboPassportType.Size = new Size(251, 45);
            cboPassportType.TabIndex = 177;
            // 
            // cboGender
            // 
            cboGender.Font = new Font("Noto Sans SC", 12F);
            cboGender.List = true;
            cboGender.ListAutoWidth = true;
            cboGender.Location = new Point(122, 394);
            cboGender.Name = "cboGender";
            cboGender.Placement = AntdUI.TAlignFrom.Bottom;
            cboGender.Round = true;
            cboGender.Size = new Size(251, 45);
            cboGender.TabIndex = 179;
            // 
            // FrmReserList
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(235, 243, 255);
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(763, 556);
            Controls.Add(cboGender);
            Controls.Add(cboCustomerType);
            Controls.Add(cboPassportType);
            Controls.Add(dtpDateOfBirth);
            Controls.Add(txtCustomerCardID);
            Controls.Add(txtCustomerTel);
            Controls.Add(txtCustomerAddress);
            Controls.Add(txtCustomerName);
            Controls.Add(txtCustomerId);
            Controls.Add(btnOk);
            Controls.Add(ucWindowHeader1);
            Controls.Add(btnPg);
            Controls.Add(dgvReserList);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmReserList";
            Resizable = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "预约列表";
            Load += FrmReserList_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private AntdUI.Table dgvReserList;
        private AntdUI.Pagination btnPg;
        private ucWindowHeader ucWindowHeader1;
        private AntdUI.Button btnOk;
        private AntdUI.Input txtCustomerName;
        private AntdUI.Input txtCustomerId;
        private AntdUI.Input txtCustomerAddress;
        private AntdUI.Input txtCustomerTel;
        private AntdUI.Input txtCustomerCardID;
        private AntdUI.DatePicker dtpDateOfBirth;
        private AntdUI.Select cboCustomerType;
        private AntdUI.Select cboPassportType;
        private AntdUI.Select cboGender;
    }
}