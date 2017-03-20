using Capstone.Web.DAL;
using Capstone.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Transactions;

namespace Capstone.Web.Tests.DAL
{
    [TestClass]
    public class ParkSqlDALTests
    {
        private string connectionString = @"Data Source=DESKTOP-58F8CH1\SQLEXPRESS;Initial Catalog=ParkDB;Integrated Security=True";
        //private string connectionString = @"Data Source=DESKTOP-U3MOBAH\SS;Initial Catalog=ParkDB;Integrated Security=True";

        private const string getAllParkSqlCommand = "SELECT * FROM park";
        private const string getParkIdSqlCommand = "SELECT * FROM park WHERE parkCode= @parkCode";
        private TransactionScope tran;

        [TestInitialize]
        public void initializer()
        {
            tran = new TransactionScope();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(getAllParkSqlCommand, conn);
                    int rowAffected = command.ExecuteNonQuery();
                    command = new SqlCommand(getParkIdSqlCommand, conn);
                    command.Parameters.AddWithValue("@parkCode", "ENP");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [TestCleanup]
        public void cleanup()
        {
            tran.Dispose();
        }

        [TestMethod]
        public void ParkSqlDAL_GetAllParks_Test()
        {
            //Arrange
            IParkDAL parkDAL = new ParkSqlDAL();
            //Act
            List<Park> allParks = parkDAL.getAllParksData();

            //Assert
            Assert.IsNotNull(parkDAL);
            Assert.IsNotNull(allParks);
            Assert.AreEqual(10, allParks.Count);
        }

        [TestMethod]
        public void ParkSqlDAL_GetParkByParkCode_Test()
        {
            //Arrange
            IParkDAL parkDAL = new ParkSqlDAL();
            //Act
            Park affectedPark = parkDAL.getParkIdData("ENP");

            //Assert
            Assert.IsNotNull(parkDAL);
            Assert.IsNotNull(affectedPark);
            Assert.AreEqual("Tropical", affectedPark.Climate);
            Assert.AreEqual("Marjory Stoneman Douglas", affectedPark.InspirationalQuoteSource);
        }
    }
}