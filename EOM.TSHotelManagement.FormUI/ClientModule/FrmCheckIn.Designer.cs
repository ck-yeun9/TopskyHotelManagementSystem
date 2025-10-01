namespace EOM.TSHotelManagement.FormUI
{
    partial class FrmCheckIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCheckIn));
            label3 = new Label();
            label13 = new Label();
            label15 = new Label();
            label19 = new Label();
            label20 = new Label();
            label18 = new Label();
            label16 = new Label();
            label14 = new Label();
            label12 = new Label();
            label1 = new Label();
            ucWindowHeader1 = new ucWindowHeader();
            btnCheckIn = new AntdUI.Button();
            btnCancel = new AntdUI.Button();
            txtRoomNo = new AntdUI.Input();
            txtState = new AntdUI.Input();
            txtRoomPosition = new AntdUI.Input();
            txtRent = new AntdUI.Input();
            txtDeposit = new AntdUI.Input();
            txtCustomerName = new AntdUI.Input();
            txtCustomerLevel = new AntdUI.Input();
            txtCustomerTel = new AntdUI.Input();
            txtCustomerNo = new AntdUI.Input();
            txtRoomType = new AntdUI.Input();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Noto Sans SC", 14.2499981F);
            label3.Location = new Point(8, 169);
            label3.Name = "label3";
            label3.Size = new Size(85, 19);
            label3.TabIndex = 149;
            label3.Text = "房间位置";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Noto Sans SC", 14.2499981F);
            label13.Location = new Point(387, 117);
            label13.Name = "label13";
            label13.Size = new Size(85, 19);
            label13.TabIndex = 144;
            label13.Text = "房间单价";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Noto Sans SC", 14.2499981F);
            label15.Location = new Point(387, 64);
            label15.Name = "label15";
            label15.Size = new Size(85, 19);
            label15.TabIndex = 143;
            label15.Text = "房间类型";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Noto Sans SC", 14.2499981F);
            label19.Location = new Point(9, 117);
            label19.Name = "label19";
            label19.Size = new Size(85, 19);
            label19.TabIndex = 142;
            label19.Text = "房间状态";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Noto Sans SC", 14.2499981F);
            label20.Location = new Point(9, 64);
            label20.Name = "label20";
            label20.Size = new Size(85, 19);
            label20.TabIndex = 141;
            label20.Text = "房间编号";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.BackColor = Color.Transparent;
            label18.Font = new Font("Noto Sans SC", 14.2499981F);
            label18.Location = new Point(8, 222);
            label18.Name = "label18";
            label18.Size = new Size(85, 19);
            label18.TabIndex = 137;
            label18.Text = "客户编号";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.BackColor = Color.Transparent;
            label16.Font = new Font("Noto Sans SC", 14.2499981F);
            label16.Location = new Point(8, 275);
            label16.Name = "label16";
            label16.Size = new Size(85, 19);
            label16.TabIndex = 138;
            label16.Text = "客户电话";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = Color.Transparent;
            label14.Font = new Font("Noto Sans SC", 14.2499981F);
            label14.Location = new Point(387, 222);
            label14.Name = "label14";
            label14.Size = new Size(85, 19);
            label14.TabIndex = 139;
            label14.Text = "客户姓名";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.Transparent;
            label12.Font = new Font("Noto Sans SC", 14.2499981F);
            label12.Location = new Point(387, 275);
            label12.Name = "label12";
            label12.Size = new Size(85, 19);
            label12.TabIndex = 140;
            label12.Text = "会员等级";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Noto Sans SC", 14.2499981F);
            label1.Location = new Point(387, 169);
            label1.Name = "label1";
            label1.Size = new Size(85, 19);
            label1.TabIndex = 151;
            label1.Text = "房间押金";
            // 
            // ucWindowHeader1
            // 
            ucWindowHeader1.Location = new Point(0, -1);
            ucWindowHeader1.Name = "ucWindowHeader1";
            ucWindowHeader1.Size = new Size(732, 35);
            ucWindowHeader1.TabIndex = 153;
            // 
            // btnCheckIn
            // 
            btnCheckIn.Font = new Font("Noto Sans SC", 12F);
            btnCheckIn.Location = new Point(548, 322);
            btnCheckIn.Name = "btnCheckIn";
            btnCheckIn.Shape = AntdUI.TShape.Round;
            btnCheckIn.Size = new Size(85, 45);
            btnCheckIn.TabIndex = 164;
            btnCheckIn.Text = "入    住";
            btnCheckIn.Type = AntdUI.TTypeMini.Primary;
            btnCheckIn.Click += FrmCheckIn_ButtonOkClick;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Noto Sans SC", 12F);
            btnCancel.Location = new Point(639, 322);
            btnCancel.Name = "btnCancel";
            btnCancel.Shape = AntdUI.TShape.Round;
            btnCancel.Size = new Size(85, 45);
            btnCancel.TabIndex = 165;
            btnCancel.Text = "取    消";
            btnCancel.Type = AntdUI.TTypeMini.Primary;
            btnCancel.Click += btnCancel_Click;
            // 
            // txtRoomNo
            // 
            txtRoomNo.Font = new Font("Noto Sans SC", 12F);
            txtRoomNo.Location = new Point(93, 51);
            txtRoomNo.Name = "txtRoomNo";
            txtRoomNo.ReadOnly = true;
            txtRoomNo.Round = true;
            txtRoomNo.Size = new Size(250, 45);
            txtRoomNo.TabIndex = 166;
            // 
            // txtState
            // 
            txtState.Font = new Font("Noto Sans SC", 12F);
            txtState.Location = new Point(93, 104);
            txtState.Name = "txtState";
            txtState.ReadOnly = true;
            txtState.Round = true;
            txtState.Size = new Size(250, 45);
            txtState.TabIndex = 167;
            // 
            // txtRoomPosition
            // 
            txtRoomPosition.Font = new Font("Noto Sans SC", 12F);
            txtRoomPosition.Location = new Point(93, 157);
            txtRoomPosition.Name = "txtRoomPosition";
            txtRoomPosition.ReadOnly = true;
            txtRoomPosition.Round = true;
            txtRoomPosition.Size = new Size(250, 45);
            txtRoomPosition.TabIndex = 168;
            // 
            // txtRent
            // 
            txtRent.Font = new Font("Noto Sans SC", 12F);
            txtRent.Location = new Point(474, 104);
            txtRent.Name = "txtRent";
            txtRent.ReadOnly = true;
            txtRent.Round = true;
            txtRent.Size = new Size(250, 45);
            txtRent.TabIndex = 169;
            // 
            // txtDeposit
            // 
            txtDeposit.Font = new Font("Noto Sans SC", 12F);
            txtDeposit.Location = new Point(474, 157);
            txtDeposit.Name = "txtDeposit";
            txtDeposit.ReadOnly = true;
            txtDeposit.Round = true;
            txtDeposit.Size = new Size(250, 45);
            txtDeposit.TabIndex = 170;
            // 
            // txtCustomerName
            // 
            txtCustomerName.Font = new Font("Noto Sans SC", 12F);
            txtCustomerName.Location = new Point(474, 210);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.ReadOnly = true;
            txtCustomerName.Round = true;
            txtCustomerName.Size = new Size(250, 45);
            txtCustomerName.TabIndex = 171;
            // 
            // txtCustomerLevel
            // 
            txtCustomerLevel.Font = new Font("Noto Sans SC", 12F);
            txtCustomerLevel.Location = new Point(474, 263);
            txtCustomerLevel.Name = "txtCustomerLevel";
            txtCustomerLevel.ReadOnly = true;
            txtCustomerLevel.Round = true;
            txtCustomerLevel.Size = new Size(250, 45);
            txtCustomerLevel.TabIndex = 172;
            // 
            // txtCustomerTel
            // 
            txtCustomerTel.Font = new Font("Noto Sans SC", 12F);
            txtCustomerTel.Location = new Point(93, 263);
            txtCustomerTel.Name = "txtCustomerTel";
            txtCustomerTel.ReadOnly = true;
            txtCustomerTel.Round = true;
            txtCustomerTel.Size = new Size(250, 45);
            txtCustomerTel.TabIndex = 173;
            // 
            // txtCustomerNo
            // 
            txtCustomerNo.Font = new Font("Noto Sans SC", 12F);
            txtCustomerNo.Location = new Point(93, 210);
            txtCustomerNo.Name = "txtCustomerNo";
            txtCustomerNo.Round = true;
            txtCustomerNo.Size = new Size(250, 45);
            txtCustomerNo.TabIndex = 174;
            txtCustomerNo.Validated += txtCustoNo_Validated;
            // 
            // txtRoomType
            // 
            txtRoomType.Font = new Font("Noto Sans SC", 12F);
            txtRoomType.Location = new Point(474, 51);
            txtRoomType.Name = "txtRoomType";
            txtRoomType.ReadOnly = true;
            txtRoomType.Round = true;
            txtRoomType.Size = new Size(250, 45);
            txtRoomType.TabIndex = 175;
            // 
            // FrmCheckIn
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(235, 243, 255);
            ClientSize = new Size(731, 379);
            ControlBox = false;
            Controls.Add(txtRoomType);
            Controls.Add(txtCustomerNo);
            Controls.Add(txtCustomerTel);
            Controls.Add(txtCustomerLevel);
            Controls.Add(txtCustomerName);
            Controls.Add(txtDeposit);
            Controls.Add(txtRent);
            Controls.Add(txtRoomPosition);
            Controls.Add(txtState);
            Controls.Add(txtRoomNo);
            Controls.Add(btnCancel);
            Controls.Add(btnCheckIn);
            Controls.Add(ucWindowHeader1);
            Controls.Add(label1);
            Controls.Add(label18);
            Controls.Add(label3);
            Controls.Add(label16);
            Controls.Add(label14);
            Controls.Add(label12);
            Controls.Add(label13);
            Controls.Add(label15);
            Controls.Add(label19);
            Controls.Add(label20);
            Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            Name = "FrmCheckIn";
            Resizable = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "房间入住";
            Load += FrmCheckIn_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label1;
        private ucWindowHeader ucWindowHeader1;
        private AntdUI.Button btnCheckIn;
        private AntdUI.Button btnCancel;
        private AntdUI.Input txtRoomNo;
        private AntdUI.Input txtState;
        private AntdUI.Input txtRoomPosition;
        private AntdUI.Input txtRent;
        private AntdUI.Input txtDeposit;
        private AntdUI.Input txtCustomerName;
        private AntdUI.Input txtCustomerLevel;
        private AntdUI.Input txtCustomerTel;
        private AntdUI.Input txtCustomerNo;
        private AntdUI.Input txtRoomType;
    }
}