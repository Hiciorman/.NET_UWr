using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3._2._2
{
    public partial class Form1 : Form
    {
        private delegate void ReadFileDelegate(string path);

        public Form1()
        {
            InitializeComponent();
            InitializeTreeView();
            InitializeProgressBar();
        }

        private void InitializeTreeView()
        {
            for (int i = 0; i < 10; i++)
            {
                treeView1.Nodes.Add(i.ToString());
                //TODO: Elements

            }
            for (int i = 11; i < 20; i++)
            {
                treeView1.Nodes[1].Nodes.Add(i.ToString());
            }
        }

        private void InitializeProgressBar()
        {
            toolStripStatusLabel1.Text = "Loading";
            progressBar1.Maximum = 500;
            progressBar1.Step = 10;
            new ReadFileDelegate(ReadFile).BeginInvoke("..\\..\\File.txt", null, null);
        }

        private void ReadFile(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                sr.ReadToEnd();
            }

            this.Invoke(new MethodInvoker(WorkDone));
        }

        private void WorkDone()
        {
            progressBar1.Style = ProgressBarStyle.Continuous;
            progressBar1.Value = 500;
            toolStripStatusLabel1.Text = "File loaded";
        }

        private void helloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello!");
        }

        private void hiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hi!");
        }

        private void goodmorningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Goodmorning!");
        }

        private void hollaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Holla!");
        }
    }
}
