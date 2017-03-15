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
        private const string getParkIdSqlCommand = "SELECT * FROM park WHERE parkCode= @parkCode";

        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }



        public List<Survey> getAllSurvey()
        {
            List<Survey> allParks = new List<Survey>();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(getAllSurveySqlCommand, conn);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {

 

                        Survey currentSurvey=new Survey();
                        currentSurvey.s = Convert.ToInt32(reader["acreage"]);
                        currentSurvey.AnnualVisitorCount = Convert.ToInt32(reader["annualVisitorCount"]);
                        currentSurvey.Climate = Convert.ToString(reader["climate"]);
                        currentSurvey.ElevationInFeet = Convert.ToInt32(reader["elevationInFeet"]);
                        currentSurvey.InspirationalQuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]);
                        currentSurvey.MilesOfTrail = Convert.ToUInt32(reader["milesOfTrail"]);
                        currentSurvey.NumberOfAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"]);
                        currentSurvey.NumberOfCampsites = Convert.ToInt32(reader["numberOfCampsites"]);
                        currentSurvey.ParkCode = Convert.ToString(reader["parkCode"]);
                        currentSurvey.ParkName = Convert.ToString(reader["parkName"]);
                        currentSurvey.State = Convert.ToString(reader["state"]);
                        currentSurvey.YearFounded = Convert.ToInt32(reader["yearFounded"]);

                        allParks.Add(currentSurvey);
                    }
                }
                return allParks;
            }
            catch (Exception)
            {

                throw;
            }
            return new List<Survey>();
        }

        public void addNewSurvey(Survey newSurvey) { }
    }
}