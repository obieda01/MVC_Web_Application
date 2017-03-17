using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class ParkSurvey
    {
        public string ParkCode { get; set; }
        public string ParkName { get; set; }
        public string State { get; set; }
        public string ActivityLevel { get; set; }

        public Dictionary<string, ParkSurvey> getAllPrakSuervey()
        {
            Dictionary<string, ParkSurvey> ParkSurveys = new Dictionary<string, ParkSurvey>();

            foreach (var item in new Park().getAllParkSql())
            {
                if (!ParkSurveys.ContainsKey(item.ParkCode))
                {
                    ParkSurvey parkSurvey = new ParkSurvey();
                    parkSurvey.ParkCode = item.ParkCode;
                    parkSurvey.ParkName = item.ParkName;
                    parkSurvey.State = item.State;
                    parkSurvey.ActivityLevel = "0";
                    ParkSurveys.Add(item.ParkCode, parkSurvey);
                }
            }
            return ParkSurveys;

        }
    }
}