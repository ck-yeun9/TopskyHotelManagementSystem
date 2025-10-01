namespace EOM.TSHotelManagement.FormUI
{
    partial class FrmPersonnelInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPersonnelInfo));
            label7 = new Label();
            label5 = new Label();
            label32 = new Label();
            label31 = new Label();
            label30 = new Label();
            label1 = new Label();
            label2 = new Label();
            label16 = new Label();
            txtEmployeeId = new AntdUI.Input();
            txtEmployeeName = new AntdUI.Input();
            txtEmployeeAddress = new AntdUI.Input();
            txtEmployeeTel = new AntdUI.Input();
            btnUpdate = new AntdUI.Button();
            cboGender = new AntdUI.Select();
            cboEmployeeNation = new AntdUI.Select();
            cboEmployeePosition = new AntdUI.Select();
            cboEmployeeDepartment = new AntdUI.Select();
            ucWindowHeader1 = new ucWindowHeader();
            SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Noto Sans SC", 14.2499981F);
            label7.Location = new Point(18, 214);
            label7.Name = "label7";
            label7.Size = new Size(85, 19);
            label7.TabIndex = 148;
            label7.Text = "联系方式";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Noto Sans SC", 14.2499981F);
            label5.Location = new Point(329, 112);
            label5.Name = "label5";
            label5.Size = new Size(85, 19);
            label5.TabIndex = 136;
            label5.Text = "现任职位";
            // 
            // label32
            // 
            label32.AutoSize = true;
            label32.Font = new Font("Noto Sans SC", 14.2499981F);
            label32.Location = new Point(18, 61);
            label32.Name = "label32";
            label32.Size = new Size(85, 19);
            label32.TabIndex = 132;
            label32.Text = "员工编号";
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Font = new Font("Noto Sans SC", 14.2499981F);
            label31.Location = new Point(18, 112);
            label31.Name = "label31";
            label31.Size = new Size(85, 19);
            label31.TabIndex = 133;
            label31.Text = "员工姓名";
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Font = new Font("Noto Sans SC", 14.2499981F);
            label30.Location = new Point(18, 162);
            label30.Name = "label30";
            label30.Size = new Size(77, 19);
            label30.TabIndex = 134;
            label30.Text = "性      别";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Noto Sans SC", 14.2499981F);
            label1.Location = new Point(329, 162);
            label1.Name = "label1";
            label1.Size = new Size(77, 19);
            label1.TabIndex = 145;
            label1.Text = "民      族";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Noto Sans SC", 14.2499981F);
            label2.Location = new Point(18, 264);
            label2.Name = "label2";
            label2.Size = new Size(85, 19);
            label2.TabIndex = 137;
            label2.Text = "居住地址";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Noto Sans SC", 14.2499981F);
            label16.Location = new Point(329, 61);
            label16.Name = "label16";
            label16.Size = new Size(85, 19);
            label16.TabIndex = 135;
            label16.Text = "所在部门";
            // 
            // txtEmployeeId
            // 
            txtEmployeeId.Font = new Font("Noto Sans SC", 12F);
            txtEmployeeId.Location = new Point(103, 51);
            txtEmployeeId.Name = "txtEmployeeId";
            txtEmployeeId.ReadOnly = true;
            txtEmployeeId.Round = true;
            txtEmployeeId.Size = new Size(205, 45);
            txtEmployeeId.TabIndex = 149;
            // 
            // txtEmployeeName
            // 
            txtEmployeeName.Font = new Font("Noto Sans SC", 12F);
            txtEmployeeName.Location = new Point(103, 102);
            txtEmployeeName.Name = "txtEmployeeName";
            txtEmployeeName.Round = true;
            txtEmployeeName.Size = new Size(205, 45);
            txtEmployeeName.TabIndex = 150;
            // 
            // txtEmployeeAddress
            // 
            txtEmployeeAddress.Font = new Font("Noto Sans SC", 12F);
            txtEmployeeAddress.Location = new Point(103, 251);
            txtEmployeeAddress.Name = "txtEmployeeAddress";
            txtEmployeeAddress.Round = true;
            txtEmployeeAddress.Size = new Size(515, 45);
            txtEmployeeAddress.TabIndex = 151;
            // 
            // txtEmployeeTel
            // 
            txtEmployeeTel.Font = new Font("Noto Sans SC", 12F);
            txtEmployeeTel.Location = new Point(104, 202);
            txtEmployeeTel.Name = "txtEmployeeTel";
            txtEmployeeTel.Round = true;
            txtEmployeeTel.Size = new Size(515, 45);
            txtEmployeeTel.TabIndex = 152;
            // 
            // btnUpdate
            // 
            btnUpdate.Font = new Font("Noto Sans SC", 12F);
            btnUpdate.Location = new Point(530, 302);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Shape = AntdUI.TShape.Round;
            btnUpdate.Size = new Size(87, 43);
            btnUpdate.TabIndex = 157;
            btnUpdate.Text = "修   改";
            btnUpdate.Type = AntdUI.TTypeMini.Info;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // cboGender
            // 
            cboGender.Font = new Font("Noto Sans SC", 12F);
            cboGender.List = true;
            cboGender.ListAutoWidth = true;
            cboGender.Location = new Point(103, 152);
            cboGender.Name = "cboGender";
            cboGender.Placement = AntdUI.TAlignFrom.Bottom;
            cboGender.Round = true;
            cboGender.Size = new Size(205, 45);
            cboGender.TabIndex = 175;
            // 
            // cboEmployeeNation
            // 
            cboEmployeeNation.Font = new Font("Noto Sans SC", 12F);
            cboEmployeeNation.List = true;
            cboEmployeeNation.ListAutoWidth = true;
            cboEmployeeNation.Location = new Point(413, 152);
            cboEmployeeNation.Name = "cboEmployeeNation";
            cboEmployeeNation.Placement = AntdUI.TAlignFrom.Bottom;
            cboEmployeeNation.Round = true;
            cboEmployeeNation.Size = new Size(204, 45);
            cboEmployeeNation.TabIndex = 176;
            // 
            // cboEmployeePosition
            // 
            cboEmployeePosition.Font = new Font("Noto Sans SC", 12F);
            cboEmployeePosition.List = true;
            cboEmployeePosition.ListAutoWidth = true;
            cboEmployeePosition.Location = new Point(413, 102);
            cboEmployeePosition.Name = "cboEmployeePosition";
            cboEmployeePosition.Placement = AntdUI.TAlignFrom.Bottom;
            cboEmployeePosition.Round = true;
            cboEmployeePosition.Size = new Size(205, 45);
            cboEmployeePosition.TabIndex = 177;
            // 
            // cboEmployeeDepartment
            // 
            cboEmployeeDepartment.Font = new Font("Noto Sans SC", 12F);
            cboEmployeeDepartment.List = true;
            cboEmployeeDepartment.ListAutoWidth = true;
            cboEmployeeDepartment.Location = new Point(413, 51);
            cboEmployeeDepartment.Name = "cboEmployeeDepartment";
            cboEmployeeDepartment.Placement = AntdUI.TAlignFrom.Bottom;
            cboEmployeeDepartment.Round = true;
            cboEmployeeDepartment.Size = new Size(205, 45);
            cboEmployeeDepartment.TabIndex = 178;
            // 
            // ucWindowHeader1
            // 
            ucWindowHeader1.Location = new Point(-1, -1);
            ucWindowHeader1.Name = "ucWindowHeader1";
            ucWindowHeader1.Size = new Size(639, 35);
            ucWindowHeader1.TabIndex = 179;
            // 
            // FrmPersonnelInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(235, 243, 255);
            ClientSize = new Size(637, 359);
            Controls.Add(ucWindowHeader1);
            Controls.Add(cboEmployeeDepartment);
            Controls.Add(cboEmployeePosition);
            Controls.Add(cboEmployeeNation);
            Controls.Add(cboGender);
            Controls.Add(btnUpdate);
            Controls.Add(txtEmployeeTel);
            Controls.Add(txtEmployeeAddress);
            Controls.Add(txtEmployeeName);
            Controls.Add(txtEmployeeId);
            Controls.Add(label7);
            Controls.Add(label5);
            Controls.Add(label32);
            Controls.Add(label31);
            Controls.Add(label30);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(label16);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmPersonnelInfo";
            Resizable = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmPersonnelInfo";
            Load += FrmPersonnelInfo_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label7;
        private Label label5;
        private Label label32;
        private Label label31;
        private Label label30;
        private Label label1;
        private Label label2;
        private Label label16;
        private AntdUI.Input txtEmployeeId;
        private AntdUI.Input txtEmployeeName;
        private AntdUI.Input txtEmployeeAddress;
        private AntdUI.Input txtEmployeeTel;
        private AntdUI.Button btnUpdate;
        private AntdUI.Select cboGender;
        private AntdUI.Select cboEmployeeNation;
        private AntdUI.Select cboEmployeePosition;
        private AntdUI.Select cboEmployeeDepartment;
        private ucWindowHeader ucWindowHeader1;
    }
}