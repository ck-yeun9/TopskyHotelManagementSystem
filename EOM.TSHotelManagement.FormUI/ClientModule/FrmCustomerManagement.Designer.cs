namespace EOM.TSHotelManagement.FormUI
{
    partial class FrmCustomerManagement
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
            components = new System.ComponentModel.Container();
            toolTip1 = new ToolTip(components);
            btnSerach = new AntdUI.Button();
            btnAddCusto = new AntdUI.Button();
            btnUpdCustomer = new AntdUI.Button();
            dgvCustomerList = new AntdUI.Table();
            cmsCustomerAction = new ContextMenuStrip(components);
            tsmiCustoNoCopy = new ToolStripMenuItem();
            btnPg = new AntdUI.Pagination();
            label1 = new AntdUI.Label();
            label2 = new AntdUI.Label();
            txtCustoName = new AntdUI.Input();
            txtCustoNo = new AntdUI.Input();
            divider1 = new AntdUI.Divider();
            cmsCustomerAction.SuspendLayout();
            SuspendLayout();
            // 
            // toolTip1
            // 
            toolTip1.ToolTipIcon = ToolTipIcon.Info;
            toolTip1.ToolTipTitle = "获取账号";
            // 
            // btnSerach
            // 
            btnSerach.Font = new Font("Noto Sans SC", 12F);
            btnSerach.Location = new Point(602, 441);
            btnSerach.Name = "btnSerach";
            btnSerach.Shape = AntdUI.TShape.Round;
            btnSerach.Size = new Size(93, 47);
            btnSerach.TabIndex = 127;
            btnSerach.Text = "搜    索";
            btnSerach.Type = AntdUI.TTypeMini.Primary;
            btnSerach.Click += btnSerach_BtnClick;
            // 
            // btnAddCusto
            // 
            btnAddCusto.Font = new Font("Noto Sans SC", 12F);
            btnAddCusto.IconPosition = AntdUI.TAlignMini.Top;
            btnAddCusto.Location = new Point(772, 441);
            btnAddCusto.Name = "btnAddCusto";
            btnAddCusto.Shape = AntdUI.TShape.Round;
            btnAddCusto.Size = new Size(93, 47);
            btnAddCusto.TabIndex = 128;
            btnAddCusto.Text = "添加客户";
            btnAddCusto.TextCenterHasIcon = true;
            btnAddCusto.Type = AntdUI.TTypeMini.Primary;
            btnAddCusto.Click += btnAddCusto_BtnClick;
            // 
            // btnUpdCustomer
            // 
            btnUpdCustomer.Enabled = false;
            btnUpdCustomer.Font = new Font("Noto Sans SC", 12F);
            btnUpdCustomer.Location = new Point(942, 441);
            btnUpdCustomer.Name = "btnUpdCustomer";
            btnUpdCustomer.Shape = AntdUI.TShape.Round;
            btnUpdCustomer.Size = new Size(93, 47);
            btnUpdCustomer.TabIndex = 129;
            btnUpdCustomer.Text = "修改客户";
            btnUpdCustomer.Type = AntdUI.TTypeMini.Primary;
            btnUpdCustomer.Click += btnUpdCustomer_Click;
            // 
            // dgvCustomerList
            // 
            dgvCustomerList.Bordered = true;
            dgvCustomerList.ContextMenuStrip = cmsCustomerAction;
            dgvCustomerList.Gap = 12;
            dgvCustomerList.Location = new Point(10, 7);
            dgvCustomerList.Name = "dgvCustomerList";
            dgvCustomerList.Size = new Size(1053, 391);
            dgvCustomerList.TabIndex = 130;
            dgvCustomerList.CellClick += dgvCustomerList_CellClick;
            dgvCustomerList.CellDoubleClick += dgvCustomerList_CellDoubleClick;
            // 
            // cmsCustomerAction
            // 
            cmsCustomerAction.Items.AddRange(new ToolStripItem[] { tsmiCustoNoCopy });
            cmsCustomerAction.Name = "cmsCustomerAction";
            cmsCustomerAction.Size = new Size(149, 26);
            // 
            // tsmiCustoNoCopy
            // 
            tsmiCustoNoCopy.Name = "tsmiCustoNoCopy";
            tsmiCustoNoCopy.Size = new Size(148, 22);
            tsmiCustoNoCopy.Text = "复制用户编号";
            tsmiCustoNoCopy.Click += tsmiCustoNo_Click;
            // 
            // btnPg
            // 
            btnPg.Font = new Font("Noto Sans SC", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPg.Location = new Point(10, 404);
            btnPg.Name = "btnPg";
            btnPg.PageSize = 15;
            btnPg.ShowSizeChanger = true;
            btnPg.Size = new Size(636, 31);
            btnPg.TabIndex = 134;
            btnPg.Total = 1000000;
            btnPg.ValueChanged += btnPg_ValueChanged;
            btnPg.ShowTotalChanged += btnPg_ShowTotalChanged;
            // 
            // label1
            // 
            label1.Font = new Font("Noto Sans SC", 12F);
            label1.Location = new Point(283, 453);
            label1.Name = "label1";
            label1.Size = new Size(86, 26);
            label1.TabIndex = 152;
            label1.Text = "客户姓名";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Font = new Font("Noto Sans SC", 12F);
            label2.Location = new Point(12, 453);
            label2.Name = "label2";
            label2.Size = new Size(86, 26);
            label2.TabIndex = 151;
            label2.Text = "客户编号";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtCustoName
            // 
            txtCustoName.Font = new Font("Noto Sans SC", 12F);
            txtCustoName.Location = new Point(375, 444);
            txtCustoName.Name = "txtCustoName";
            txtCustoName.PlaceholderText = "请输入客户姓名...";
            txtCustoName.Round = true;
            txtCustoName.Size = new Size(173, 42);
            txtCustoName.TabIndex = 150;
            // 
            // txtCustoNo
            // 
            txtCustoNo.Font = new Font("Noto Sans SC", 12F);
            txtCustoNo.Location = new Point(104, 444);
            txtCustoNo.Name = "txtCustoNo";
            txtCustoNo.PlaceholderText = "请输入客户编号...";
            txtCustoNo.Round = true;
            txtCustoNo.Size = new Size(173, 42);
            txtCustoNo.TabIndex = 149;
            // 
            // divider1
            // 
            divider1.Font = new Font("Noto Sans SC", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            divider1.Location = new Point(670, 406);
            divider1.Name = "divider1";
            divider1.Size = new Size(393, 23);
            divider1.TabIndex = 153;
            divider1.Text = "右键可复制快速客户编号";
            divider1.Thickness = 1F;
            // 
            // FrmCustomerManagement
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(235, 243, 255);
            ClientSize = new Size(1072, 490);
            Controls.Add(divider1);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(txtCustoName);
            Controls.Add(txtCustoNo);
            Controls.Add(btnPg);
            Controls.Add(dgvCustomerList);
            Controls.Add(btnUpdCustomer);
            Controls.Add(btnAddCusto);
            Controls.Add(btnSerach);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4);
            Name = "FrmCustomerManagement";
            Text = "TS酒店管理系统";
            Load += FrmCustomerManagement_Load;
            cmsCustomerAction.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private AntdUI.Button btnSerach;
        private AntdUI.Button btnAddCusto;
        private AntdUI.Button btnUpdCustomer;
        private AntdUI.Table dgvCustomerList;
        private AntdUI.Pagination btnPg;
        private AntdUI.Label label1;
        private AntdUI.Label label2;
        private AntdUI.Input txtCustoName;
        private AntdUI.Input txtCustoNo;
        private ContextMenuStrip cmsCustomerAction;
        private ToolStripMenuItem tsmiCustoNoCopy;
        private AntdUI.Divider divider1;
    }
}