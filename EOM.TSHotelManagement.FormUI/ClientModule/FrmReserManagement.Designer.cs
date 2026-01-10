namespace EOM.TSHotelManagement.FormUI
{
    partial class FrmReserManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReserManager));
            label1 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            btnReserList = new AntdUI.Button();
            btnReser = new AntdUI.Button();
            txtCustoName = new AntdUI.Input();
            txtCustoTel = new AntdUI.Input();
            dtpStartDate = new AntdUI.DatePicker();
            dtpEndDate = new AntdUI.DatePicker();
            whReserRoomManagement = new ucWindowHeader();
            cboReserChannel = new AntdUI.Select();
            cboReserRoom = new AntdUI.Select();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Noto Sans SC", 14.25F);
            label1.Location = new Point(283, 62);
            label1.Name = "label1";
            label1.Size = new Size(85, 19);
            label1.TabIndex = 106;
            label1.Text = "电话号码";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Noto Sans SC", 14.25F);
            label9.Location = new Point(24, 62);
            label9.Name = "label9";
            label9.Size = new Size(85, 19);
            label9.TabIndex = 105;
            label9.Text = "客户姓名";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Noto Sans SC", 14.25F);
            label10.Location = new Point(24, 110);
            label10.Name = "label10";
            label10.Size = new Size(85, 19);
            label10.TabIndex = 109;
            label10.Text = "预约渠道";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Noto Sans SC", 14.25F);
            label11.Location = new Point(284, 110);
            label11.Name = "label11";
            label11.Size = new Size(85, 19);
            label11.TabIndex = 111;
            label11.Text = "预约房号";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Noto Sans SC", 14.25F);
            label12.Location = new Point(24, 158);
            label12.Name = "label12";
            label12.Size = new Size(85, 19);
            label12.TabIndex = 113;
            label12.Text = "预约起始";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Noto Sans SC", 14.25F);
            label13.Location = new Point(284, 158);
            label13.Name = "label13";
            label13.Size = new Size(85, 19);
            label13.TabIndex = 115;
            label13.Text = "预约止日";
            // 
            // btnReserList
            // 
            btnReserList.Font = new Font("Noto Sans SC", 12F);
            btnReserList.Location = new Point(316, 195);
            btnReserList.Name = "btnReserList";
            btnReserList.Shape = AntdUI.TShape.Round;
            btnReserList.Size = new Size(139, 43);
            btnReserList.TabIndex = 118;
            btnReserList.Text = "查看预约列表";
            btnReserList.Click += btnReserList_Click;
            // 
            // btnReser
            // 
            btnReser.Font = new Font("Noto Sans SC", 12F);
            btnReser.Location = new Point(461, 195);
            btnReser.Name = "btnReser";
            btnReser.Shape = AntdUI.TShape.Round;
            btnReser.Size = new Size(87, 43);
            btnReser.TabIndex = 119;
            btnReser.Text = "预   约";
            btnReser.Type = AntdUI.TTypeMini.Info;
            btnReser.Click += btnReser_Click;
            // 
            // txtCustoName
            // 
            txtCustoName.Font = new Font("Noto Sans SC", 12F);
            txtCustoName.Location = new Point(115, 49);
            txtCustoName.Name = "txtCustoName";
            txtCustoName.Round = true;
            txtCustoName.Size = new Size(162, 40);
            txtCustoName.TabIndex = 121;
            // 
            // txtCustoTel
            // 
            txtCustoTel.Font = new Font("Noto Sans SC", 12F);
            txtCustoTel.Location = new Point(376, 49);
            txtCustoTel.Name = "txtCustoTel";
            txtCustoTel.Round = true;
            txtCustoTel.Size = new Size(162, 40);
            txtCustoTel.TabIndex = 122;
            // 
            // dtpStartDate
            // 
            dtpStartDate.Font = new Font("Noto Sans SC", 10F);
            dtpStartDate.Location = new Point(115, 145);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Round = true;
            dtpStartDate.Size = new Size(162, 40);
            dtpStartDate.TabIndex = 125;
            // 
            // dtpEndDate
            // 
            dtpEndDate.Font = new Font("Noto Sans SC", 10F);
            dtpEndDate.Location = new Point(376, 145);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Round = true;
            dtpEndDate.Size = new Size(162, 40);
            dtpEndDate.TabIndex = 126;
            // 
            // whReserRoomManagement
            // 
            whReserRoomManagement.Location = new Point(0, 0);
            whReserRoomManagement.Name = "whReserRoomManagement";
            whReserRoomManagement.Size = new Size(562, 34);
            whReserRoomManagement.TabIndex = 141;
            // 
            // cboReserChannel
            // 
            cboReserChannel.Font = new Font("Noto Sans SC", 12F);
            cboReserChannel.List = true;
            cboReserChannel.ListAutoWidth = true;
            cboReserChannel.Location = new Point(115, 97);
            cboReserChannel.Name = "cboReserChannel";
            cboReserChannel.Placement = AntdUI.TAlignFrom.Bottom;
            cboReserChannel.Round = true;
            cboReserChannel.Size = new Size(162, 40);
            cboReserChannel.TabIndex = 175;
            // 
            // cboReserRoom
            // 
            cboReserRoom.Font = new Font("Noto Sans SC", 12F);
            cboReserRoom.List = true;
            cboReserRoom.ListAutoWidth = true;
            cboReserRoom.Location = new Point(376, 97);
            cboReserRoom.Name = "cboReserRoom";
            cboReserRoom.Placement = AntdUI.TAlignFrom.Bottom;
            cboReserRoom.Round = true;
            cboReserRoom.Size = new Size(161, 40);
            cboReserRoom.TabIndex = 176;
            // 
            // FrmReserManager
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(235, 243, 255);
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(560, 251);
            Controls.Add(cboReserRoom);
            Controls.Add(cboReserChannel);
            Controls.Add(whReserRoomManagement);
            Controls.Add(dtpEndDate);
            Controls.Add(dtpStartDate);
            Controls.Add(txtCustoTel);
            Controls.Add(txtCustoName);
            Controls.Add(btnReser);
            Controls.Add(btnReserList);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label1);
            Controls.Add(label9);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmReserManager";
            Resizable = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "预约管理";
            Load += FrmRoomManager_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private AntdUI.Button btnReserList;
        private AntdUI.Button btnReser;
        private AntdUI.Input txtCustoName;
        private AntdUI.Input txtCustoTel;
        private AntdUI.DatePicker dtpStartDate;
        private AntdUI.DatePicker dtpEndDate;
        private ucWindowHeader whReserRoomManagement;
        private AntdUI.Select cboReserChannel;
        private AntdUI.Select cboReserRoom;
    }
}