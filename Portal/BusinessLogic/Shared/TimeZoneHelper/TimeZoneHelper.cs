using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtomicArcade.ViewLogic.Shared.TimeZoneHelper
{
    public class TimeZoneHelper:ITimeZoneHelper
    {
        public DateTime GetUTCDateTime(DateTime dateTimeToConvert, TimeZoneInfo timeZone)
        {
            var offset = timeZone.GetUtcOffset(dateTimeToConvert);

            var convertedDate = dateTimeToConvert.ToUniversalTime() + offset;

            return convertedDate;

        }
    }
}
