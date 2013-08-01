using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WeifenLuo.WinFormsUI.Docking
{
    internal class VS2012LightSplitterControl : DockPane.SplitterControlBase
    {
        private static readonly SolidBrush _horizontalBrush = new SolidBrush(Color.FromArgb(0xFF, 204, 206, 219));
        private static readonly Color[] _verticalSurroundColors = new[] { SystemColors.Control };


        public VS2012LightSplitterControl(DockPane pane)
            : base(pane)
        {
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            Rectangle rect = ClientRectangle;

            switch (Alignment)
            {
                case DockAlignment.Right:
                case DockAlignment.Left:
                    {
                        var path = new GraphicsPath();
                        path.AddRectangle(rect);
                        var brush = new PathGradientBrush(path)
                            {
                                CenterColor = Color.FromArgb(0xFF, 204, 206, 219), 
                                SurroundColors = _verticalSurroundColors
                            };

                        g.FillRectangle(brush, rect.X + Measures.SplitterSize / 2 - 1, rect.Y,
                                        Measures.SplitterSize / 3, rect.Height);

                        path.Dispose();
                        brush.Dispose();
                    }
                    break;
                case DockAlignment.Bottom:
                case DockAlignment.Top:
                    {
                        g.FillRectangle(_horizontalBrush, rect.X, rect.Y,
                                        rect.Width, Measures.SplitterSize);
                    }
                    break;
            }
        }
    }
}