using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Moravia.Shouter.Core.Tools
{
    public class DateTimeHelper
    {
        #region GetFriendlyElapsedTime( DateTime elapsedFrom, DateTime elapsedUntil )
        public static string GetFriendlyElapsedTime( DateTime elapsedFrom, DateTime elapsedUntil )
        {
                var elapsedTime = elapsedUntil.Subtract(elapsedFrom);

                //Commented years ago
                if (elapsedTime.TotalDays > 365)
                    return "Commented more than one year ago";

                //Commented months ago
                if (elapsedTime.TotalDays > 31)
                {
                    var monthsElapsed = Convert.ToInt32(Math.Floor(elapsedTime.TotalDays / 30.5));
                    var monthText = monthsElapsed == 1 ? "month" : "months";

                    return string.Format("Commented {0} {1} ago", monthsElapsed, monthText);
                }

                //Commented weeks ago
                if (elapsedTime.TotalDays >= 7.0)
                {
                    var weeksElapsed = Convert.ToInt32(Math.Floor(elapsedTime.TotalDays / 7));
                    var weeksText = weeksElapsed == 1 ? "week" : "weeks";

                    return string.Format("Commented {0} {1} ago", weeksElapsed, weeksText);
                }

                //Commented days ago
                if (elapsedTime.TotalDays > 2.0)
                    return "Commented " + elapsedTime.TotalDays.ToString() + " days ago";

                //Commented yesterday 
                if (elapsedTime.TotalDays > 1.0)
                    return "Commented yesterday";

                //Commented hous ago
                if (elapsedTime.TotalHours >= 1.0)
                {
                    var hoursElapsed = Convert.ToInt32(Math.Floor(elapsedTime.TotalHours));
                    var hoursText = hoursElapsed == 1 ? "hour" : "hours";

                    return string.Format("Commented {0} {1} ago", hoursElapsed, hoursText);
                }


                if (elapsedTime.TotalMinutes >= 1.0)
                {
                    //Commented minutes ago
                    var minutesElapsed = Convert.ToInt32(Math.Floor(elapsedTime.TotalMinutes));
                    var minutesText = minutesElapsed == 1 ? "minute" : "minutes";

                    return string.Format("Commented {0} {1} ago", minutesElapsed, minutesText);
                }
                else
                {
                    //Commented in the last minute ago
                    return "Commented a few seconds ago";
                }

            }
        #endregion
        #region GetFriendlyElapsedTime( DateTime elapsedFrom)
        public static string GetFriendlyElapsedTime( DateTime elapsedFrom)
        {
            return DateTimeHelper.GetFriendlyElapsedTime(elapsedFrom: elapsedFrom, elapsedUntil: DateTime.Now);
        }
        #endregion
    }
}
