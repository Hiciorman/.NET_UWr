using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3._2._3
{
    public partial class Form1 : Form
    {
        Graphics GDI;

        public Form1()
        {
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();

            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            int width = 200;
            int height = 200;
            GDI = e.Graphics;
            GDI.Clear(Color.Black);
            GDI.SmoothingMode = SmoothingMode.AntiAlias;

            Font myFont = new Font("Arial", 12, FontStyle.Bold);

            //Tarcza zegara
            //GDI.FillEllipse(Brushes.White,    width / 2 - width / 3, height / 2 - height / 3, 2 * width / 3, 2 * height / 3);
 
            int i_h = DateTime.Now.Hour;
            int i_min = DateTime.Now.Minute;
            int i_sec = DateTime.Now.Second;

            int x_sec = width / 2 + (int)(width / 3 * Math.Sin(2 * Math.PI * (double)i_sec / 60));
            int y_sec = height / 2 - (int)(height / 3 * Math.Cos(2 * Math.PI * (double)i_sec / 60));
            int x_min = width / 2 + (int)(0.8 * width / 3 * Math.Sin(2 * Math.PI * (double)i_min / 60));
            int y_min = height / 2 - (int)(0.8 * height / 3 * Math.Cos(2 * Math.PI * (double)i_min / 60));
            int x_h = width / 2 + (int)(0.5 * width / 3 * Math.Sin(2 * Math.PI * (double)i_h / 12));
            int y_h = height / 2 - (int)(0.5 * height / 3 * Math.Cos(2 * Math.PI * (double)i_h / 12));


            GDI.DrawLine(new Pen(Color.Blue, 2), width / 2, height / 2, x_sec, y_sec);
            GDI.DrawLine(new Pen(Color.Blue, 3), width / 2, height / 2, x_min, y_min);
            GDI.DrawLine(new Pen(Color.Blue, 4), width / 2, height / 2, x_h, y_h);

            for (int i = 1; i <= 12; i++)
            {
                GDI.DrawString("" + i, myFont, Brushes.Red, width / 2 + (int)(width / 3 * Math.Sin(i * Math.PI / 6)) - (int)GDI.MeasureString("" + i, myFont).Width / 2,
                  height / 2 - (int)(height / 3 * Math.Cos(i * Math.PI / 6)) - (int)GDI.MeasureString("" + i, myFont).Height / 2);
            }
        }

        void Timer_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}
