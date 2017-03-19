using Capstone.Web.DAL;
using System.Collections.Generic;

namespace Capstone.Web.Models
{
    public class Weather
    {
        //parkCode varchar(10) not null,
        public string ParkCode { get; set; }

        //fiveDayForecastValue int not null,
        public double FiveDayForecastValue { get; set; }

        //   low int not null,
        public double Low { get; set; }

        //   high int not null
        public int High { get; set; }

        //   forecast varchar(100) not null,
        public string Forecast { get; set; }
        public string Tempature { get; set; }

        private IWeatherDAL weatherDAL;

        public List<Weather> getFiveDaysWeather(string parkCode)
        {
            weatherDAL = new WeatherSqlDAL();
            return weatherDAL.getWeatherByParkCode(parkCode);
        }
    }
}