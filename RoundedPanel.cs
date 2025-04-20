using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facebook_clone
{
    [DesignerCategory("Code")]
    public class RoundedPanel : Panel
    {
        #region Fields
        private int _cornerRadius = 15;
        private int _borderThickness = 0; // Default to no border
        private Color _borderColor = Color.Gray;
        private DashStyle _borderDashStyle = DashStyle.Solid;
        #endregion

        #region Constructor
        public RoundedPanel()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                    ControlStyles.OptimizedDoubleBuffer |
                    ControlStyles.ResizeRedraw |
                    ControlStyles.UserPaint |
                    ControlStyles.SupportsTransparentBackColor, true);

            this.DoubleBuffered = true;
            this.BackColor = Color.Transparent;
        }
        #endregion

        #region Properties
        [Category("Appearance")]
        [Description("Radius of the rounded corners")]
        [DefaultValue(15)]
        public int CornerRadius
        {
            get => _cornerRadius;
            set { _cornerRadius = Math.Max(0, value); UpdateRegions(); Invalidate(); }
        }

        [Category("Appearance")]
        [Description("Border thickness (0 = no border)")]
        [DefaultValue(0)]
        public int BorderThickness
        {
            get => _borderThickness;
            set { _borderThickness = Math.Max(0, value); UpdateRegions(); Invalidate(); }
        }

        [Category("Appearance")]
        [Description("Color of the border")]
        public Color BorderColor
        {
            get => _borderColor;
            set { _borderColor = value; Invalidate(); }
        }

        [Category("Appearance")]
        [Description("Style of the border line")]
        [DefaultValue(DashStyle.Solid)]
        public DashStyle BorderDashStyle
        {
            get => _borderDashStyle;
            set { _borderDashStyle = value; Invalidate(); }
        }
        #endregion

        #region Painting
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Enable anti-aliasing for all drawing operations
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath mainPath = CreateRoundedRectanglePath(ClientRectangle, _cornerRadius))
            {
                // Draw background with anti-aliased edges
                using (SolidBrush backBrush = new SolidBrush(BackColor))
                {
                    e.Graphics.FillPath(backBrush, mainPath);
                }

                // Draw border with anti-aliasing
                if (_borderThickness > 0)
                {
                    using (Pen borderPen = new Pen(_borderColor, _borderThickness))
                    {
                        borderPen.DashStyle = _borderDashStyle;
                        Rectangle borderRect = new Rectangle(
                            _borderThickness / 2,
                            _borderThickness / 2,
                            Width - _borderThickness,
                            Height - _borderThickness);

                        using (GraphicsPath borderPath = CreateRoundedRectanglePath(
                            borderRect,
                            Math.Max(0, _cornerRadius - _borderThickness / 2)))
                        {
                            e.Graphics.DrawPath(borderPen, borderPath);
                        }
                    }
                }
            }

            // Reset smoothing mode if needed (optional)
            // e.Graphics.SmoothingMode = SmoothingMode.Default;
        }
        #endregion

        #region Region Handling
        private void UpdateRegions()
        {
            using (GraphicsPath path = CreateRoundedRectanglePath(ClientRectangle, _cornerRadius))
            {
                Region = new Region(path);
            }

            // Force parent to clear any residual border
            Parent?.Invalidate(Bounds, true);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UpdateRegions();
        }
        #endregion

        #region Path Creation
        private GraphicsPath CreateRoundedRectanglePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();

            if (radius <= 0)
            {
                path.AddRectangle(rect);
                return path;
            }

            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(rect.Location, size);

            // Top left
            path.AddArc(arc, 180, 90);

            // Top right
            arc.X = rect.Right - diameter;
            path.AddArc(arc, 270, 90);

            // Bottom right
            arc.Y = rect.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // Bottom left
            arc.X = rect.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }
        #endregion
    }
}
