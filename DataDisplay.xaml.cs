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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WeatherApp
{
    /// <summary>
    /// Logika interakcji dla klasy DataDisplay.xaml
    /// </summary>
    public partial class DataDisplay : UserControl
    {
        private BitmapImage wind_img;
        private RotateTransform trans;
        public DataDisplay()
        {
            InitializeComponent();
            trans = new RotateTransform();
            wind_img = new BitmapImage();
        }
        public void SendNewData(WeatherData handler)
        {
            Temp.Content = handler.Temp;
            Humidity.Content = handler.Humidity;
            City_Name.Content = handler.Name + " " + handler.Country;
            Status.Content = handler.Status;
            Date.Content = handler.Time;
            SetDate.Content = handler.Sunset;
            RiseDate.Content = handler.Sunrise;
            Pressure.Content = handler.Pressure;
            WindSpeed.Content = handler.Wind_Speed;
            StatusImage.Source = handler.Imag;
            trans.Angle = handler.Wind_Deg;
            trans.CenterX = WindImage.ActualWidth / 2;
            trans.CenterY = WindImage.ActualHeight / 2;
            
            WindImage.RenderTransform = trans; 


        }
    }
}
