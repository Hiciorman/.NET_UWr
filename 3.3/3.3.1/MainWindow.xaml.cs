using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _3._3._1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            foreach (var item in ComboBoxSource)
            {
                comboCykl.Items.Add(item);                
            }
        }

        private string[] comboBoxSource = { "3-letnie", "4-letnie", "5-letnie", "6-letnie" };

        public string[] ComboBoxSource
        {
            get { return comboBoxSource; }
            set { comboBoxSource = value; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(String.Format("{0}\n{1}\n{2}\n{3} {4}", txtNazwa.Text, txtAdres.Text, comboCykl.SelectedValue, (bool)checkBoxD.IsChecked ? checkBoxD.Content : "", (bool)checkBoxU.IsChecked ? checkBoxU.Content : ""));
        }

        private void buttonAnuluj_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
