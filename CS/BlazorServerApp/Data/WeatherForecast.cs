using System;

namespace BlazorServerApp.Data
{
    public class WeatherForecast {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public bool Precipitates { get; set; }

        public string Summary { get; set; }

        public double TemperatureF => Math.Round((TemperatureC * 1.8 + 32), 2);
        public string WeatherType { get; set; }
    }
}
