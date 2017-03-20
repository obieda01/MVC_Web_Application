using Capstone.Web.DAL;
using Capstone.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home/Parklist
        public ActionResult ParkList()
        {
            Session["ParkList"] = "active";
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
                }
            }

            bool isFaranheight;
            Session["Tempature"] = Request.Params["Tempature"];
            if (Session["Tempature"] != null)
            {
                if (Session["Tempature"].ToString() == "F")
                {
                    isFaranheight = true;
                }
                else
                {
                    isFaranheight = false;
                }
            }
            else
            {
                isFaranheight = true;
            }
            // update to Faranheight or Celcius
            for (int i = 0; i < weather.Count; i++)
            {
                if (isFaranheight)
                {
                    if (weather[i].Tempature == "F")
                    {
                        continue;
                    }
                    else
                    {
                        weather[i].Tempature = "F";
                        weather[i].High = ChangeFaranheightToCelcius(weather[i].High, "F");
                        weather[i].Low = ChangeFaranheightToCelcius(weather[i].Low, "F");
                    }
                }
                else
                {
                    weather[i].Tempature = "C";
                    weather[i].High = ChangeFaranheightToCelcius(weather[i].High, "C");
                    weather[i].Low = ChangeFaranheightToCelcius(weather[i].Low, "C");
                }
            }

            return View("Weather", weather);
        }

        public int ChangeFaranheightToCelcius(double temp, string fTempOrCtemp)
        {
            double newTemp = 0.00;
            if (fTempOrCtemp.ToLower() == "c")
            {
                //(°F - 32)  x  5 / 9 = °C
                newTemp = ((temp - 32) * (5.0 / 9));
            }
            else if (fTempOrCtemp.ToLower() == "f")
            {
                //°C x  9 / 5 + 32 = °F
                newTemp = (temp * (9 / 5.0) + 32);
            }
            return (int)newTemp;
        }
    }
}