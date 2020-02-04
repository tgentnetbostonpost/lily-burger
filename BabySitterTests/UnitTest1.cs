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
            double hours = 8.23;

            if (hours % 1 > 0)
            {
                hours = (int)hours;
            }

            Assert.AreEqual(0, sitter.PayRoundedToFullHour(hours));
        }

        [TestMethod]
        public void StartTimeBeforeEndTime()
        {
            //test start time before midnight
            DateTime startTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 7, 20, 29);
            DateTime endTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 11, 20, 29);
            Assert.IsTrue(sitter.StartTimeBeforeEndTime(startTime,endTime));

            //test start time after midnight
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


        [TestMethod]
        public void FamilyATotalPay()
        {
            //Family A pays $15 per hour before 11pm, and $20 per hour the rest of the night
            //Starts at 6:23 pm ends at 2 am 
            DateTime startTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 18, 23, 00);
            DateTime endTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day + 1, 2, 20, 29);

            Assert.IsTrue(sitter.AllowableWorkHours(startTime, endTime));
            Assert.AreEqual(5, sitter.HoursBefore11PM(startTime,endTime));
            Assert.AreEqual(3, sitter.HoursAfter11PM(startTime, endTime));

            int hoursBeforeElevenPM = 5;
            int hoursAferElevenPM = 3;

            Assert.AreEqual(sitter.FamilyARateBefore11PM * hoursBeforeElevenPM, sitter.HoursBefore11PM(startTime, endTime) * sitter.FamilyARateBefore11PM);
            Assert.AreEqual(sitter.FamilyARateAfter11PM * hoursAferElevenPM, sitter.HoursAfter11PM(startTime, endTime) * sitter.FamilyARateAfter11PM);

            Assert.AreEqual(135, sitter.TotalPayFamilyA(hoursBeforeElevenPM, hoursAferElevenPM));



        }


    }
}
