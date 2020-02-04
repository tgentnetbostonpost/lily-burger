using System;
using System.Collections.Generic;
using System.Text;

namespace BabySitterKata
{
    public class BabySitter
    {

        public int FamilyARateBefore11PM
        {
            get { return 15; }
        }
        public int FamilyARateAfter11PM
        {
            get { return 20; }
        }

        public int FamilyBRateBefore10PM
        {
            get { return 12; }
        }
        public int FamilyBRateBetween10And12PM
        {
            get { return 8; }
        }
        public int FamilyBRateAfter12PM
        {
            get { return 16; }
        }

        public bool ValidStartTime(DateTime startTime)
        {
            TimeSpan validStartTime = DateTime.Parse("5:00 PM").TimeOfDay;
   
            if (startTime.Date == DateTime.Today)
            {
                if (startTime.TimeOfDay >= validStartTime)
                {
                    return true;
                }
            }        
            return false;
        }

        public bool ValidEndTime(DateTime endTime)
        {
            TimeSpan validEndTime = DateTime.Parse("4:00 AM").TimeOfDay;
            TimeSpan midnight = DateTime.Parse("11:59 PM").TimeOfDay;


            if (endTime.Date == DateTime.Today.Date)
            {
                if (endTime.TimeOfDay <= midnight)
                {
                    return true;
                }
            }
            else ///after midnight
            {
                if (endTime.TimeOfDay <= validEndTime)
                {
                    return true;
                }
            }
            return false;
        }


        public object OneFamilyPerNight(int numberOfFamilies)
        {
            if (numberOfFamilies == 1)
            {
                return 1;
            }
            return 0;
        }

        public double PayRoundedToFullHour(double hours)
        {
            if (hours % 1 > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public bool StartTimeBeforeEndTime(DateTime startTime, DateTime endTime)
        {
            TimeSpan midnight = DateTime.Parse("11:59 PM").TimeOfDay;

            // no start time before  5 pm which rules out after midnight
            if (startTime.Date == DateTime.Today)
            {
                if (startTime.TimeOfDay < endTime.TimeOfDay)
                {
                    return true;
                }
            }           
                return false;
        }

        public bool AllowableWorkHours(DateTime startTime, DateTime endTime)
        {
            if (ValidStartTime(startTime) && ValidEndTime(endTime))
            {
                return true;
            }
            return false;
        }

        public int FamilyAHoursBefore11PM(DateTime startTime)
        {
            // no start time before  5 pm which rules out after midnight
            if (startTime.Hour>=17)
            {
                return 23 - startTime.Hour;
            }
            else
            {
                return 0;
            }
        }

        public int FamilyAHoursAfter11PM(DateTime startTime, DateTime endTime)
        {
            int hours = 0;

            //get 1 hour for start time day
            if (startTime.Date < endTime.Date)
            {
                hours = 1;
            }

            //start time afer midnight
            if (startTime.Date.AddDays(1)==endTime.Date)
            {
                hours = hours + (4 - endTime.Hour);
            }

            return hours;
        }

        public int TotalPayFamilyA(int hoursBeforeElevenPM, int hoursAferElevenPM)
        {
            if (hoursBeforeElevenPM == 0) { hoursBeforeElevenPM = 1; }
            if (hoursAferElevenPM == 0) { hoursAferElevenPM = 1; }

            return (hoursBeforeElevenPM * FamilyARateBefore11PM) + (hoursAferElevenPM * FamilyARateAfter11PM);
        }

        public int FamilyBHoursBefore10PM(DateTime startTime)
        {
            int hours = 0;

            //same day
            if (startTime.Hour >= 17)
            {
                hours= 22 - startTime.Hour;
            }
            else
            {
                hours = 0; 
            }
            return hours;  
        }

        public int FamilyBHoursBetween10And12PM(DateTime startTime, DateTime endTime)
        {
            int totalHours = 0;

            //clocked in and out on same day
            if (startTime.Date==endTime.Date && startTime.Hour>17 && endTime.Hour >= 22)
            {
                totalHours=endTime.Hour - 22;
            }//clocked out next day
            else if (startTime.Date<endTime.Date && startTime.Hour >=17) 
            {
                totalHours = 2;
            }

            return totalHours;

        }

        public int FamilyBHoursAfter12PM(DateTime startTime, DateTime endTime)
        {
            int hours = 0;
            //same day
            if (startTime.Date == endTime.Date)
            {
                hours = 0;
            }
            else if (startTime.Date < endTime.Date && endTime.Hour<=4)
            {
                hours = endTime.Hour;
            }
            return hours;
        }

        public int TotalPayFamilyB(int hoursBeforeTenPM, int hoursBetween10And12PM, int hoursAFter12PM)
        {
            //account for zero
            if (hoursBeforeTenPM==0) { hoursBeforeTenPM = 1; }
            if (hoursBetween10And12PM == 0) { hoursBetween10And12PM = 1; }
            if (hoursAFter12PM == 0) { hoursAFter12PM = 1; }

            return (hoursBeforeTenPM*FamilyBRateBefore10PM) + (hoursBetween10And12PM*FamilyBRateBetween10And12PM) + (hoursAFter12PM * FamilyBRateAfter12PM);
        }
    }
}
