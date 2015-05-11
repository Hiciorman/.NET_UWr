using System.Windows.Forms;

namespace _3._2._4
{
    public partial class Form1 : Form
    {
        SmoothProgressBar bar;
     
        public Form1()
        {
            bar = new SmoothProgressBar();
            bar.Min = 0;
            bar.Max = 1500;
            bar.Value = 750;
            bar.X = 20;
            bar.Y = 100;

            this.Controls.AddRange(new Control[] { bar});
            InitializeComponent();
        }
    }
}
