using System;
using System.Collections.Generic;
using System.Windows;

namespace UsingElementsWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> PhoneNumbers = new List<String>();
        System.Windows.Forms.SaveFileDialog aDialog;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.MaskedTextBox aBox;
            aBox = (System.Windows.Forms.MaskedTextBox)windowsFormsHost1.Child;
            PhoneNumbers.Add(aBox.Text);
            aBox.Clear();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            aDialog = new System.Windows.Forms.SaveFileDialog();
            aDialog.Filter = "Text Files | *.txt";
            aDialog.ShowDialog();
            System.IO.StreamWriter myWriter = new
            System.IO.StreamWriter(aDialog.FileName, true);
            foreach (string s in PhoneNumbers)
                myWriter.WriteLine(s);
            myWriter.Close();
        }
    }
}
