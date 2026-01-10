namespace EOM.TSHotelManagement.FormUI
{
    partial class FrmAvator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAvator));
            label4 = new AntdUI.Label();
            picWorkerPic = new PictureBox();
            openPic = new OpenFileDialog();
            ucWindowHeader1 = new ucWindowHeader();
            ((System.ComponentModel.ISupportInitialize)picWorkerPic).BeginInit();
            SuspendLayout();
            // 
            // label4
            // 
            label4.Font = new Font("Noto Sans SC", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(293, 347);
            label4.Name = "label4";
            label4.Size = new Size(215, 23);
            label4.TabIndex = 3;
            label4.Text = "Tips:头像大小不能超过1MB";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // picWorkerPic
            // 
            picWorkerPic.BackgroundImage = Properties.Resources.账号;
            picWorkerPic.BackgroundImageLayout = ImageLayout.Stretch;
            picWorkerPic.Location = new Point(293, 81);
            picWorkerPic.Name = "picWorkerPic";
            picWorkerPic.Size = new Size(215, 246);
            picWorkerPic.SizeMode = PictureBoxSizeMode.StretchImage;
            picWorkerPic.TabIndex = 2;
            picWorkerPic.TabStop = false;
            picWorkerPic.Click += picWorkerPic_Click;
            // 
            // openPic
            // 
            openPic.FileName = "openFileDialog1";
            openPic.Filter = "PNG文件|*.png|JPG文件|*.jpg|位图文件|*.bmp";
            openPic.FileOk += openPic_FileOk;
            // 
            // ucWindowHeader1
            // 
            ucWindowHeader1.Location = new Point(-2, 0);
            ucWindowHeader1.Name = "ucWindowHeader1";
            ucWindowHeader1.Size = new Size(804, 35);
            ucWindowHeader1.TabIndex = 4;
            // 
            // FrmAvator
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(235, 243, 255);
            ClientSize = new Size(800, 450);
            Controls.Add(ucWindowHeader1);
            Controls.Add(label4);
            Controls.Add(picWorkerPic);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmAvator";
            Resizable = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "账号头像";
            Load += FrmAvator_Load;
            ((System.ComponentModel.ISupportInitialize)picWorkerPic).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Label label4;
        private PictureBox picWorkerPic;
        private OpenFileDialog openPic;
        private ucWindowHeader ucWindowHeader1;
    }
}