using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

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
            this.Title = "Inventory Management | " + Properties.Settings.Default.libraryName + " | " + Properties.Settings.Default.libraryLocation;
        }

        private void saveItems()
        {
            string contents = String.Empty;
            foreach (inventoryItem item in items)
            {
                contents = contents + item.Title + "|" +
                                      item.Author + "|" +
                                      item.Publisher + "|" +
                                      item.Type + "|" +
                                      item.ISBN + "|" +
                                      item.Price + "|" +
                                      item.Stock + System.Environment.NewLine;
            }
            File.WriteAllText("inventory.inv", contents);
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
            filterItems(SearchBox.Text);
        }

        private void filterItems(string filter)
        {
            List<inventoryItem> filtered = new List<inventoryItem>();
            filter = filter.ToLower();
            foreach (inventoryItem item in items)
            {
                if (item.Title.ToLower().Contains(filter))
                    filtered.Add(item);
                else if (item.Author.ToLower().Contains(filter))
                    filtered.Add(item);
                else if (item.Publisher.ToLower().Contains(filter))
                    filtered.Add(item);
                else if (item.Type.ToLower().Contains(filter))
                    filtered.Add(item);
                else if (item.ISBN.ToLower().Contains(filter))
                    filtered.Add(item);
                else if (item.Price.ToLower().Contains(filter))
                    filtered.Add(item);
                else if (item.Stock.ToLower().Contains(filter))
                    filtered.Add(item);
            }
            InventoryDataGrid.ItemsSource = filtered;
        }

        private void AddItemButton_Click(object sender, RoutedEventArgs e)
        {
            AddInventoryDialog addInventoryDialog = new AddInventoryDialog();
            addInventoryDialog.ShowDialog();
            items.Clear();
            loadItems();
            InventoryDataGrid.ItemsSource = null;
            filterItems(SearchBox.Text);
        }

        private void StockItemButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                inventoryItem item = (inventoryItem)InventoryDataGrid.SelectedItem;
                int index = items.IndexOf(item);
                StockModifyDialog stockModifyDialog = new StockModifyDialog();
                stockModifyDialog.Title = "Modify Stock | " + items[index].Title;

                if (item.Stock != "Out of stock" && item.Stock != "Digital Distribution")
                    stockModifyDialog.StockValueTextBox.Text = item.Stock;
                else
                    stockModifyDialog.StockValueTextBox.Text = "0";

                stockModifyDialog.ShowDialog();

                if (stockModifyDialog.StockValueTextBox.Text != "0")
                    items[index].Stock = stockModifyDialog.StockValueTextBox.Text;
                else
                    items[index].Stock = "Out of stock";

                InventoryDataGrid.ItemsSource = null;
                filterItems(SearchBox.Text);
                saveItems();
            }
            catch
            {
                MessageBox.Show("Please select an item in the table!", "Warning!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void PriceModifyButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                inventoryItem item = (inventoryItem)InventoryDataGrid.SelectedItem;
                int index = items.IndexOf(item);
                PriceModifyDialog priceModifyDialog = new PriceModifyDialog();
                priceModifyDialog.Title = "Modify Price | " + items[index].Title;
                priceModifyDialog.ShowDialog();
                items[index].Price = priceModifyDialog.PriceValueTextBox.Text;
                InventoryDataGrid.ItemsSource = null;
                filterItems(SearchBox.Text);
                saveItems();
            }
            catch
            {
                MessageBox.Show("Please select an item in the table!", "Warning!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}