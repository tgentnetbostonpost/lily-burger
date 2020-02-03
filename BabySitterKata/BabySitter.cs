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
            TimeSpan validEndTime = DateTime.Parse("4:00 AM").TimeOfDay;

            if (startTime >= validStartTime)
                {
                    return true;
                }
          
            return false;

        }
    }
}
