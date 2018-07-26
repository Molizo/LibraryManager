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
using System.Windows.Shapes;
using System.IO;

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