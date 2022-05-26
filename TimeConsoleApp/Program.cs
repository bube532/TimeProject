using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeLibrary;

namespace TimeConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            List<TimeSpan> startTimesList = new List<TimeSpan>();
            startTimesList.Add(new TimeSpan(10, 30, 00));
            startTimesList.Add(new TimeSpan(11, 30, 00));

            List<int> durationsList = new List<int>();
            durationsList.Add(40);
            durationsList.Add(40);

            int[] durations = durationsList.ToArray();
            TimeSpan[] startTimes = startTimesList.ToArray();

            TimeSpan beginWorkingTime = new TimeSpan(09, 30, 00);
            TimeSpan endWorkingTime = new TimeSpan(12, 00, 00);

            int consultationTime = 30;

            string[] rasp = Calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);

            int i = 0;
            foreach (var item in rasp)
            {
                i++;
                Console.WriteLine(i+") "+item);
            }

            Console.ReadKey();
        }
    }
}
