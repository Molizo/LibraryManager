using System.Windows;

namespace LibraryManager
{
    /// <summary>
    /// Interaction logic for PriceModifyDialog.xaml
    /// </summary>
    public partial class PriceModifyDialog : Window
    {
        public PriceModifyDialog()
        {
            InitializeComponent();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            PriceValueTextBox.Text = PriceValueTextBox.Text.Replace(',', '.');
            this.Close();
        }
    }
}