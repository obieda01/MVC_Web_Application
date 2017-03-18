using Capstone.Web.Models;
using System.Collections.Generic;

namespace Capstone.Web.DAL
{
    public interface IWeatherDAL
    {
        List<Weather> getWeatherByParkCode(string parkCode);
    }
}