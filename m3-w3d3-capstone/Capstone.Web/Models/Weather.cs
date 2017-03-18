using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Transactions;
using Capstone.Web.DAL;

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

        private  IWeatherDAL weatherDAL;

        public List<Weather> getFiveDaysWeather(string parkCode)
        {
            weatherDAL = new WeatherSqlDAL();
            return weatherDAL.getWeatherByParkCode(parkCode);
        }

    }
}