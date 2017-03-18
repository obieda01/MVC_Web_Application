using Capstone.Web.Models;
using System.Collections.Generic;

namespace Capstone.Web.DAL
{
    public interface ISurveyDAL
    {
        List<Survey> getAllSurvey();
        bool addNewSurvey(Survey newSurvey);
        Dictionary<string, ParkSurvey> getSurveyByPark(string parkCode);
        string activityLevelByPark(string parkCode);
    }
}