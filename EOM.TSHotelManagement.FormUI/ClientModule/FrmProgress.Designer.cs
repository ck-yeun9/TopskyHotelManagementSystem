namespace EOM.TSHotelManagement.FormUI
{
    partial class FrmProgress
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProgress));
            spin1 = new AntdUI.Spin();
            SuspendLayout();
            // 
            // spin1
            // 
            spin1.BackColor = Color.Transparent;
            spin1.Font = new Font("Noto Sans SC", 10F);
            spin1.Location = new Point(7, 13);
            spin1.Name = "spin1";
            spin1.Size = new Size(141, 84);
            spin1.TabIndex = 0;
            spin1.Text = "正在加载中......";
            // 
            // FrmProgress
            // 
            AutoHandDpi = false;
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(235, 243, 255);
            ClientSize = new Size(155, 110);
            Controls.Add(spin1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmProgress";
            Resizable = false;
            ShowIcon = false;
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Show;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Loading...";
            TopMost = true;
            Load += FrmProgress_Load;
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Label label1;
        private AntdUI.Spin spin1;
    }
}