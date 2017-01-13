using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace FakeNews
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OrderPage : Page
    {
        private string _adult;
        private string _child;
        private string _night;
        private int cost;

        public OrderPage()
        {
            this.InitializeComponent();
        }

        private void Adult_Click(object sender, RoutedEventArgs e)
        {
            var selected = (MenuFlyoutItem)sender;
            _adult = selected.Text;
            displayResult();
        }

        private void Night_Click(object sender, RoutedEventArgs e)
        {
            var selected = (MenuFlyoutItem)sender;
            _night = selected.Text;
            displayResult();
        }

        private void Child_Click(object sender, RoutedEventArgs e)
        {
            var selected = (MenuFlyoutItem)sender;
            _child = selected.Text;
            displayResult();
        }

        private void displayResult()
        {
            if (_adult == "0" || String.IsNullOrEmpty(_adult))
            {
                ResultTextBlock.Text = "No adults ... No tour";
                return;
            }
            ResultTextBlock.Text = "Your booking : " + _adult + " adults ";

            if (_child != "0" && !String.IsNullOrEmpty(_child))
            {
                ResultTextBlock.Text += "\nand " + _child + " child";
            }

            if (_night != "0" && !String.IsNullOrEmpty(_night))
            {
                cost = ((Int32.Parse(_adult) * 100) + (Int32.Parse(_child) * 25)) * Int32.Parse(_night);
                ResultTextBlock.Text += "\nfor " + _night + " nights\nTotal Cost : $" + cost + "\nProceed to payment.";
                PayBtn.Content = "Pay";
            }
        }

        private void Pay_Click(object sender, RoutedEventArgs e)
        {
            ResultTextBlock.Text = "Thank you for payment";
            PayBtn.Content = "";
        }
    }
}
