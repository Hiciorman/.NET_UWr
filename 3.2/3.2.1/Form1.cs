using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3._2._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeCombo();
        }

        private void InitializeCombo()
        {
            comboBox1.Items.Add("3-letnie");
            comboBox1.Items.Add("3,5-letnie");
            comboBox1.Items.Add("4-letnie");
            comboBox1.Items.Add("4,5-letnie");
            comboBox1.Items.Add("5-letnie");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string checkBoxText = "";

            if (checkBox1.CheckState == CheckState.Checked)
            {
                checkBoxText += checkBox1.Text;
            }
            if (checkBox2.CheckState == CheckState.Checked)
            {
                checkBoxText += " " + checkBox2.Text;
            }
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(checkBoxText) || comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Uzupełnij dane!");
            }
            else
            {
                MessageBox.Show(String.Format("{0}\n{1}\n{2}\n{3}", textBox1.Text, textBox2.Text, comboBox1.SelectedItem, checkBoxText));
            }
        }
    }
}
