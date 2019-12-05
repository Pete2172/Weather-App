using Microsoft.Maps.MapControl.WPF;
using Microsoft.Maps.MapControl.WPF.Core;
using System;
using System.Windows;
using System.Windows.Controls;



namespace WeatherApp
{

    public class MyTileSource : TileSource
    {
        private string _baseTileURL;

        public MyTileSource(string mode)
        {
            _baseTileURL = "https://tile.openweathermap.org/map/" + mode + "/{2}/{0}/{1}.png?appid=6d3a41189563209a62df88fc160e27eb";
        }
        public override Uri GetUri(int x, int y, int zoomLevel)
        {
            return new Uri(string.Format(_baseTileURL, x, y, zoomLevel));
        }
    }
    public partial class WeatherMap : UserControl
    {
        MapTileLayer layer;
        string map_type;
        Location loc;

        public WeatherMap()
        {
            InitializeComponent();
            layer = new MapTileLayer();
            loc = new Location() { Latitude = 0, Longitude = 0 };
            Map.Center = loc;
            Pin.Location = loc;
            map_type = "temp_new";
            Temp.IsChecked = true;
            AddTileLayers();
            Map.Children.Add(layer);
        }

        public void ChangeCenter(WeatherData data)
        {
            Map.Center = data.Coords;
            Pin.Location = data.Coords;
            AddTileLayers();
        }

        private void MapLoaded(object sender, RoutedEventArgs e)
        {

        }
        private void AddTileLayers()
        {
            MyTileSource tileSource = new MyTileSource(map_type);
            layer.TileSource = tileSource;
            layer.Opacity = 40;
        }

        private void Map_ViewChangeFrame(object sender, MapEventArgs e)
        {
            double zoom = Map.ZoomLevel;

            if (zoom > 1)
            {
                Map.ZoomLevel = 1;
            }
            if (zoom < 1)
            {
                Map.ZoomLevel = 1;
            }
        }

        private void CloudsChecked(object sender, RoutedEventArgs e)
        {
            map_type = "clouds_new";
            AddTileLayers();
        }

        private void TempChecked(object sender, RoutedEventArgs e)
        {
            map_type = "temp_new";
            AddTileLayers();
        }

        private void PrecChecked(object sender, RoutedEventArgs e)
        {
            map_type = "precipitation_new";
            AddTileLayers();
        }

        private void PressChecked(object sender, RoutedEventArgs e)
        {
            map_type = "pressure_new";
            AddTileLayers();
        }

        private void WindChecked(object sender, RoutedEventArgs e)
        {
            map_type = "wind_new";
            AddTileLayers();
        }
    }
}
