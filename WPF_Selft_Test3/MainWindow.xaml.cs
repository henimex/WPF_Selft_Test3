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
        private double _lastNumber, _result;
        private SelectedOperator _selectedOperator;

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
            double newNumber;
            if (double.TryParse(ResultLabel.Content.ToString(), out newNumber))
            {
                switch (_selectedOperator)
                {
                    case SelectedOperator.Addition:
                        _result = SimpleMath.Add(_lastNumber, newNumber);
                        break;
                    case SelectedOperator.Subtraction:
                        _result = SimpleMath.Subs(_lastNumber, newNumber);
                        break;
                    case SelectedOperator.Multiplication:
                        _result = SimpleMath.Multiple(_lastNumber, newNumber);
                        break;
                    case SelectedOperator.Division:
                        _result = SimpleMath.Divide(_lastNumber, newNumber);
                        break;
                }

                ResultLabel.Content = _result.ToString();
            }
        }

        private void BtnPercentage_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(ResultLabel.Content.ToString(), out _lastNumber))
            {
                _lastNumber = _lastNumber / 100;
                ResultLabel.Content = _lastNumber.ToString();
            }
        }

        private void BtnMinPlus_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(ResultLabel.Content.ToString(), out _lastNumber))
            {
                _lastNumber = _lastNumber * -1;
                ResultLabel.Content = _lastNumber.ToString();
            }
        }

        private void BtnAc_Click(object sender, RoutedEventArgs e)
        {
            ResultLabel.Content = "0";
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            int selectedValue = Convert.ToInt32(((Button)sender).Content.ToString());
            //MessageBox.Show($"Pressed Button Is: {selectedValue}");

            if (ResultLabel.Content.ToString() == "0")
            {
                ResultLabel.Content = $"{selectedValue}";
            }
            else
            {
                ResultLabel.Content = $"{ResultLabel.Content}{selectedValue}";
            }
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(ResultLabel.Content.ToString(), out _lastNumber)) ResultLabel.Content = "0";

            if (sender == BtnMultiple) _selectedOperator = SelectedOperator.Multiplication;
            if (sender == BtnPlus) _selectedOperator = SelectedOperator.Addition;
            if (sender == BtnMinus) _selectedOperator = SelectedOperator.Subtraction;
            if (sender == BtnDivide) _selectedOperator = SelectedOperator.Division;
        }

        private void BtnComa_OnClick(object sender, RoutedEventArgs e)
        {
            if (!ResultLabel.Content.ToString().Contains(".")) ResultLabel.Content = $"{ResultLabel.Content}.";
        }
    }

    public enum SelectedOperator
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }

    public class SimpleMath
    {
        public static double Add(double number1, double number2)
        {
            return number1 + number2;
        }

        public static double Subs(double number1, double number2)
        {
            return number1 - number2;
        }

        public static double Multiple(double number1, double number2)
        {
            return number1 * number2;
        }

        public static double Divide(double number1, double number2)
        {
            if (number2 == 0)
            {
                MessageBox.Show("Divide by 0 is 0");
                return 0;
            }
            return number1 / number2;
        }
    }
}
