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
            return View("SurveyList", new ParkSurvey().getAllPrakSuervey());
        }
        public ActionResult AddSurvey()
        {

            ViewBag.visable = "hidden";
            return View("AddSurvey");
        }
        // GET: Survey/addSurvey
        [HttpPost]
        public ActionResult AddSurvey(Survey model, string id)
        {

            ViewBag.visable = "hidden";
            if (!ModelState.IsValid)
            {
                ViewBag.visable = "";
                return View("AddSurvey");
            }
            ISurveyDAL newSurvey = new SurveySqlDAL();
            model.ParkCode = id;
            if (newSurvey.addNewSurvey(model))
            {
                return RedirectToAction("SurveyList", "Survey");
            }
            else
            {
                return View("AddSurvey");
            }
        }
    }
}