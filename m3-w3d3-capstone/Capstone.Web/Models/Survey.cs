using Capstone.Web.DAL;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Sorry, Email Address is required, don't be anonymous")]
        public string EmailAddress { get; set; }

        //state varchar(30) not null,
        [Required(ErrorMessage = "The State field is required.")]
        public string State { get; set; }

        public static List<SelectListItem> States
        {
            get
            {
                return new List<SelectListItem>() {
                    new SelectListItem { Value = "", Text = "" },
                    new SelectListItem { Value = "AL", Text = "Alabama" },
                    new SelectListItem { Value = "AK", Text = "Alaska" },
                    new SelectListItem { Value = "AZ", Text = "Arizona" },
                    new SelectListItem { Value = "AR", Text = "Arkansas" },
                    new SelectListItem { Value = "CA", Text = "California" },
                    new SelectListItem { Value = "CO", Text = "Colorado" },
                    new SelectListItem { Value = "CT", Text = "Connecticut" },
                    new SelectListItem { Value = "DE", Text = "Delaware" },
                    new SelectListItem { Value = "FL", Text = "Florida" },
                    new SelectListItem { Value = "GA", Text = "Georgia" },
                    new SelectListItem { Value = "HI", Text = "Hawaii" },
                    new SelectListItem { Value = "ID", Text = "Idaho" },
                    new SelectListItem { Value = "IL", Text = "Illinois" },
                    new SelectListItem { Value = "IN", Text = "Indiana" },
                    new SelectListItem { Value = "IA", Text = "Iowa" },
                    new SelectListItem { Value = "KS", Text = "Kansas" },
                    new SelectListItem { Value = "KY", Text = "Kentucky" },
                    new SelectListItem { Value = "LA", Text = "Louisiana" },
                    new SelectListItem { Value = "ME", Text = "Maine" },
                    new SelectListItem { Value = "MD", Text = "Maryland" },
                    new SelectListItem { Value = "MA", Text = "Massachusetts" },
                    new SelectListItem { Value = "MI", Text = "Michigan" },
                    new SelectListItem { Value = "MN", Text = "Minnesota" },
                    new SelectListItem { Value = "MS", Text = "Mississippi" },
                    new SelectListItem { Value = "MO", Text = "Missouri" },
                    new SelectListItem { Value = "MT", Text = "Montana" },
                    new SelectListItem { Value = "NC", Text = "North Carolina" },
                    new SelectListItem { Value = "ND", Text = "North Dakota" },
                    new SelectListItem { Value = "NE", Text = "Nebraska" },
                    new SelectListItem { Value = "NV", Text = "Nevada" },
                    new SelectListItem { Value = "NH", Text = "New Hampshire" },
                    new SelectListItem { Value = "NJ", Text = "New Jersey" },
                    new SelectListItem { Value = "NM", Text = "New Mexico" },
                    new SelectListItem { Value = "NY", Text = "New York" },
                    new SelectListItem { Value = "OH", Text = "Ohio" },
                    new SelectListItem { Value = "OK", Text = "Oklahoma" },
                    new SelectListItem { Value = "OR", Text = "Oregon" },
                    new SelectListItem { Value = "PA", Text = "Pennsylvania" },
                    new SelectListItem { Value = "RI", Text = "Rhode Island" },
                    new SelectListItem { Value = "SC", Text = "South Carolina" },
                    new SelectListItem { Value = "SD", Text = "South Dakota" },
                    new SelectListItem { Value = "TN", Text = "Tennessee" },
                    new SelectListItem { Value = "TX", Text = "Texas" },
                    new SelectListItem { Value = "UT", Text = "Utah" },
                    new SelectListItem { Value = "VT", Text = "Vermont" },
                    new SelectListItem { Value = "VA", Text = "Virginia" },
                    new SelectListItem { Value = "WA", Text = "Washington" },
                    new SelectListItem { Value = "WV", Text = "West Virginia" },
                    new SelectListItem { Value = "WI", Text = "Wisconsin" },
                    new SelectListItem { Value = "WY", Text = "Wyoming" }
                };
            }
        }

        //activityLevel varchar(100) not null,
        [Required(ErrorMessage = "The Activity Level field is required.")]
        public string ActivityLevel { get; set; }

        public static List<SelectListItem> ActivityLevels
        {
            get
            {
                return new List<SelectListItem>()
                {
                    new SelectListItem { Value = "", Text = "" },
                 new SelectListItem{Text="Inactive",Value="1"},
                 new SelectListItem{Text="Sedentary",Value="2"},
                 new SelectListItem{Text="Active",Value="3"},
                 new SelectListItem{Text="Extremely Active",Value="4"},

                };
            }
        }
        private ISurveyDAL surveyDAL;

        public List<Survey> getAllSurveySql()
        {
            surveyDAL = new SurveySqlDAL();
            return surveyDAL.getAllSurvey();
        }


        //public List<Survey> getAllSurveyJoinParkSql()
        //{
        //    surveyDAL = new SurveySqlDAL();
        //    return surveyDAL.getAllSurveyByPark();
        //}

    }
}