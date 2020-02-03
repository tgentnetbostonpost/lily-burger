using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BabySitterKata;


namespace SitterTests
{
    [TestClass]
    public class BabySitterTests

    {
        [TestMethod]
        public void StartTimeNoEarlierThan500PM()
        {
            //starts no earlier than 5:00PM
            //leaves no later than 4:00AM

            TimeSpan startTime = DateTime.Parse("7:00 PM").TimeOfDay;

            BabySitter sitter = new BabySitter();
            Assert.IsTrue(sitter.ValidStartTime(startTime));

        }
    }
}
