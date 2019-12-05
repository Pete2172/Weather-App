using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WeatherApp
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        private WeatherData dat;
        private BackgroundWorker worker;
        private string city_name="";
        private string default_name;

        public MainWindow()
        {
            InitializeComponent();
            InitTimer();
            InitBackGroundWorker();
            dat = new WeatherData();
            default_name = dat.GetNameOfTheCityByIP();
        }
        private void InitBackGroundWorker()
        {
            worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(AppRun);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(AppWorkFinishing);
        }
        private void InitTimer()
        {
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(TimerEvent);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }
        private void TimerEvent(object sender, EventArgs e)
        {
            worker.RunWorkerAsync();
        }
        private void AppRun(object sender, DoWorkEventArgs e)
        {
            timer.Stop();
            if(city_name == "")
            {
                city_name = default_name;
                timer.Interval = new TimeSpan(0, 20, 0);
            }
            this.Dispatcher.Invoke(() =>
            {
                if (dat.DownloadWeatherData(city_name) == true)
                {
                    datDisp.SendNewData(dat);
                    weatherMap.ChangeCenter(dat);
                }
                else
                {
                    ShowMessageBox(MessageBoxImage.Error, "Something went wrong with downloading weather data. Check your internet connection or check name of the city.");
                }
            });
        }
        private void AppWorkFinishing(object sender, EventArgs e)
        {
            timer.Start();
        }
        private void ShowMessageBox(MessageBoxImage imag, string text)
        {
            switch (imag)
            {
                case MessageBoxImage.Error:
                    MessageBox.Show(text, "Error!", MessageBoxButton.OK, imag);
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            city_name = TextBox.Text;
            worker.RunWorkerAsync();
        }

        private void Default_Click(object sender, RoutedEventArgs e)
        {
            city_name = default_name;
            worker.RunWorkerAsync();
        }
    }
}
