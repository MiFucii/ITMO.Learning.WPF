using System;
using System.Windows;

namespace RoutedEvent2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StackPanel_Click_1(object sender, RoutedEventArgs e)
        {
            FrameworkElement feSource = e.Source as FrameworkElement;
            double a = Double.Parse(txtBox.Text);
            switch (feSource.Name)
            {
                case "butAdd":
                    a += a;
                    break;
                case "butMult":
                    a *= a;
                    break;
                case "butSqrt":
                    a = Math.Sqrt(a);
                    break;
            }
            e.Handled = true;
            txtBox.Text = String.Format("{0:#.##}", a);

        }
    }
}
