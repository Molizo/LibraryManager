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

namespace LibraryManager
{
    /// <summary>
    /// Interaction logic for InventoryWindow.xaml
    /// </summary>
    public partial class InventoryWindow : Window
    {
        public InventoryWindow()
        {
            InitializeComponent();
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
        }
    }
}