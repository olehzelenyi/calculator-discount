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

namespace calculator_discount
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void inputBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

            if (inputBox.Text == "Enter a value here...")
            {
                // Do nothing while the placeholder text is present
                return;
            }

            if (double.TryParse(inputBox.Text, out double value))
            {
                string discountInfo = "No Discount";
                double discountValue = value;

                if (value < 500)
                {
                    discountValue = 0;
                }
                else if (value >= 500 && value < 1000)
                {
                    discountInfo = "Discount 2.5%";
                    discountValue = value * 0.025;
                }
                else if (value >= 1000 && value < 1500)
                {
                    discountInfo = "Discount 5%";
                    discountValue = value * 0.05;
                }
                else if (value >= 1500 && value < 2500)
                {
                    discountInfo = "Discount 7.5%";
                    discountValue = value * 0.075;
                }
                else if (value >= 2500)
                {
                    discountInfo = "Discount 10%";
                    discountValue = value * 0.1;
                }

                resultText.Text = $"Updated Value: {value - discountValue:C2}";
                discountText.Text = discountInfo;
            }
            else
            {
                resultText.Text = "Invalid input";
                discountText.Text = "";
            }
        }

        private void inputBox_GotFocus(object sender, RoutedEventArgs e)
        {
            // Clear the placeholder text when the TextBox gains focus
            if (inputBox.Text == "Enter a value here...")
            {
                inputBox.Text = "";
            }
        }

    }
}
