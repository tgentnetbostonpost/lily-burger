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

            Assert.AreEqual(5, sitter.FamilyAHoursBefore11PM(startTime));
            Assert.AreEqual(3, sitter.FamilyAHoursAfter11PM(startTime, endTime));

            int hoursBeforeElevenPM = 5;
            int hoursAferElevenPM = 3;

            Assert.AreEqual(sitter.FamilyARateBefore11PM * hoursBeforeElevenPM, sitter.FamilyAHoursBefore11PM(startTime) * sitter.FamilyARateBefore11PM);
            Assert.AreEqual(sitter.FamilyARateAfter11PM * hoursAferElevenPM, sitter.FamilyAHoursAfter11PM(startTime, endTime) * sitter.FamilyARateAfter11PM);

            Assert.AreEqual(135, sitter.TotalPayFamilyA(hoursBeforeElevenPM, hoursAferElevenPM));
        }

        [TestMethod]
        public void FamilyBTotalPay()
        {
            //Family B pays $12 per hour before 10pm, $8 between 10 and 12, and $16 the rest of the night
            //Starts at 6:23 pm ends at 2 am 
            DateTime startTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 18, 23, 00);
            DateTime endTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day + 1, 2, 20, 29);

            int hoursBeforeTenPM = 4;
            int hoursBetween10And12PM = 2;
            int hoursAFer12PM = 2;

            Assert.AreEqual(hoursBeforeTenPM, sitter.FamilyBHoursBefore10PM(startTime));
            Assert.AreEqual(hoursBetween10And12PM, sitter.FamilyBHoursBetween10And12PM(startTime, endTime));
            Assert.AreEqual(hoursAFer12PM, sitter.FamilyBHoursAfter12PM(startTime, endTime));

            Assert.AreEqual(96, sitter.TotalPayFamilyB(hoursBeforeTenPM, hoursBetween10And12PM, hoursAFer12PM));
        }


        [TestMethod]
        public void FamilyCTotalPay()
        {
            //Family C pays $21 per hour before 9pm, then $15 the rest of the night
            
            DateTime startTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 18, 23, 00);
            DateTime endTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day + 1, 2, 20, 29);

            int hoursBeforeNinePM = 3;
            int hoursAfterNinePM = 5;
  
            Assert.AreEqual(hoursBeforeNinePM, sitter.FamilyCHoursBeforeNinePM(startTime));
            Assert.AreEqual(hoursAfterNinePM, sitter.FamilyCHoursAfterNinePM(startTime, endTime));
  
            Assert.AreEqual(138, sitter.TotalPayFamilyC(hoursBeforeNinePM, hoursAfterNinePM));
        }


    }
}
