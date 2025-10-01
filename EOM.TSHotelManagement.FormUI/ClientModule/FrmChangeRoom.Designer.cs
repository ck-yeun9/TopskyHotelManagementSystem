namespace EOM.TSHotelManagement.FormUI
{
    partial class FrmChangeRoom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChangeRoom));
            ucWindowHeader1 = new ucWindowHeader();
            label24 = new Label();
            label1 = new Label();
            lblRoomType = new AntdUI.Label();
            btnChangeRoom = new AntdUI.Button();
            cboRoomList = new AntdUI.Select();
            SuspendLayout();
            // 
            // ucWindowHeader1
            // 
            ucWindowHeader1.Location = new Point(0, -1);
            ucWindowHeader1.Name = "ucWindowHeader1";
            ucWindowHeader1.Size = new Size(249, 35);
            ucWindowHeader1.TabIndex = 11;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new Font("Noto Sans SC", 14F);
            label24.Location = new Point(5, 58);
            label24.Name = "label24";
            label24.Size = new Size(85, 19);
            label24.TabIndex = 159;
            label24.Text = "新房间：";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Noto Sans SC", 14F);
            label1.Location = new Point(5, 108);
            label1.Name = "label1";
            label1.Size = new Size(81, 19);
            label1.TabIndex = 161;
            label1.Text = "类   型：";
            // 
            // lblRoomType
            // 
            lblRoomType.Font = new Font("Noto Sans SC", 12F);
            lblRoomType.Location = new Point(91, 99);
            lblRoomType.Name = "lblRoomType";
            lblRoomType.Size = new Size(149, 36);
            lblRoomType.TabIndex = 162;
            lblRoomType.Text = "";
            lblRoomType.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnChangeRoom
            // 
            btnChangeRoom.Font = new Font("Noto Sans SC", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnChangeRoom.Location = new Point(155, 156);
            btnChangeRoom.Name = "btnChangeRoom";
            btnChangeRoom.Shape = AntdUI.TShape.Round;
            btnChangeRoom.Size = new Size(85, 45);
            btnChangeRoom.TabIndex = 163;
            btnChangeRoom.Text = "转    房";
            btnChangeRoom.Type = AntdUI.TTypeMini.Primary;
            btnChangeRoom.Click += btnChangeRoom_Click;
            // 
            // cboRoomList
            // 
            cboRoomList.Font = new Font("Noto Sans SC", 12F);
            cboRoomList.List = true;
            cboRoomList.ListAutoWidth = true;
            cboRoomList.Location = new Point(91, 46);
            cboRoomList.Name = "cboRoomList";
            cboRoomList.Placement = AntdUI.TAlignFrom.Bottom;
            cboRoomList.Round = true;
            cboRoomList.Size = new Size(149, 45);
            cboRoomList.TabIndex = 179;
            cboRoomList.TextChanged += cboRoomList_TextChanged;
            // 
            // FrmChangeRoom
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(235, 243, 255);
            ClientSize = new Size(248, 210);
            Controls.Add(cboRoomList);
            Controls.Add(btnChangeRoom);
            Controls.Add(lblRoomType);
            Controls.Add(label1);
            Controls.Add(label24);
            Controls.Add(ucWindowHeader1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmChangeRoom";
            Resizable = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "转换房间";
            Load += FrmChangeRoom_Load;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private ucWindowHeader ucWindowHeader1;
        private Label label24;
        private Label label1;
        private AntdUI.Label lblRoomType;
        private AntdUI.Button btnChangeRoom;
        private AntdUI.Select cboRoomList;
    }
}