namespace EOM.TSHotelManagement.FormUI
{
    partial class FrmSellThing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSellThing));
            groupBox2 = new GroupBox();
            label5 = new AntdUI.Label();
            label4 = new AntdUI.Label();
            label3 = new AntdUI.Label();
            label7 = new AntdUI.Label();
            nudNum = new AntdUI.InputNumber();
            txtPrice = new AntdUI.Input();
            txtSellName = new AntdUI.Input();
            txtSellNo = new AntdUI.Input();
            txtFind = new AntdUI.Input();
            btnFind = new AntdUI.Button();
            txtRoomNo = new AntdUI.Input();
            btnCheck = new AntdUI.Button();
            dgvSellthing = new AntdUI.Table();
            btnPg = new AntdUI.Pagination();
            btnAdd = new AntdUI.Button();
            btnCancel = new AntdUI.Button();
            dgvRoomSell = new AntdUI.Table();
            label1 = new AntdUI.Label();
            label2 = new AntdUI.Label();
            lblState = new AntdUI.Label();
            btnClear = new AntdUI.Button();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(nudNum);
            groupBox2.Controls.Add(txtPrice);
            groupBox2.Controls.Add(txtSellName);
            groupBox2.Controls.Add(txtSellNo);
            groupBox2.Font = new Font("Noto Sans SC", 9F);
            groupBox2.Location = new Point(617, 57);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(452, 120);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "订购中心";
            // 
            // label5
            // 
            label5.Location = new Point(258, 78);
            label5.Name = "label5";
            label5.Size = new Size(55, 23);
            label5.TabIndex = 144;
            label5.Tag = "";
            label5.Text = "单价：";
            label5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.Location = new Point(258, 32);
            label4.Name = "label4";
            label4.Size = new Size(55, 23);
            label4.TabIndex = 143;
            label4.Tag = "";
            label4.Text = "数量：";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.Location = new Point(4, 78);
            label3.Name = "label3";
            label3.Size = new Size(107, 23);
            label3.TabIndex = 142;
            label3.Tag = "";
            label3.Text = "商品名称：";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            label7.Location = new Point(4, 32);
            label7.Name = "label7";
            label7.Size = new Size(107, 23);
            label7.TabIndex = 141;
            label7.Tag = "";
            label7.Text = "商品编号：";
            label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // nudNum
            // 
            nudNum.Font = new Font("Noto Sans SC", 12F);
            nudNum.Location = new Point(319, 23);
            nudNum.Name = "nudNum";
            nudNum.Round = true;
            nudNum.Size = new Size(119, 38);
            nudNum.TabIndex = 34;
            nudNum.Text = "0";
            nudNum.TextAlign = HorizontalAlignment.Center;
            // 
            // txtPrice
            // 
            txtPrice.Font = new Font("Noto Sans SC", 12F);
            txtPrice.Location = new Point(319, 69);
            txtPrice.Name = "txtPrice";
            txtPrice.ReadOnly = true;
            txtPrice.Round = true;
            txtPrice.Size = new Size(119, 38);
            txtPrice.TabIndex = 33;
            // 
            // txtSellName
            // 
            txtSellName.Font = new Font("Noto Sans SC", 12F);
            txtSellName.Location = new Point(111, 69);
            txtSellName.Name = "txtSellName";
            txtSellName.ReadOnly = true;
            txtSellName.Round = true;
            txtSellName.Size = new Size(145, 38);
            txtSellName.TabIndex = 32;
            // 
            // txtSellNo
            // 
            txtSellNo.Font = new Font("Noto Sans SC", 12F);
            txtSellNo.Location = new Point(111, 23);
            txtSellNo.Name = "txtSellNo";
            txtSellNo.ReadOnly = true;
            txtSellNo.Round = true;
            txtSellNo.Size = new Size(145, 38);
            txtSellNo.TabIndex = 31;
            // 
            // txtFind
            // 
            txtFind.Font = new Font("Noto Sans SC", 12F);
            txtFind.Location = new Point(148, 13);
            txtFind.Name = "txtFind";
            txtFind.Round = true;
            txtFind.Size = new Size(197, 38);
            txtFind.TabIndex = 27;
            // 
            // btnFind
            // 
            btnFind.Font = new Font("Noto Sans SC", 12F);
            btnFind.Location = new Point(351, 13);
            btnFind.Name = "btnFind";
            btnFind.Shape = AntdUI.TShape.Round;
            btnFind.Size = new Size(101, 38);
            btnFind.TabIndex = 28;
            btnFind.Text = "查     找";
            btnFind.Type = AntdUI.TTypeMini.Primary;
            btnFind.Click += btnFind_Click;
            // 
            // txtRoomNo
            // 
            txtRoomNo.Font = new Font("Noto Sans SC", 12F);
            txtRoomNo.Location = new Point(617, 13);
            txtRoomNo.Name = "txtRoomNo";
            txtRoomNo.Round = true;
            txtRoomNo.Size = new Size(134, 38);
            txtRoomNo.TabIndex = 30;
            txtRoomNo.TextChanged += txtRoomNo_TextChanged;
            txtRoomNo.Validated += txtRoomNo_Validated;
            // 
            // btnCheck
            // 
            btnCheck.Font = new Font("Noto Sans SC", 12F);
            btnCheck.Location = new Point(764, 15);
            btnCheck.Name = "btnCheck";
            btnCheck.Shape = AntdUI.TShape.Round;
            btnCheck.Size = new Size(101, 38);
            btnCheck.TabIndex = 31;
            btnCheck.Text = "可否消费";
            btnCheck.Type = AntdUI.TTypeMini.Primary;
            btnCheck.Click += btnCheck_Click;
            // 
            // dgvSellthing
            // 
            dgvSellthing.AutoSizeColumnsMode = AntdUI.ColumnsMode.Fill;
            dgvSellthing.Bordered = true;
            dgvSellthing.Font = new Font("Noto Sans SC", 9F);
            dgvSellthing.Gap = 12;
            dgvSellthing.Location = new Point(4, 57);
            dgvSellthing.Name = "dgvSellthing";
            dgvSellthing.Size = new Size(487, 382);
            dgvSellthing.TabIndex = 131;
            dgvSellthing.CellClick += dgvSellthing_CellClick;
            // 
            // btnPg
            // 
            btnPg.Font = new Font("Noto Sans SC", 12F);
            btnPg.Location = new Point(4, 448);
            btnPg.Name = "btnPg";
            btnPg.PageSize = 15;
            btnPg.ShowSizeChanger = true;
            btnPg.Size = new Size(487, 31);
            btnPg.TabIndex = 135;
            btnPg.Total = 1000000;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Noto Sans SC", 12F);
            btnAdd.Location = new Point(496, 58);
            btnAdd.Name = "btnAdd";
            btnAdd.Shape = AntdUI.TShape.Round;
            btnAdd.Size = new Size(115, 38);
            btnAdd.TabIndex = 136;
            btnAdd.Text = "确定添加";
            btnAdd.Type = AntdUI.TTypeMini.Primary;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Noto Sans SC", 12F);
            btnCancel.Location = new Point(496, 144);
            btnCancel.Name = "btnCancel";
            btnCancel.Shape = AntdUI.TShape.Round;
            btnCancel.Size = new Size(115, 38);
            btnCancel.TabIndex = 137;
            btnCancel.Text = "撤回添加";
            btnCancel.Type = AntdUI.TTypeMini.Primary;
            btnCancel.Click += btnCancel_Click;
            // 
            // dgvRoomSell
            // 
            dgvRoomSell.AutoSizeColumnsMode = AntdUI.ColumnsMode.Fill;
            dgvRoomSell.Bordered = true;
            dgvRoomSell.Font = new Font("Noto Sans SC", 9F);
            dgvRoomSell.Gap = 12;
            dgvRoomSell.Location = new Point(497, 188);
            dgvRoomSell.Name = "dgvRoomSell";
            dgvRoomSell.Size = new Size(572, 291);
            dgvRoomSell.TabIndex = 138;
            dgvRoomSell.CellClick += dgvRoomSell_CellClick;
            // 
            // label1
            // 
            label1.Location = new Point(22, 22);
            label1.Name = "label1";
            label1.Size = new Size(120, 23);
            label1.TabIndex = 139;
            label1.Tag = "消费房号：";
            label1.Text = "要查找的商品名称：";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.Location = new Point(510, 22);
            label2.Name = "label2";
            label2.Size = new Size(107, 23);
            label2.TabIndex = 140;
            label2.Tag = "";
            label2.Text = "消费房号：";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblState
            // 
            lblState.Location = new Point(886, 22);
            lblState.Name = "lblState";
            lblState.Size = new Size(107, 23);
            lblState.TabIndex = 141;
            lblState.Tag = "";
            lblState.Text = "";
            lblState.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(462, 12);
            btnClear.Name = "btnClear";
            btnClear.Radius = 16;
            btnClear.Size = new Size(42, 39);
            btnClear.TabIndex = 155;
            btnClear.Click += btnClear_Click;
            // 
            // FrmSellThing
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(235, 243, 255);
            ClientSize = new Size(1072, 486);
            Controls.Add(btnClear);
            Controls.Add(lblState);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvRoomSell);
            Controls.Add(btnCancel);
            Controls.Add(btnAdd);
            Controls.Add(btnPg);
            Controls.Add(dgvSellthing);
            Controls.Add(btnCheck);
            Controls.Add(txtRoomNo);
            Controls.Add(btnFind);
            Controls.Add(txtFind);
            Controls.Add(groupBox2);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmSellThing";
            Resizable = false;
            Text = "商品消费";
            Load += FrmSellThing_Load;
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn clRoomNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clCustoNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSpendName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSpendAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSpendPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSpendMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSpendTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSpendNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSellNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSellName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSellPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn clFormat;
        private System.Windows.Forms.DataGridViewTextBoxColumn clStock;
        private AntdUI.Input txtFind;
        private AntdUI.Button btnFind;
        private AntdUI.Input txtRoomNo;
        private AntdUI.Button btnCheck;
        private AntdUI.Table dgvSellthing;
        private AntdUI.Pagination btnPg;
        private AntdUI.Button btnAdd;
        private AntdUI.Button btnCancel;
        private AntdUI.Table dgvRoomSell;
        private ucWindowHeader ucWindowHeader1;
        private AntdUI.InputNumber nudNum;
        private AntdUI.Input txtPrice;
        private AntdUI.Input txtSellName;
        private AntdUI.Input txtSellNo;
        private AntdUI.Label label1;
        private AntdUI.Label label2;
        private AntdUI.Label label5;
        private AntdUI.Label label4;
        private AntdUI.Label label3;
        private AntdUI.Label label7;
        private AntdUI.Label lblState;
        private AntdUI.Button btnClear;
    }
}