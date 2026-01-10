namespace EOM.TSHotelManagement.FormUI
{
    partial class FrmEditInputs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditInputs));
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            dtpDateOfBirth = new AntdUI.DatePicker();
            txtCustomerName = new AntdUI.Input();
            txtCustomerId = new AntdUI.Input();
            txtCustomerCardID = new AntdUI.Input();
            txtCustomerTel = new AntdUI.Input();
            txtCustomerAddress = new AntdUI.Input();
            ucWindowHeader1 = new ucWindowHeader();
            btnOk = new AntdUI.Button();
            cboGender = new AntdUI.Select();
            cboPassportType = new AntdUI.Select();
            cboCustomerType = new AntdUI.Select();
            SuspendLayout();
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Noto Sans SC", 14.2499981F);
            label10.Location = new Point(9, 263);
            label10.Name = "label10";
            label10.Size = new Size(85, 19);
            label10.TabIndex = 115;
            label10.Text = "居住地址";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Noto Sans SC", 14.2499981F);
            label9.Location = new Point(379, 212);
            label9.Name = "label9";
            label9.Size = new Size(85, 19);
            label9.TabIndex = 114;
            label9.Text = "联系方式";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Noto Sans SC", 14.2499981F);
            label8.Location = new Point(379, 161);
            label8.Name = "label8";
            label8.Size = new Size(85, 19);
            label8.TabIndex = 113;
            label8.Text = "证件号码";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Noto Sans SC", 14.2499981F);
            label7.Location = new Point(379, 110);
            label7.Name = "label7";
            label7.Size = new Size(85, 19);
            label7.TabIndex = 112;
            label7.Text = "证件类型";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Noto Sans SC", 14.2499981F);
            label6.Location = new Point(379, 59);
            label6.Name = "label6";
            label6.Size = new Size(85, 19);
            label6.TabIndex = 111;
            label6.Text = "客户类型";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Noto Sans SC", 14.2499981F);
            label5.Location = new Point(11, 212);
            label5.Name = "label5";
            label5.Size = new Size(85, 19);
            label5.TabIndex = 110;
            label5.Text = "出生日期";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Noto Sans SC", 14.2499981F);
            label4.Location = new Point(11, 161);
            label4.Name = "label4";
            label4.Size = new Size(82, 19);
            label4.TabIndex = 109;
            label4.Text = "性       别";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Noto Sans SC", 14.2499981F);
            label3.Location = new Point(11, 110);
            label3.Name = "label3";
            label3.Size = new Size(85, 19);
            label3.TabIndex = 108;
            label3.Text = "客户姓名";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Noto Sans SC", 14.2499981F);
            label2.Location = new Point(11, 59);
            label2.Name = "label2";
            label2.Size = new Size(85, 19);
            label2.TabIndex = 107;
            label2.Text = "客户编号";
            // 
            // dtpDateOfBirth
            // 
            dtpDateOfBirth.Font = new Font("Noto Sans SC", 10F);
            dtpDateOfBirth.Location = new Point(94, 201);
            dtpDateOfBirth.Name = "dtpDateOfBirth";
            dtpDateOfBirth.Round = true;
            dtpDateOfBirth.Size = new Size(252, 43);
            dtpDateOfBirth.TabIndex = 166;
            // 
            // txtCustomerName
            // 
            txtCustomerName.Font = new Font("Noto Sans SC", 12F);
            txtCustomerName.Location = new Point(95, 99);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.Round = true;
            txtCustomerName.Size = new Size(252, 45);
            txtCustomerName.TabIndex = 164;
            // 
            // txtCustomerId
            // 
            txtCustomerId.Font = new Font("Noto Sans SC", 12F);
            txtCustomerId.Location = new Point(95, 48);
            txtCustomerId.Name = "txtCustomerId";
            txtCustomerId.ReadOnly = true;
            txtCustomerId.Round = true;
            txtCustomerId.Size = new Size(252, 45);
            txtCustomerId.TabIndex = 163;
            // 
            // txtCustomerCardID
            // 
            txtCustomerCardID.Font = new Font("Noto Sans SC", 12F);
            txtCustomerCardID.Location = new Point(463, 148);
            txtCustomerCardID.Name = "txtCustomerCardID";
            txtCustomerCardID.Round = true;
            txtCustomerCardID.Size = new Size(250, 45);
            txtCustomerCardID.TabIndex = 168;
            txtCustomerCardID.Validated += txtCardID_Validated;
            // 
            // txtCustomerTel
            // 
            txtCustomerTel.Font = new Font("Noto Sans SC", 12F);
            txtCustomerTel.Location = new Point(463, 198);
            txtCustomerTel.Name = "txtCustomerTel";
            txtCustomerTel.Round = true;
            txtCustomerTel.Size = new Size(250, 45);
            txtCustomerTel.TabIndex = 167;
            // 
            // txtCustomerAddress
            // 
            txtCustomerAddress.Font = new Font("Noto Sans SC", 12F);
            txtCustomerAddress.Location = new Point(95, 250);
            txtCustomerAddress.Name = "txtCustomerAddress";
            txtCustomerAddress.Round = true;
            txtCustomerAddress.Size = new Size(618, 45);
            txtCustomerAddress.TabIndex = 171;
            // 
            // ucWindowHeader1
            // 
            ucWindowHeader1.Location = new Point(0, 0);
            ucWindowHeader1.Name = "ucWindowHeader1";
            ucWindowHeader1.Size = new Size(723, 35);
            ucWindowHeader1.TabIndex = 172;
            // 
            // btnOk
            // 
            btnOk.Font = new Font("Noto Sans SC", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnOk.Location = new Point(579, 307);
            btnOk.Name = "btnOk";
            btnOk.Shape = AntdUI.TShape.Round;
            btnOk.Size = new Size(135, 45);
            btnOk.TabIndex = 173;
            btnOk.Text = "保     存";
            btnOk.Type = AntdUI.TTypeMini.Info;
            btnOk.Click += FrmEditInputs_ButtonOkClick;
            // 
            // cboGender
            // 
            cboGender.Font = new Font("Noto Sans SC", 12F);
            cboGender.List = true;
            cboGender.ListAutoWidth = true;
            cboGender.Location = new Point(95, 150);
            cboGender.Name = "cboGender";
            cboGender.Placement = AntdUI.TAlignFrom.Bottom;
            cboGender.Round = true;
            cboGender.Size = new Size(251, 45);
            cboGender.TabIndex = 174;
            // 
            // cboPassportType
            // 
            cboPassportType.Font = new Font("Noto Sans SC", 12F);
            cboPassportType.List = true;
            cboPassportType.ListAutoWidth = true;
            cboPassportType.Location = new Point(463, 98);
            cboPassportType.Name = "cboPassportType";
            cboPassportType.Placement = AntdUI.TAlignFrom.Bottom;
            cboPassportType.Round = true;
            cboPassportType.Size = new Size(251, 45);
            cboPassportType.TabIndex = 175;
            // 
            // cboCustomerType
            // 
            cboCustomerType.Font = new Font("Noto Sans SC", 12F);
            cboCustomerType.List = true;
            cboCustomerType.ListAutoWidth = true;
            cboCustomerType.Location = new Point(463, 48);
            cboCustomerType.Name = "cboCustomerType";
            cboCustomerType.Placement = AntdUI.TAlignFrom.Bottom;
            cboCustomerType.Round = true;
            cboCustomerType.Size = new Size(251, 45);
            cboCustomerType.TabIndex = 176;
            // 
            // FrmEditInputs
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(235, 243, 255);
            ClientSize = new Size(722, 364);
            Controls.Add(cboCustomerType);
            Controls.Add(cboPassportType);
            Controls.Add(cboGender);
            Controls.Add(btnOk);
            Controls.Add(ucWindowHeader1);
            Controls.Add(txtCustomerAddress);
            Controls.Add(txtCustomerCardID);
            Controls.Add(txtCustomerTel);
            Controls.Add(dtpDateOfBirth);
            Controls.Add(txtCustomerName);
            Controls.Add(txtCustomerId);
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
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmEditInputs";
            Resizable = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "添加会员信息";
            Load += FrmEditInputs_Load;
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
        private AntdUI.DatePicker dtpDateOfBirth;
        private AntdUI.Input txtCustomerName;
        private AntdUI.Input txtCustomerId;
        private AntdUI.Input txtCustomerCardID;
        private AntdUI.Input txtCustomerTel;
        private AntdUI.Input txtCustomerAddress;
        private ucWindowHeader ucWindowHeader1;
        private AntdUI.Button btnOk;
        private AntdUI.Select cboGender;
        private AntdUI.Select cboPassportType;
        private AntdUI.Select cboCustomerType;
    }
}