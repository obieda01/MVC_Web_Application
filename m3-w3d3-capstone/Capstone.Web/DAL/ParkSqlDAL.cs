using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capstone.Web.DAL
{
    public class ParkSqlDAL : IParkDAL
    {
        private string connectionString = @"Data Source=DESKTOP-58F8CH1\SQLEXPRESS;Initial Catalog=ParkDB;Integrated Security=True";
        //private string connectionString = @"Data Source=DESKTOP-U3MOBAH\SS;Initial Catalog=ParkDB;Integrated Security=True";

        private const string getAllParkSqlCommand = "SELECT * FROM park order by state";

        private const string getParkIdSqlCommand = "SELECT * FROM park WHERE parkCode= @parkCode";

        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }

        public List<Park> getAllParksData()
        {
            List<Park> allParks = new List<Park>();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(getAllParkSqlCommand, conn);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Park currentPark = new Park();
                        currentPark.Acreage = Convert.ToInt32(reader["acreage"]);
                        currentPark.AnnualVisitorCount = Convert.ToInt32(reader["annualVisitorCount"]);
                        currentPark.Climate = Convert.ToString(reader["climate"]);
                        currentPark.ElevationInFeet = Convert.ToInt32(reader["elevationInFeet"]);
                        currentPark.InspirationalQuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]);
                        currentPark.InspirationalQuote = Convert.ToString(reader["inspirationalQuote"]);
                        currentPark.MilesOfTrail = Convert.ToUInt32(reader["milesOfTrail"]);
                        currentPark.NumberOfAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"]);
                        currentPark.NumberOfCampsites = Convert.ToInt32(reader["numberOfCampsites"]);
                        currentPark.ParkCode = Convert.ToString(reader["parkCode"]);
                        currentPark.ParkName = Convert.ToString(reader["parkName"]);
                        currentPark.ParkDescription = Convert.ToString(reader["parkDescription"]);
                        currentPark.State = Convert.ToString(reader["state"]);
                        currentPark.YearFounded = Convert.ToInt32(reader["yearFounded"]);

                        allParks.Add(currentPark);
                    }
                }
                return allParks;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Park getParkIdData(string parkCode)
        {
            Park currentPark = new Park();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(getParkIdSqlCommand, conn);
                    string sql = @"'" + parkCode + @"'";
                    command.Parameters.AddWithValue("@parkCode", parkCode);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        currentPark.Acreage = Convert.ToInt32(reader["acreage"]);
                        currentPark.AnnualVisitorCount = Convert.ToInt32(reader["annualVisitorCount"]);
                        currentPark.Climate = Convert.ToString(reader["climate"]);
                        currentPark.ElevationInFeet = Convert.ToInt32(reader["elevationInFeet"]);
                        currentPark.InspirationalQuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]);
                        currentPark.MilesOfTrail = Convert.ToUInt32(reader["milesOfTrail"]);
                        currentPark.NumberOfAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"]);
                        currentPark.NumberOfCampsites = Convert.ToInt32(reader["numberOfCampsites"]);
                        currentPark.ParkCode = Convert.ToString(reader["parkCode"]);
                        currentPark.ParkName = Convert.ToString(reader["parkName"]);
                        currentPark.State = Convert.ToString(reader["state"]);
                        currentPark.YearFounded = Convert.ToInt32(reader["yearFounded"]);
                    }
                }
                return currentPark;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}