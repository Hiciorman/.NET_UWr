using System.Drawing;
using System.Windows.Forms;

namespace _3._2._4
{
    public class SmoothProgressBar : UserControl
    {
        private int x = 0;
        public int X
        {
            get { return x; }
            set { x = value; }
        }

        private int y = 0;
        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        private int width = 100;
        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        private int height = 30;
        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        private int min = 0;
        public int Min
        {
            get { return min; }
            set { min = value; }
        }

        private int max = 100;
        public int Max
        {
            get { return max; }
            set { max = value; }
        }

        private int valueS = 0;
        public int Value
        {
            get { return valueS; }
            set
            {
                if (value > Max)
                {
                    valueS = Max;
                }
                else if (value < Min)
                {
                    valueS = Min;
                }
                else
                {
                    valueS = value;
                }
            }
        }



        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics GDI = e.Graphics;
            SolidBrush brush = new SolidBrush(Color.Blue);
            float percent = (float)(Value - Min) / (float)(Max - Min);
            Rectangle rect = new Rectangle(X, Y, Width, Height);

            rect.Width = (int)((float)rect.Width * percent);

            GDI.FillRectangle(brush, rect);

            Draw3DBorder(GDI);
            brush.Dispose();
            GDI.Dispose();
        }

        private void Draw3DBorder(Graphics g)
        {
            g.DrawLine(Pens.DarkBlue,
                new Point(X, Y),
                new Point(Width + X, Y));
            g.DrawLine(Pens.DarkBlue,
                new Point(X, Height + Y),
                new Point(Width + X, Height + Y));
            g.DrawLine(Pens.DarkBlue,
                new Point(X, Y),
                new Point(X, Height + Y));
            g.DrawLine(Pens.DarkBlue,
                new Point(Width + X, Y),
                new Point(Width + X, Height + Y));
        }
    }
}
