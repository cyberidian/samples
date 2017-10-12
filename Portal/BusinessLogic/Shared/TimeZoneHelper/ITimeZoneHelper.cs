using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtomicArcade.ViewLogic.Shared.TimeZoneHelper
{
    public interface ITimeZoneHelper
    {
        DateTime GetUTCDateTime(DateTime dateToConvert, TimeZoneInfo timeZone);
    }
}
