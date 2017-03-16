using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using System.Web.Util;
using System.Transactions;
using System.Data.SqlClient;
using Capstone.Web.DAL;
using System.Collections.Generic;
using Capstone.Web.Models;

namespace Capstone.Web.Tests.DAL
{
    [TestClass]
    public class SurveySqlDALTests
    {
        // private string connectionString = @"Data Source=DESKTOP-58F8CH1\SQLEXPRESS;Initial Catalog=ParkDB;Integrated Security=True";
        private string connectionString = @"Data Source=DESKTOP-U3MOBAH\SS;Initial Catalog=ParkDB;Integrated Security=True";
        private const string getAllSurveySqlCommand = "SELECT* FROM survey_result;";
        private const string addNewSurveySqlCommand = @"INSERT INTO survey_result ([parkCode],[emailAddress],[state],[activityLevel]) VALUES(@ParkCode,@EmailAddress,@State,@ActivityLevel)";
        private int rowAffected = 0;

        TransactionScope tran;

        [TestInitialize]
        public void initializer()
        {
            tran = new TransactionScope();
            try
            {
                using (SqlConnection conn =new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(getAllSurveySqlCommand, conn);
                    command.ExecuteNonQuery();

                    command = new SqlCommand(addNewSurveySqlCommand, conn);
                    command.Parameters.AddWithValue("@parkCode", "ENP");
                    command.Parameters.AddWithValue("@ActivityLevel", "test");
                    command.Parameters.AddWithValue("@EmailAddress", "test");
                    command.Parameters.AddWithValue("@State", "test");
                    rowAffected = command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [TestCleanup]
        public void cleanup()
        {
            tran.Dispose();
        }

        [TestMethod]
        public void SurveySqlDAL_GetAllSurvey_Tests()
        {
            //Arrange
            SurveySqlDAL surveyDAL = new SurveySqlDAL();

            //Act
            List<Survey> allSurveies = surveyDAL.getAllSurvey();

            //Assert 
            Assert.IsNotNull(surveyDAL);
            Assert.IsNotNull(allSurveies);
            Assert.AreEqual(rowAffected, allSurveies.Count);
        }

        [TestMethod]
        public void SurveySqlDAL_AddNewSurvey_Tests()
        {
            //Arrange
            SurveySqlDAL surveyDAL = new SurveySqlDAL();
            //Survey newSurvey = new Survey();
            //newSurvey.ActivityLevel = "test";
            //newSurvey.EmailAddress = "test";
            //newSurvey.State = "test";
            //newSurvey.ParkCode = "ENP";
            ////Act
            //bool successAdding = surveyDAL.addNewSurvey(newSurvey);

            //Assert 
            //Assert.IsTrue(successAdding);
            Assert.IsNotNull(surveyDAL);
            Assert.AreEqual(rowAffected, surveyDAL.getAllSurvey().Count);
        }
    }
}
