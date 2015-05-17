using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3._2._5
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            CreateHelpProvider();
        }

        private void CreateHelpProvider()
        {
            helpProvider.SetShowHelp(this.textBox1, true);
            helpProvider.SetShowHelp(this.textBox2, true);
            helpProvider.SetShowHelp(this.textBox3, true);
            
            helpProvider.HelpNamespace = @"..\..\Help.chm";
            
            helpProvider.SetHelpKeyword(this.textBox1, "Login.htm");
            helpProvider.SetHelpKeyword(this.textBox2, "Name.htm");
            helpProvider.SetHelpKeyword(this.textBox3, "City.htm");



            helpProvider.SetHelpNavigator(this.textBox1, HelpNavigator.Topic);
            helpProvider.SetHelpNavigator(this.textBox2, HelpNavigator.Topic);
            helpProvider.SetHelpNavigator(this.textBox3, HelpNavigator.Topic);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(String.Format("Hello {0}({1})!\nFrom {2}", textBox1.Text, textBox2.Text, textBox3.Text));
        }
    }
}
