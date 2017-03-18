using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.DAL;

namespace Capstone.Web.Models
{
    public class ParkSurvey
    {
        public string ParkCode { get; set; }
        public string ParkName { get; set; }
        public string State { get; set; }
        public string ActivityLevel { get; set; }

        public List<KeyValuePair<string, ParkSurvey>> getAllPrakSuervey()
        {
            Dictionary<string, ParkSurvey> ParkSurveys = new Dictionary<string, ParkSurvey>();
            ISurveyDAL surveyDAL = new SurveySqlDAL();
            foreach (var item in new Park().getAllParkSql())
            {
                if (!ParkSurveys.ContainsKey(item.ParkCode))
                {
                    ParkSurvey parkSurvey = new ParkSurvey();
                    parkSurvey.ParkCode = item.ParkCode;
                    parkSurvey.ParkName = item.ParkName;
                    parkSurvey.State = item.State;
                    parkSurvey.ActivityLevel = surveyDAL.activityLevelByPark(item.ParkCode);
                    ParkSurveys.Add(item.ParkCode, parkSurvey);
                }
            }

            List<KeyValuePair<string, ParkSurvey>> myList = ParkSurveys.ToList();

            myList.Sort(
                delegate (KeyValuePair<string, ParkSurvey> pair1,
                KeyValuePair<string, ParkSurvey> pair2)
                {
                    return int.Parse( pair2.Value.ActivityLevel).CompareTo(int.Parse( pair1.Value.ActivityLevel));
                }
            );
            
            return myList;
        }
    }
}