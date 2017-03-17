using Capstone.Web.DAL;
using Capstone.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult ParkList()
        {
            IParkDAL DAL = new ParkSqlDAL();
            List<Park> model = DAL.getAllParksData();
            return View("ParkList", model);
        }

        public ActionResult ParkDetails(string id)
        {
            IParkDAL DAL = new ParkSqlDAL();
            List<Park> ParkList = DAL.getAllParksData();
            Park model = null;

            foreach (Park p in ParkList)
            {
                if (id == p.ParkCode)
                {
                    model = p;
                }
            }
            return View("ParkDetails", model);
        }

        public ActionResult Weather(string id)
        {
            IParkDAL DAL = new ParkSqlDAL();
            List<Park> ParkList = DAL.getAllParksData();
            List<Weather> weather = new List<Weather>();
            foreach (Park p in ParkList)
            {
                if (id == p.ParkCode)
                {
                    IWeatherDAL thisDAL = new WeatherSqlDAL();
                    weather = thisDAL.getWeatherByParkCode(p.ParkCode);
                    return View("Weather", weather);
                }
            }
            return View("Weather", weather);
        }
    }
}