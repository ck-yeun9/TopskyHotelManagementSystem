using EOM.TSHotelManagement.Shared;
using System.Drawing.Drawing2D;

namespace EOM.TSHotelManagement.FormUI
{
    public partial class ucWindowHeader : UserControl
    {
        public ucWindowHeader()
        {
            InitializeComponent();
            if (!DesignMode) SetDefaults();
            this.Visible = true;
            phCustoHeader.Visible = true;
        }

        public ucWindowHeader(string title, string subTitle, Image? icon = null,
                              bool showIcon = true, bool showClose = true, bool showMinimize = true)
            : this()
        {
            ApplySettings(title, subTitle, icon, showIcon, showClose, showMinimize);
        }


        #region 圆角代码
        public GraphicsPath GetRoundRectPath(RectangleF rect, float radius)
        {
            return GetRoundRectPath(rect.X, rect.Y, rect.Width, rect.Height, radius);
        }
        public GraphicsPath GetRoundRectPath(float X, float Y, float width, float height, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddLine(X + radius, Y, (X + width) - (radius * 2f), Y);
            path.AddArc((X + width) - (radius * 2f), Y, radius * 2f, radius * 2f, 270f, 100f);
            path.AddLine((float)(X + width), (float)(Y + radius), (float)(X + width), (float)((Y + height) - (radius * 2f)));
            path.AddArc((float)((X + width) - (radius * 2f)), (float)((Y + height) - (radius * 2f)), (float)(radius * 2f), (float)(radius * 2f), 0f, 100f);
            path.AddLine((float)((X + width) - (radius * 2f)), (float)(Y + height), (float)(X + radius), (float)(Y + height));
            path.AddArc(X, (Y + height) - (radius * 2f), radius * 2f, radius * 2f, 100f, 100f);
            path.AddLine(X, (Y + height) - (radius * 2f), X, Y + radius);
            path.AddArc(X, Y, radius * 2f, radius * 2f, 180f, 100f);
            path.CloseFigure();
            return path;
        }

        //窗体圆角代码开始
        public void SetWindowRegion()
        {
            System.Drawing.Drawing2D.GraphicsPath FormPath;
            FormPath = new System.Drawing.Drawing2D.GraphicsPath();
            Rectangle rect = new Rectangle(0, 22, this.Width, this.Height - 22);
            //this.Left-10,this.Top-10,this.Width-10,this.Height-10);                 
            FormPath = GetRoundedRectPath(rect, 30);
            this.Region = new Region(FormPath);
        }
        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            int diameter = radius;
            Rectangle arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));
            GraphicsPath path = new GraphicsPath();
            //   左上角   
            path.AddArc(arcRect, 180, 90);
            //   右上角   
            arcRect.X = rect.Right - diameter;
            path.AddArc(arcRect, 270, 90);
            //   右下角   
            arcRect.Y = rect.Bottom - diameter;
            path.AddArc(arcRect, 0, 90);
            //   左下角   
            arcRect.X = rect.Left;
            path.AddArc(arcRect, 90, 90);
            path.CloseFigure();
            return path;
        }
        protected override void OnResize(System.EventArgs e)
        {
            this.Region = null;
            SetWindowRegion();
        }
        #endregion


        public void ApplySettings(string title, string subTitle, Image? icon, bool showIcon, bool showClose, bool showMinimize)
        {
            phCustoHeader.Text = title;
            phCustoHeader.SubText = subTitle;
            phCustoHeader.ShowIcon = showIcon;
            phCustoHeader.Icon = icon;
            btnClose.IconSvg = UIControlIconConstant.Close;
            btnClose.Visible = showClose;
            phCustoHeader.Refresh();
            this.Refresh();
        }

        public void ApplySettings(string title, string subTitle, Image? icon)
        {
            phCustoHeader.Text = title;
            phCustoHeader.SubText = subTitle;
            phCustoHeader.ShowIcon = true;
            phCustoHeader.Icon = icon;
            btnClose.Visible = true;
            phCustoHeader.Refresh();
            this.Refresh();
        }

        public void ApplySettingsWithoutIcon(string title, string subTitle, Image? icon)
        {
            phCustoHeader.Text = title;
            phCustoHeader.SubText = subTitle;
            phCustoHeader.ShowIcon = false;
            phCustoHeader.Icon = null;
            btnClose.Visible = true;
            phCustoHeader.Refresh();
            this.Refresh();
        }

        public void ApplySettingsWithoutMinimize(string title, string subTitle, Image? icon,
                                  bool showIcon = true, bool showClose = true)
        {
            phCustoHeader.Text = title;
            phCustoHeader.SubText = subTitle;
            phCustoHeader.ShowIcon = showIcon;
            phCustoHeader.Icon = icon;
            btnClose.Visible = showClose;
            btnClose.IconSvg = UIControlIconConstant.Close;
            phCustoHeader.Refresh();
            this.Refresh();
        }

        private void SetDefaults()
        {
            phCustoHeader.Text = string.Empty;
            phCustoHeader.SubText = string.Empty;
            btnClose.IconSvg = UIControlIconConstant.Close;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            var parentForm = this.FindForm();
            if (parentForm != null)
            {
                parentForm.Close();
            }
        }

        private void ucWindowHeader_Load(object sender, EventArgs e)
        {
            this.Region = new Region(GetRoundRectPath(new RectangleF(0, 0, this.Width, this.Height), 6f));
        }
    }
}
