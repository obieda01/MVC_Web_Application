using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Web.DAL;
using Capstone.Web.Models;

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
        
    }
}