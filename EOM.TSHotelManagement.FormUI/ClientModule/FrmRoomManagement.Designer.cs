namespace EOM.TSHotelManagement.FormUI
{
    partial class FrmRoomManager
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
            pnlRoomInfo = new Panel();
            lblRoomState = new Label();
            label11 = new Label();
            lblRoomNo = new Label();
            lblCustoName = new Label();
            lblRoomPosition = new Label();
            lblCheckTime = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            muRoomState = new AntdUI.Menu();
            flpRoomTypes = new AntdUI.In.FlowLayoutPanel();
            flpRoom = new AntdUI.In.FlowLayoutPanel();
            pnlRoomInfo.SuspendLayout();
            SuspendLayout();
            // 
            // pnlRoomInfo
            // 
            pnlRoomInfo.BackColor = Color.Transparent;
            pnlRoomInfo.Controls.Add(lblRoomState);
            pnlRoomInfo.Controls.Add(label11);
            pnlRoomInfo.Controls.Add(lblRoomNo);
            pnlRoomInfo.Controls.Add(lblCustoName);
            pnlRoomInfo.Controls.Add(lblRoomPosition);
            pnlRoomInfo.Controls.Add(lblCheckTime);
            pnlRoomInfo.Controls.Add(label4);
            pnlRoomInfo.Controls.Add(label3);
            pnlRoomInfo.Controls.Add(label2);
            pnlRoomInfo.Controls.Add(label1);
            pnlRoomInfo.Location = new Point(3, 339);
            pnlRoomInfo.Margin = new Padding(4);
            pnlRoomInfo.Name = "pnlRoomInfo";
            pnlRoomInfo.Size = new Size(255, 280);
            pnlRoomInfo.TabIndex = 72;
            // 
            // lblRoomState
            // 
            lblRoomState.AutoSize = true;
            lblRoomState.Font = new Font("Noto Sans SC", 12F);
            lblRoomState.Location = new Point(108, 173);
            lblRoomState.Margin = new Padding(4, 0, 4, 0);
            lblRoomState.Name = "lblRoomState";
            lblRoomState.Size = new Size(14, 24);
            lblRoomState.TabIndex = 16;
            lblRoomState.Text = " ";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Noto Sans SC", 12F);
            label11.Location = new Point(11, 173);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(90, 24);
            label11.TabIndex = 15;
            label11.Text = "房间状态：";
            // 
            // lblRoomNo
            // 
            lblRoomNo.AutoSize = true;
            lblRoomNo.Font = new Font("Noto Sans SC", 12F);
            lblRoomNo.Location = new Point(108, 13);
            lblRoomNo.Margin = new Padding(4, 0, 4, 0);
            lblRoomNo.Name = "lblRoomNo";
            lblRoomNo.Size = new Size(14, 24);
            lblRoomNo.TabIndex = 14;
            lblRoomNo.Text = " ";
            // 
            // lblCustoName
            // 
            lblCustoName.AutoSize = true;
            lblCustoName.Font = new Font("Noto Sans SC", 12F);
            lblCustoName.Location = new Point(108, 53);
            lblCustoName.Margin = new Padding(4, 0, 4, 0);
            lblCustoName.Name = "lblCustoName";
            lblCustoName.Size = new Size(14, 24);
            lblCustoName.TabIndex = 12;
            lblCustoName.Text = " ";
            // 
            // lblRoomPosition
            // 
            lblRoomPosition.AutoSize = true;
            lblRoomPosition.Font = new Font("Noto Sans SC", 12F);
            lblRoomPosition.Location = new Point(108, 133);
            lblRoomPosition.Margin = new Padding(4, 0, 4, 0);
            lblRoomPosition.Name = "lblRoomPosition";
            lblRoomPosition.Size = new Size(14, 24);
            lblRoomPosition.TabIndex = 10;
            lblRoomPosition.Text = " ";
            // 
            // lblCheckTime
            // 
            lblCheckTime.AutoSize = true;
            lblCheckTime.Font = new Font("Noto Sans SC", 12F);
            lblCheckTime.Location = new Point(108, 93);
            lblCheckTime.Margin = new Padding(4, 0, 4, 0);
            lblCheckTime.Name = "lblCheckTime";
            lblCheckTime.Size = new Size(14, 24);
            lblCheckTime.TabIndex = 9;
            lblCheckTime.Text = " ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Noto Sans SC", 12F);
            label4.Location = new Point(11, 133);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(90, 24);
            label4.TabIndex = 3;
            label4.Text = "所在区域：";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Noto Sans SC", 12F);
            label3.Location = new Point(11, 93);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(90, 24);
            label3.TabIndex = 2;
            label3.Text = "入住时间：";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Noto Sans SC", 12F);
            label2.Location = new Point(11, 53);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(90, 24);
            label2.TabIndex = 1;
            label2.Text = "客户名字：";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Noto Sans SC", 12F);
            label1.Location = new Point(11, 13);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(90, 24);
            label1.TabIndex = 0;
            label1.Text = "房间号码：";
            // 
            // muRoomState
            // 
            muRoomState.Font = new Font("Noto Sans SC", 10F);
            muRoomState.Indent = true;
            muRoomState.Location = new Point(2, 4);
            muRoomState.Mode = AntdUI.TMenuMode.Vertical;
            muRoomState.Name = "muRoomState";
            muRoomState.Size = new Size(255, 328);
            muRoomState.TabIndex = 96;
            muRoomState.SelectChanged += muRoomState_SelectChanged;
            // 
            // flpRoomTypes
            // 
            flpRoomTypes.Location = new Point(265, 6);
            flpRoomTypes.Name = "flpRoomTypes";
            flpRoomTypes.Size = new Size(804, 90);
            flpRoomTypes.TabIndex = 97;
            // 
            // flpRoom
            // 
            flpRoom.Location = new Point(265, 103);
            flpRoom.Name = "flpRoom";
            flpRoom.Size = new Size(804, 516);
            flpRoom.TabIndex = 98;
            // 
            // FrmRoomManager
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(235, 243, 255);
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1072, 623);
            Controls.Add(flpRoom);
            Controls.Add(flpRoomTypes);
            Controls.Add(muRoomState);
            Controls.Add(pnlRoomInfo);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "FrmRoomManager";
            StartPosition = FormStartPosition.CenterScreen;
            TransparencyKey = Color.White;
            Load += FrmRoomManager_Load;
            pnlRoomInfo.ResumeLayout(false);
            pnlRoomInfo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        public System.Windows.Forms.FlowLayoutPanel pe;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblRoomState;
        public System.Windows.Forms.Label lblRoomNo;
        public System.Windows.Forms.Label lblCustoName;
        public System.Windows.Forms.Label lblRoomPosition;
        public System.Windows.Forms.Label lblCheckTime;
        public System.Windows.Forms.Panel pnlRoomInfo;
        private AntdUI.Menu muRoomState;
        private AntdUI.In.FlowLayoutPanel flpRoomTypes;
        private AntdUI.In.FlowLayoutPanel flpRoom;
    }
}