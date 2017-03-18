using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        public ActionResult Index()
        {
            return RedirectToAction("About");
        }
        // GET: About
        public ActionResult About()
        {
            return View("About");
        }
    }
}