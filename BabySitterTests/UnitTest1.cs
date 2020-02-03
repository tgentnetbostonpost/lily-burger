using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BabySitterKata;


namespace SitterTests
{
    [TestClass]
    public class BabySitterTests

    {
        BabySitter sitter = new BabySitter();

        [TestMethod]
        public void StartTimeNoEarlierThan500PM()
        {
            //starts no earlier than 5:00PM     
            DateTime startTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 17, 20, 29);
            Assert.IsTrue(sitter.ValidStartTime(startTime));

        }

        [TestMethod]
        public void EndTimeNoLaterThan400AM()
        {
            //leaves no later than 4:00AM 
            //Same day test 6 pm
            DateTime endTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 18, 20, 29);
            Assert.IsTrue(sitter.ValidEndTime(endTime));
            
            //After midnight test 2 AM
            endTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day+1, 2, 20, 29);
            Assert.IsTrue(sitter.ValidEndTime(endTime));
         
        }

        [TestMethod]
        public void OnlyBabysitsForOneFamilyPerNight()
        {
            int validNumOfFamilies = 1;
            Assert.AreEqual(1, sitter.OneFamilyPerNight(validNumOfFamilies));
        }

        [TestMethod]
        public void PayForFullHour ()
        {
            double hours = 8.00;
            Assert.AreEqual(0, sitter.PayRoundedUpToFullHour(hours));
        }

        [TestMethod]
        public void StartTimeBeforeEndTime()
        {
            //test before midnight
            DateTime startTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 7, 20, 29);
            DateTime endTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 11, 20, 29);
            Assert.IsTrue(sitter.StartTimeBeforeEndTime(startTime,endTime));

            //test after midnight
            startTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 1, 20, 29);
            endTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day+1, 3, 20, 29);
            Assert.IsTrue(sitter.StartTimeBeforeEndTime(startTime, endTime));

        }

        [TestMethod]
        public void AllowableWorkHours()
        { 
            //should be prevented from mistakes when entering times(e.g.end time before start time, or outside of allowable work hours)

            ///test end time before midnight
            DateTime startTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 17, 20, 29);
            DateTime endTime =   new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 23, 20, 29);
            Assert.IsTrue(sitter.AllowableWorkHours(startTime, endTime));

            //test end time after midnight
            startTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 17, 20, 29);
            endTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day+1, 2, 20, 29);
            Assert.IsTrue(sitter.AllowableWorkHours(startTime, endTime));

        }



    }
}
