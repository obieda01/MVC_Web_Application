using System;
using System.Transactions;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Models
{
    public class Survey
    {
        //surveyId int identity(1,1) not null,
        public int SurveyId { get; set; }

        //parkCode varchar(10) not null,
        public string ParkCode { get; set; }

        //emailAddress varchar(100) not null,
        public string EmailAddress { get; set; }

        //state varchar(30) not null,
        public string State { get; set; }

        //activityLevel varchar(100) not null,
        public string ActivityLevel { get; set; }
    }
}