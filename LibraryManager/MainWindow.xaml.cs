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
            this.Title = "Library manager | " + Properties.Settings.Default.libraryName + " | " + Properties.Settings.Default.libraryLocation;
        }

        public void InventoryButtonClick(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("INVENTORY");
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