using Capstone.Web.Models;
using System.Collections.Generic;

namespace Capstone.Web.DAL
{
    public interface ISurveyDAL
    {
        List<Survey> getAllSurvey();
        bool addNewSurvey(Survey newSurvey);
        List<ParkSurvey> getSurveyByPark(string parkCode);
    }
}