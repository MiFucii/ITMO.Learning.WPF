using System.Windows;

namespace BackgroundWorker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        System.ComponentModel.BackgroundWorker aWorker = new System.ComponentModel.BackgroundWorker();
        public MainWindow()
        {
            InitializeComponent();
            aWorker.WorkerSupportsCancellation = true;
            aWorker.DoWork += aWorker_DoWork;
            aWorker.RunWorkerCompleted += aWorker_RunWorkerCompleted;
        }

        private void aWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            for (int i = 0; i <= 50; i++)
            {
                for (int j = 1; j <= 100000000; j++)
                {
                }
                if (aWorker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                UpdateDelegate update = new UpdateDelegate(UpdateLabel);
                label1.Dispatcher.BeginInvoke(
                System.Windows.Threading.DispatcherPriority.Normal, update, i);
            }
        }


        private void aWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (!(e.Cancelled))
                label2.Content = "Run Completed";
            else
                label2.Content = "Run Cancelled";
        }

        private delegate void UpdateDelegate(int i);
        private void UpdateLabel(int i)
        {
            label1.Content = "Cycles: " + i.ToString();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            aWorker.RunWorkerAsync();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            aWorker.CancelAsync();
        }
    }
}
