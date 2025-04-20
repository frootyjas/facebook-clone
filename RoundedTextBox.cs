using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;



namespace facebook_clone
{
    [DefaultEvent("TextChanged")]
    public partial class RoundedTextBox : UserControl
    {
        // P/Invoke declarations
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, ref RECT rect);
        private const int EM_SETRECT = 0xB3;

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        private TextBox textBox;
        private int cornerRadius = 10;
        private Color borderColor = Color.Gray;
        private int borderWidth = 1;

        public RoundedTextBox()
        {
                
            SetStyle(ControlStyles.SupportsTransparentBackColor |
                   ControlStyles.OptimizedDoubleBuffer |
                   ControlStyles.AllPaintingInWmPaint |
                   ControlStyles.ResizeRedraw, true);
            CreateTextBox();
            UpdateTextBoxRegion();
        }

        private void CreateTextBox()
        {
            textBox = new TextBox
            {
                BorderStyle = BorderStyle.None,
                Multiline = true,
                Dock = DockStyle.Fill,
                Font = this.Font,
                ForeColor = this.ForeColor,
            
            };

            textBox.TextChanged += (s, e) => OnTextChanged(e);
            Controls.Add(textBox);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x20; // WS_EX_TRANSPARENT
                return cp;
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // Don't paint background if transparent
            if (BackColor != Color.Transparent)
            {
                using (var brush = new SolidBrush(BackColor))
                {
                    e.Graphics.FillRectangle(brush, ClientRectangle);
                }
            }
        }

        // Expose TextBox properties
        public override string Text
        {
            get => textBox.Text;
            set => textBox.Text = value;
        }

        public HorizontalAlignment TextAlign
        {
            get => textBox.TextAlign;
            set => textBox.TextAlign = value;
        }

        public int CornerRadius
        {
            get => cornerRadius;
            set { cornerRadius = value; Invalidate(); }
        }

        public Color BorderColor
        {
            get => borderColor;
            set { borderColor = value; Invalidate(); }
        }

        public int BorderWidth
        {
            get => borderWidth;
            set { borderWidth = value; Invalidate(); }
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
            if (textBox != null)
                textBox.BackColor = this.BackColor;
        }

        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);
            if (textBox != null)
                textBox.ForeColor = this.ForeColor;
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            if (textBox != null)
                textBox.Font = this.Font;
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (GraphicsPath path = CreateRoundedRectanglePath(
                new Rectangle(borderWidth / 2, borderWidth / 2,
                    Width - borderWidth, Height - borderWidth),
                cornerRadius))
            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.DrawPath(pen, path);
            }
        }
        private GraphicsPath CreateRoundedRectanglePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
            path.CloseFigure();
            return path;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UpdateTextBoxRegion();
            Invalidate();
        }


        private void UpdateTextArea()
        {
            if (textBox == null) return;

            // Calculate vertical padding
            int textHeight = TextRenderer.MeasureText(" ", textBox.Font).Height;
            int margin = (textBox.Height - textHeight) / 2;

            RECT rect = new RECT
            {
                Left = borderWidth + 2,
                Top = margin,
                Right = textBox.Width - borderWidth - 2,
                Bottom = textBox.Height - margin
            };

            SendMessage(textBox.Handle, EM_SETRECT, 0, ref rect);
        }

        private void UpdateTextBoxRegion()
        {
            if (textBox == null) return;

            int radius = Math.Max(0, cornerRadius - borderWidth);
            using (GraphicsPath path = CreateRoundedRectanglePath(
                new Rectangle(0, 0, textBox.Width, textBox.Height),
                radius))
            {
                textBox.Region = new Region(path);
            }
            UpdateTextArea();
        }
    }
}
