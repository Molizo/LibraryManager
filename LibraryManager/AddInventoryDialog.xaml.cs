using System.IO;
using System.Windows;

namespace LibraryManager
{
    /// <summary>
    /// Interaction logic for AddInventoryDialog.xaml
    /// </summary>
    public partial class AddInventoryDialog : Window
    {
        public AddInventoryDialog()
        {
            InitializeComponent();
        }

        private void AddItemButton_Click(object sender, RoutedEventArgs e)
        {
            string oldInventoryFile = File.ReadAllText("inventory.inv");
            string inventoryFile = oldInventoryFile + System.Environment.NewLine +
                                   TitleTextBox.Text + "|" +
                                   AuthorTextBox.Text + "|" +
                                   PublisherTextBox.Text + "|" +
                                   TypeTextBox.Text + "|" +
                                   ISBNTextBox.Text + "|" +
                                   PriceTextBox.Text + "|" +
                                   "Out of stock";
            File.WriteAllText("inventory.inv", inventoryFile);
            this.Close();
        }
    }
}