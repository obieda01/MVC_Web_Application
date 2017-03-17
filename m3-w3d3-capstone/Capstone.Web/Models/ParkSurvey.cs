using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class ParkSurvey
    {
        public String ParkCode { get; set; }
        public String ParkName { get; set; }
        public string State { get; set; }
        public int InactiveVotes { get; set; }
        public int SedentaryVotes { get; set; }
        public int ActiveVotes { get; set; }
        public int ExtremelyActiveVotes { get; set; }
    }
}