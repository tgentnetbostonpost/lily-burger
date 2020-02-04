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

        public int HoursBefore11PM(DateTime startTime, DateTime endTime)
        {
            // no start time before  5 pm which rules out after midnight
            if (startTime.Date == DateTime.Today && startTime.Hour>=17)
            {
                return 23 - startTime.Hour;
            }
            else
            {
                return 0;
            }
        }

        public int HoursAfter11PM(DateTime startTime, DateTime endTime)
        {
            // end time is after 11 PM only valid up to 4 am
            if (endTime.Date == startTime.Date.AddDays(1))
            {
                return 5 - endTime.Hour;
            }
            else
            {
                return 0;
            }
        }

        public int TotalPayFamilyA(int hoursBeforeElevenPM, int hoursAferElevenPM)
        {
            return hoursBeforeElevenPM * FamilyARateBefore11PM + hoursAferElevenPM * FamilyARateAfter11PM;
        }
    }
}
