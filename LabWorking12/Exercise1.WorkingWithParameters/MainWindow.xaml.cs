using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WorkingWithParameters
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Title = Properties.Settings.Default.ApplicationName;
            this.Background = new System.Windows.Media.SolidColorBrush(
            Properties.Settings.Default.BackgroundColor);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (!(listBox1.SelectedItem == null))
            {
                String astring = ((ListBoxItem)listBox1.SelectedItem).Content.ToString();
                switch (astring)
                {
                    case "Red":
                        Properties.Settings.Default.BackgroundColor = Colors.Red;
                        break;
                    case "Blue":
                        Properties.Settings.Default.BackgroundColor = Colors.Blue;
                        break;
                    case "Green":
                        Properties.Settings.Default.BackgroundColor = Colors.Green;
                        break;
                    case "Tomato":
                        Properties.Settings.Default.BackgroundColor = Colors.Tomato;
                        break;
                }
                this.Background = new System.Windows.Media.SolidColorBrush(
                Properties.Settings.Default.BackgroundColor);
                Properties.Settings.Default.Save();
            }
        }
    }
}
