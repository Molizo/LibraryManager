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
    /// Interaction logic for OptionsWindow.xaml
    /// </summary>
    public partial class OptionsWindow : Window
    {
        public OptionsWindow()
        {
            InitializeComponent();
            //Load all settings into their respective text boxes.
            LibraryNameTextBox.Text = Properties.Settings.Default.libraryName;
            LibraryLocationTextBox.Text = Properties.Settings.Default.libraryLocation;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.libraryName = LibraryNameTextBox.Text;
            Properties.Settings.Default.libraryLocation = LibraryLocationTextBox.Text;
            Properties.Settings.Default.Save();

            MessageBox.Show("The settings have been saved.\nPlease relaunch the application for them to take effect", "Settings saved", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
    }
}