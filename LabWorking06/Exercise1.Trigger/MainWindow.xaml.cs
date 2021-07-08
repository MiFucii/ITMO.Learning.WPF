using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Trigger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        string nameFile = "username.txt";

        public MyWindow myWin { get; set; }

        bool isDataDirty = false;

        public MainWindow()
        {
            InitializeComponent();

            CommandBinding abinding = new CommandBinding();
            abinding.Command = CustomCommands.Launch;
            abinding.Executed += new ExecutedRoutedEventHandler(Launch_Handler);
            abinding.CanExecute += new CanExecuteRoutedEventHandler(LaunchEnabled_Handler);
            this.CommandBindings.Add(abinding);

            //lbl.Content = "Добрый день!";
            setBut.IsEnabled = false;
            retBut.IsEnabled = false;
            retBut.IsEnabled = false;
            Top = 25;
            Left = 25;
        }

        private void SetBut()
        {
            System.IO.StreamWriter sw = new System.IO.StreamWriter(nameFile);
            sw.WriteLine(setText.Text);
            sw.Close();
            retBut.IsEnabled = true;
            isDataDirty = false;
        }
        private void RetBut()
        {
            System.IO.StreamReader sr = new System.IO.StreamReader(nameFile);
            retLabel.Content = "Hi there, my dear " + sr.ReadToEnd();
            sr.Close();
            //retBut.IsEnabled = true;
            isDataDirty = false;
        }

        

        private void setText_TextChanged(object sender, TextChangedEventArgs e)
        {
            setBut.IsEnabled = true;
            isDataDirty = true;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.isDataDirty) 
            {
                string msg = "Данные были изменены, но не сохранены!\n Закрыть окно без сохранения?";
                MessageBoxResult result = MessageBox.Show(msg, "Контроль данных", MessageBoxButton.YesNo, MessageBoxImage.Warning); 
                if (result == MessageBoxResult.No) 
                {
                    e.Cancel = true; 
                } 
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
             

        private void Grid_Click(object sender, RoutedEventArgs e)
        {
            FrameworkElement feSource = e.Source as FrameworkElement;
            try
            {
                switch (feSource.Name)
                {
                    case "setBut":
                        SetBut();
                        break;
                    case "retBut":
                        RetBut();
                        break;
                }
                e.Handled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LaunchEnabled_Handler(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (bool)check.IsChecked;
        }

        private void Launch_Handler(object sender, ExecutedRoutedEventArgs e)
        {
            if (myWin == null)
                myWin = new MyWindow();
            myWin.Owner = this;
            var location = New_Win.PointToScreen(new Point(0, 0));
            myWin.Left = location.X + New_Win.Width;
            myWin.Top = location.Y;
            myWin.Show();
        }

    }
}
