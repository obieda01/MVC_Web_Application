using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Web.DAL;
using Capstone.Web.Models;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
        // GET: Survey
        public ActionResult Index()
        {
            return RedirectToAction("SurveyList");
        }
        // GET: Survey/
        public ActionResult SurveyList()
        {
            List<Survey> allSurvey = new Survey().getAllSurveySql();

            return View("SurveyList",allSurvey);
        }
    }
}