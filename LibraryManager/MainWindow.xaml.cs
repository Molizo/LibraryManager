using System;
using System.Windows;

namespace LibraryManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Title = "Library Manager | " + Properties.Settings.Default.libraryName + " | " + Properties.Settings.Default.libraryLocation;
        }

        public void InventoryButtonClick(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("INVENTORY");
            InventoryWindow inventoryWindow = new InventoryWindow();
            inventoryWindow.ShowDialog();
        }

        public void CustomersButtonClick(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("CUSTOMERS");
        }

        public void LendButtonClick(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("LEND");
        }

        public void SellButtonClick(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("SELL");
        }

        public void ReportsButtonClick(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("REPORTS");
        }

        public void OptionsButtonClick(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("OPTIONS");
            OptionsWindow optionsWindow = new OptionsWindow();
            optionsWindow.ShowDialog();
        }
    }
}