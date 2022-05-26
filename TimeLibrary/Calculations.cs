using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeLibrary
{
    public class Calculations
    {
        /// <summary>
        /// Расписание
        /// </summary>
        /// <param name="startTimes"></param>
        /// <param name="durations"></param>
        /// <param name="beginWorkingTime"></param>
        /// <param name="endWorkingTime"></param>
        /// <param name="consultationTime"></param>
        /// <returns></returns>
        public static string[] AvailablePeriods(TimeSpan[] startTimes, int[] durations, TimeSpan beginWorkingTime, TimeSpan endWorkingTime, int consultationTime)
        {
            List<string> intervalList = new List<string>();

            TimeSpan nextDurationTime = new TimeSpan();

            TimeSpan consTime = new TimeSpan(0, consultationTime, 0);

            for (TimeSpan i = beginWorkingTime; i < endWorkingTime; i += consTime)
            {
                if (endWorkingTime - i >= consTime) 
                {
                    nextDurationTime = startTimes.Where(x => x - i < consTime && x - i >= new TimeSpan(0,0,0)).FirstOrDefault();
                    if (startTimes.Contains(nextDurationTime))
                    {
                        i = nextDurationTime + new TimeSpan(0,durations[Array.IndexOf(startTimes, nextDurationTime)],0) - consTime;
                    }
                    else 
                    {
                        intervalList.Add(i.ToString(@"hh\:mm") + " - " + (i + consTime).ToString(@"hh\:mm"));
                    }
                }
            }
            return intervalList.ToArray();
        } 
    }
}
