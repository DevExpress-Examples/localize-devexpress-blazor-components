using BlazorClientApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorClientApp.Services {
    public class WeatherForecastService {
        Tuple<int, int>[] temperatureStatistic = new Tuple<int, int>[] {
            Tuple.Create(-15, -1),
            Tuple.Create(-12, -2),
            Tuple.Create(-6, 8),
            Tuple.Create(4, 14),
            Tuple.Create(11, 21),
            Tuple.Create(13, 23),
            Tuple.Create(18, 32),
            Tuple.Create(16, 26),
            Tuple.Create(10, 18),
            Tuple.Create(1, 11),
            Tuple.Create(-4, 6),
            Tuple.Create(-13, 1)
        };

        Tuple<int, string>[] ConditionsForSummary = new Tuple<int, string>[] {
            Tuple.Create( 28 , "Hot"),
            Tuple.Create( 14 , "Warm"),
            Tuple.Create( -9 , "Cold"),
            Tuple.Create( -80 , "Freezing")
        };

        private static string[] WeatherTypes = new[] {
            "Sunny", "Partly cloudy", "Cloudy", "Storm"
        };

        private List<WeatherForecast> CreateForecast() {
            var rng = new Random();
            DateTime startDate = DateTime.Now;

            int min = 0;
            int max = 0;
            int? temperatureC = null;

            return Enumerable.Range(1, 15).Select(index => {
                var day = startDate.AddDays(index);
                if (day.Month - startDate.AddDays(index - 1).Month != 0 || temperatureC == null) {
                    min = temperatureStatistic[day.Month - 1].Item1;
                    max = temperatureStatistic[day.Month - 1].Item2;
                    temperatureC = rng.Next(min, max);
                }
                else {
                    temperatureC = temperatureC + rng.Next(-3, 3);
                    temperatureC = Math.Max(temperatureC.Value, min);
                    temperatureC = Math.Min(temperatureC.Value, max);
                }
                int weatherTypes = rng.NextDouble() < 0.5 ? 0 : (rng.NextDouble() < 0.5 ? 1 : rng.NextDouble() < 0.5 ? 2 : 3);
                double feelTemper = temperatureC.Value - (weatherTypes - 1) * 3;
                return new WeatherForecast {
                    Date = day,
                    TemperatureC = temperatureC.Value,
                    Precipitates = rng.NextDouble() < weatherTypes * 0.3,
                    WeatherType = WeatherTypes[weatherTypes],
                    Summary = ConditionsForSummary.First(c => c.Item1 <= feelTemper).Item2
                };
            }).ToList();
        }
        private List<WeatherForecast> CreateDetailedForecast() {
            var rng = new Random();
            DateTime startDate = DateTime.Now.Date;
            return Enumerable.Range(1, 15).SelectMany(day => {
                var dayDate = startDate.AddDays(day);
                int avgTemp = rng.Next(-20, 55);
                int minTemp = Math.Max(-20, avgTemp - 10);
                int maxTemp = Math.Min(55, avgTemp + 10);
                return Enumerable.Range(0, 24).Select(hour => new WeatherForecast {
                    Date = dayDate.AddHours(hour),
                    TemperatureC = rng.Next(minTemp, maxTemp),
                    Summary = ConditionsForSummary[rng.Next(ConditionsForSummary.Length)].Item2,
                    WeatherType = WeatherTypes[rng.Next(WeatherTypes.Length)],
                    Precipitates = rng.Next(100) < 30
                });
            }).ToList();
        }

        private List<WeatherForecast> Forecasts { get; set; }
        private List<WeatherForecast> DetailedForecast { get; set; }
        public WeatherForecastService() {
            Forecasts = CreateForecast();
            DetailedForecast = CreateDetailedForecast();
        }
        public Task<IEnumerable<WeatherForecast>> GetForecastAsync(CancellationToken ct = default) {
            return Task.FromResult(Forecasts.AsEnumerable());
        }
        public Task<WeatherForecast[]> GetDetailedForecastAsync(CancellationToken ct = default) {
            return Task.FromResult(DetailedForecast.ToArray());
        }
        public Task<string[]> GetSummariesAsync(CancellationToken ct = default) {
            return Task.FromResult(ConditionsForSummary.Select(v => v.Item2).ToArray());
        }
        public Task<IEnumerable<string>> GetCloudinessAsync(CancellationToken ct = default) {
            return Task.FromResult(WeatherTypes.AsEnumerable());
        }
        WeatherForecast[] InsertInternal(WeatherForecast newValue) {
            var dataItem = new WeatherForecast();
            Update(dataItem, newValue);
            Forecasts.Insert(0, newValue);
            return Forecasts.ToArray();
        }
        public Task<WeatherForecast[]> Insert(WeatherForecast newValue) {
            return Task.FromResult(InsertInternal(newValue));
        }
        WeatherForecast[] RemoveInternal(WeatherForecast dataItem) {
            Forecasts.Remove(dataItem);
            return Forecasts.ToArray();
        }
        public Task<WeatherForecast[]> Remove(WeatherForecast dataItem) {
            return Task.FromResult(RemoveInternal(dataItem));
        }
        WeatherForecast[] UpdateInternal(WeatherForecast dataItem, WeatherForecast newValue) {
            dataItem.Date = newValue.Date;
            dataItem.Summary = newValue.Summary;
            dataItem.TemperatureC = newValue.TemperatureC;
            dataItem.WeatherType = newValue.WeatherType;
            dataItem.Precipitates = newValue.Precipitates;
            return Forecasts.ToArray();
        }
        public Task<WeatherForecast[]> Update(WeatherForecast dataItem, WeatherForecast newValue) {
            return Task.FromResult(UpdateInternal(dataItem, newValue));
        }
    }

}