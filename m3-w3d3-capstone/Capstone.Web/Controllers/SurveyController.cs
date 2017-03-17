using Capstone.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using Capstone.Web.DAL;

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

            return View("SurveyList", allSurvey);
        }
        public ActionResult AddSurvey()
        {
            ViewBag.visable = "hidden";
            return View("AddSurvey");
        }
        // GET: Survey/addSurvey
        [HttpPost]
        public ActionResult AddSurvey(Survey model)
        {

            ViewBag.visable = "hidden";
            if (!ModelState.IsValid)
            {
                ViewBag.visable = "";
                return View("AddSurvey");
            }
            ISurveyDAL newSurvey = new SurveySqlDAL();
            if (newSurvey.addNewSurvey(model))
            {
                return RedirectToAction("SurveyList","Survey");
            }
            else
            {
                return View("AddSurvey");
            }
        }
    }
}