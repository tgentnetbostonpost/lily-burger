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
            TimeSpan startTime = DateTime.Parse("7:00 PM").TimeOfDay;
            Assert.IsTrue(sitter.ValidStartTime(startTime));

        }

        [TestMethod]
        public void EndTimeNoEarlierThan400AM()
        {
            //leaves no later than 4:00AM
            TimeSpan endTime = DateTime.Parse("3:00 AM").TimeOfDay;
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



    }
}
