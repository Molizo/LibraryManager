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
    /// Interaction logic for InventoryWindow.xaml
    /// </summary>
    public partial class InventoryWindow : Window
    {
        public class inventoryItem
        {
            public string Title { set; get; }
            public string Author { set; get; }
            public string Publisher { set; get; }
            public string Type { set; get; }
            public string ISBN { set; get; }
            public string Price { set; get; }
            public string Stock { set; get; }
        }

        private List<inventoryItem> items = new List<inventoryItem>();

        public InventoryWindow()
        {
            InitializeComponent();
            InventoryDataGrid.ItemsSource = items;
            loadItems();
        }

        private void loadItems()
        {
            if (File.Exists("inventory.inv"))
            {
                string[] lines = File.ReadAllLines("inventory.inv");
                foreach (string line in lines)
                {
                    inventoryItem item = new inventoryItem();
                    string[] contents = line.Split('|');
                    item.Title = contents[0];
                    item.Author = contents[1];
                    item.Publisher = contents[2];
                    item.Type = contents[3];
                    item.ISBN = contents[4];
                    item.Price = contents[5];
                    item.Stock = contents[6];
                    items.Add(item);
                }
                Console.WriteLine("Loaded inventory file!");
            }
            else
            {
                File.Create("inventory.inv");
                Console.WriteLine("No inventory file found! Creating one...");
            }
        }

        private void InventoryToolBar_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            foreach (FrameworkElement a in InventoryToolBar.Items)
            {
                ToolBar.SetOverflowMode(a, OverflowMode.Never);
            }
            var overflowGrid = InventoryToolBar.Template.FindName("OverflowGrid", InventoryToolBar) as FrameworkElement;
            if (overflowGrid != null)
            {
                overflowGrid.Visibility = Visibility.Collapsed;
            }
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<inventoryItem> filtered = new List<inventoryItem>();
            string filter = SearchBox.Text;
            foreach (inventoryItem item in items)
            {
                if (item.Title.Contains(filter))
                    filtered.Add(item);
                else if (item.Author.Contains(filter))
                    filtered.Add(item);
                else if (item.Publisher.Contains(filter))
                    filtered.Add(item);
                else if (item.Type.Contains(filter))
                    filtered.Add(item);
                else if (item.ISBN.Contains(filter))
                    filtered.Add(item);
                else if (item.Price.Contains(filter))
                    filtered.Add(item);
                else if (item.Stock.Contains(filter))
                    filtered.Add(item);
            }
            InventoryDataGrid.ItemsSource = filtered;
        }
    }
}