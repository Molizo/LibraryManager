using System;
using System.Windows;

namespace LibraryManager
{
    /// <summary>
    /// Interaction logic for StockModifyDialog.xaml
    /// </summary>
    public partial class StockModifyDialog : Window
    {
        public StockModifyDialog()
        {
            InitializeComponent();
        }

        private void OutOfStockButton_Click(object sender, RoutedEventArgs e)
        {
            StockValueTextBox.Text = "Out of stock";
            this.Close();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (StockValueTextBox.Text != String.Empty)
                StockValueTextBox.Text = Convert.ToUInt32(StockValueTextBox.Text).ToString();
            else
                StockValueTextBox.Text = "Out of stock";
            this.Close();
        }

        private void DigitalDistributionButton_Click(object sender, RoutedEventArgs e)
        {
            StockValueTextBox.Text = "Digital Distribution";
            this.Close();
        }
    }
}