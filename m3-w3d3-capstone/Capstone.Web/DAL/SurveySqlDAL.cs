using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public class SurveySqlDAL : ISurveyDAL
    {
        // private string connectionString = @"Data Source=DESKTOP-58F8CH1\SQLEXPRESS;Initial Catalog=ParkDB;Integrated Security=True";
        private string connectionString = @"Data Source=DESKTOP-U3MOBAH\SS;Initial Catalog=ParkDB;Integrated Security=True";

        private const string getAllSurveySqlCommand = "SELECT* FROM survey_result;";
        private const string addNewSurveySqlCommand = @"INSERT INTO survey_result ([parkCode],[emailAddress],[state],[activityLevel]) VALUES(@ParkCode,@EmailAddress,@State,@ActivityLevel)";

        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }

        public static string AddNewSurveySqlCommand => addNewSurveySqlCommand;

        public List<Survey> getAllSurvey()
        {
            List<Survey> allSurveys = new List<Survey>();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(getAllSurveySqlCommand, conn);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Survey currentSurvey = new Survey();
                        currentSurvey.ParkCode = Convert.ToString(reader["parkCode"]);
                        currentSurvey.ActivityLevel = Convert.ToString(reader["activityLevel"]);
                        currentSurvey.EmailAddress = Convert.ToString(reader["emailAddress"]);
                        currentSurvey.State = Convert.ToString(reader["state"]);
                        currentSurvey.SurveyId = Convert.ToInt32(reader["surveyId"]);
                        allSurveys.Add(currentSurvey);
                    }
                }
                return allSurveys;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool addNewSurvey(Survey newSurvey)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(AddNewSurveySqlCommand, conn);
                    command.Parameters.AddWithValue("@ParkCode", newSurvey.ParkCode);
                    command.Parameters.AddWithValue("@ActivityLevel", newSurvey.ActivityLevel);
                    command.Parameters.AddWithValue("@EmailAddress", newSurvey.EmailAddress);
                    command.Parameters.AddWithValue("@State", newSurvey.State);
                    int rowAffected = command.ExecuteNonQuery();

                    return rowAffected > 0;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}