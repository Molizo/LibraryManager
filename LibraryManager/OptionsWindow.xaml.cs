using System.Windows;

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
            if (Properties.Settings.Default.theme == "Dark")
                DarkTheme.IsChecked = true;
            else
                LightTheme.IsChecked = true;

            /*
            //NOT FULLY IMPLEMENTED - Theme the menu
            if (Properties.Settings.Default.theme == "Light")
            {
                this.Background = System.Windows.Media.Brushes.White;
                LibraryLocationTextBlock.Foreground = System.Windows.Media.Brushes.Black;
                LibraryNameTextBlock.Foreground = System.Windows.Media.Brushes.Black;
                ThemeTextBlock.Foreground = System.Windows.Media.Brushes.Black;
            }
            */
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.libraryName = LibraryNameTextBox.Text;
            Properties.Settings.Default.libraryLocation = LibraryLocationTextBox.Text;
            if (LightTheme.IsChecked == true)
                Properties.Settings.Default.theme = "Light";
            else
                Properties.Settings.Default.theme = "Dark";
            Properties.Settings.Default.Save();

            MessageBox.Show("The settings have been saved.\nPlease relaunch the application for them to take effect", "Settings saved", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }

        private void DarkTheme_Checked(object sender, RoutedEventArgs e)
        {
            LightTheme.IsChecked = false;
        }

        private void LightTheme_Checked(object sender, RoutedEventArgs e)
        {
            DarkTheme.IsChecked = false;
        }
    }
}