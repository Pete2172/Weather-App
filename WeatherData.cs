using Microsoft.Maps.MapControl.WPF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using static System.Net.Mime.MediaTypeNames;

namespace WeatherApp
{
    public class WeatherData
    {
        public Location Coords { get; private set; }
        public string Name { get; private set; }
        public string Country { get; private set; }
        public string Temp { get; private set; }
        public string Status { get; private set; }
        public string Pressure { get; private set; }
        public string Wind_Speed { get; private set; }
        public string Humidity { get; private set; }
        public double Wind_Deg { get; private set; }
        public BitmapImage Imag { get; private set; }
        public string Sunset { get; private set; }
        public string Sunrise { get; private set; }
        public string Time { get; private set; }
         
        public WeatherData()
        {
            Coords = new Location();
        }
        public string GetNameOfTheCityByIP()
        {
            IPAddress[] hostAddresses = Dns.GetHostAddresses("");

                foreach (IPAddress hostAddress in hostAddresses)
                {
                if (hostAddress.AddressFamily == AddressFamily.InterNetwork &&
                    !IPAddress.IsLoopback(hostAddress) &&
                    !hostAddress.ToString().StartsWith("169.254."))
                {
                    using (WebClient wc = new WebClient())
                    {
                        var htmlData = wc.DownloadData("http://ip-api.com/json/");
                        var result = Encoding.UTF8.GetString(htmlData);
                        dynamic stuff = JsonConvert.DeserializeObject(result);
                        return stuff.city.ToString();
                    }
                  
                }
                }
                return null; 
        }
        public bool DownloadWeatherData(string city_name)
        {
            WebClient wc = new WebClient();
            string jsonFile = "";
            string icon_name;
            try
            {
                jsonFile = wc.DownloadString("https://api.openweathermap.org/data/2.5/weather?q=" + city_name + "&APPID=6d3a41189563209a62df88fc160e27eb");   // copying website's json content to a string

                dynamic stuff = JsonConvert.DeserializeObject(jsonFile);
                Coords.Longitude = (double) stuff.coord.lon;
                Coords.Latitude = (double) stuff.coord.lat;
                Temp = ((int) stuff.main.temp - 273).ToString() + " °C";
                Pressure = (string)stuff.main.pressure + " hPa";
                Humidity = (string)stuff.main.humidity + " %";
                Name = city_name.ToUpper();
                Status = (string)stuff.weather[0].main;
                Wind_Speed = ((double) stuff.wind.speed*3.6).ToString() + " km/h";
                Wind_Deg = (double)stuff.wind.deg;
                Country = (string)stuff.sys.country;

                DateTime sunriseDateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);  
                sunriseDateTime = sunriseDateTime.AddSeconds((int) stuff.sys.sunrise); 
                Sunrise = sunriseDateTime.ToLocalTime().ToString("dddd, HH:mm");

                DateTime sunsetDateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                sunsetDateTime = sunsetDateTime.AddSeconds((int)stuff.sys.sunset);
                Sunset = sunsetDateTime.ToLocalTime().ToString("dddd, HH:mm");

                DateTime DateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                DateTime = DateTime.AddSeconds((int)stuff.dt);
                Time = DateTime.ToLocalTime().ToString("dddd, HH:mm");

                icon_name = (string)stuff.weather[0].icon;
                var fullFilePath = @"https://openweathermap.org/img/w/" + icon_name + ".png";

                Imag = new BitmapImage();
                Imag.BeginInit();
                Imag.UriSource = new Uri(fullFilePath, UriKind.Absolute);
                Imag.EndInit();
                return true;
            }
            catch (WebException)
            {
                return false;
            }
        }
    }
}
