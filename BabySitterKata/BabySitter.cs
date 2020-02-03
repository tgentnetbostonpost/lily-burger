using System;
using System.Collections.Generic;
using System.Text;

namespace BabySitterKata
{
    public class BabySitter
    {
        public bool ValidStartTime(TimeSpan startTime)
        {
            TimeSpan validStartTime = DateTime.Parse("5:00 PM").TimeOfDay;

            if (startTime >= validStartTime)
                {
                    return true;
                }
            return false;
        }

        public bool ValidEndTime(TimeSpan endTime)
        {
            TimeSpan validEndTime = DateTime.Parse("4:00 AM").TimeOfDay;

            if (endTime <= validEndTime)
            {
                return true;
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

        public double PayRoundedUpToFullHour(double hours)
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

        public bool StartTimeBeforeEndTime(TimeSpan startTime, TimeSpan endTime)
        {

            if (startTime < endTime)
            {
                return true;
            }

            return false;
            
        }
    }
}
