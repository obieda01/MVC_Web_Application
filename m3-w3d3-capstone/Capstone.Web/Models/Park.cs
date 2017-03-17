using Capstone.Web.DAL;
using System.Collections.Generic;

namespace Capstone.Web.Models
{
    public class Park
    {
        private string parkCode;
        private string parkName;
        private string state;
        private int acreage;
        private int elevationInFeet;
        private float milesOfTrail;

        //parkCode varchar(10) not null,
        public string ParkCode
        {
            get { return parkCode; }
            set { parkCode = value; }
        }

        //parkName varchar(200) not null,
        public string ParkName
        {
            get { return parkName; }
            set { parkName = value; }
        }

        //state varchar(30) not null,
        public string State
        {
            get { return state; }
            set { state = value; }
        }

        //   acreage int not null,
        public int Acreage
        {
            get { return acreage; }
            set { acreage = value; }
        }

        //   elevationInFeet int not null,
        public int ElevationInFeet
        {
            get { return elevationInFeet; }
            set { elevationInFeet = value; }
        }

        //   milesOfTrail real not null,
        public float MilesOfTrail
        {
            get { return milesOfTrail; }
            set { milesOfTrail = value; }
        }

        //   numberOfCampsites int not null,
        public int NumberOfCampsites { get; set; }

        //   climate varchar(100) not null,
        public string Climate { get; set; }

        //yearFounded int not null,
        public int YearFounded { get; set; }

        //   annualVisitorCount int not null,
        public int AnnualVisitorCount { get; set; }

        //   inspirationalQuote varchar(max) not null,
        public string InspirationalQuote { get; set; }

        //inspirationalQuoteSource varchar(200) not null,
        public string InspirationalQuoteSource { get; set; }

        //parkDescription varchar(max) not null,
        public string ParkDescription { get; set; }

        //entryFee int not null,
        public int EntryFee { get; set; }

        //   numberOfAnimalSpecies int not null,
        public int NumberOfAnimalSpecies { get; set; }

        public Park()
        {
        }

        private IParkDAL parkDAL;

        public List<Park> getAllParkSql()
        {
            parkDAL = new ParkSqlDAL();
            return parkDAL.getAllParksData();
        }
    }
}