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

namespace WPF_Selft_Test3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double lastNumber, result;

        public MainWindow()
        {
            InitializeComponent();
            BtnAc.Click += BtnAc_Click;
            BtnMinPlus.Click += BtnMinPlus_Click;
            BtnPercentage.Click += BtnPercentage_Click;
            BtnEquals.Click += BtnEquals_Click;
        }

        private void BtnEquals_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnPercentage_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(ResultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber / 100;
                ResultLabel.Content = lastNumber.ToString();
            }
        }

        private void BtnMinPlus_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(ResultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber * -1;
                ResultLabel.Content = lastNumber.ToString();
            }
        }

        private void BtnAc_Click(object sender, RoutedEventArgs e)
        {
            ResultLabel.Content = "0";
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            int selectedValue = Convert.ToInt32(((Button)sender).Content.ToString());
            MessageBox.Show($"Pressed Button Is: {selectedValue}");

            if (ResultLabel.Content.ToString() == "0")
            {
                ResultLabel.Content = $"{selectedValue}";
            }
            else
            {
                ResultLabel.Content = $"{ResultLabel.Content}{selectedValue}";
            }
        }
    }
}
