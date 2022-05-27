using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TimeLibrary;

namespace TimeUnitTests
{
    [TestClass]
    public class TimeUnitTest
    {
        /// <summary>
        /// Вводим входные данные из ТЗ и сравниваем выходные данные из ТЗ и полученные данные из алгоритма
        /// Получаем True
        /// </summary>
        [TestMethod]
        public void TimeLibrary_TestMethod1_TrueReturned()
        {
            #region Arrange

            List<TimeSpan> startTimesList = new List<TimeSpan>();
            startTimesList.Add(new TimeSpan(10, 00, 00));
            startTimesList.Add(new TimeSpan(11, 00, 00));
            startTimesList.Add(new TimeSpan(15, 00, 00));
            startTimesList.Add(new TimeSpan(15, 30, 00));
            startTimesList.Add(new TimeSpan(16, 50, 00));

            List<int> durationsList = new List<int>();
            durationsList.Add(60);
            durationsList.Add(30);
            durationsList.Add(10);
            durationsList.Add(10);
            durationsList.Add(40);

            int[] durations = durationsList.ToArray();
            TimeSpan[] startTimes = startTimesList.ToArray();

            TimeSpan beginWorkingTime = new TimeSpan(08, 00, 00);
            TimeSpan endWorkingTime = new TimeSpan(18, 00, 00);

            int consultationTime = 30;

            List<string> resultList = new List<string>();
            resultList.Add("08:00 - 08:30");
            resultList.Add("08:30 - 09:00");
            resultList.Add("09:00 - 09:30");
            resultList.Add("09:30 - 10:00");
            resultList.Add("11:30 - 12:00");
            resultList.Add("12:00 - 12:30");
            resultList.Add("12:30 - 13:00");
            resultList.Add("13:00 - 13:30");
            resultList.Add("13:30 - 14:00");
            resultList.Add("14:00 - 14:30");
            resultList.Add("14:30 - 15:00");
            resultList.Add("15:40 - 16:10");
            resultList.Add("16:10 - 16:40");
            resultList.Add("17:30 - 18:00");

            string[] expected = resultList.ToArray();

            #endregion

            #region Act

            string[] result = Calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);

            #endregion

            #region Assert

            CollectionAssert.AreEquivalent(expected, result);

            #endregion
        }

        /// <summary>
        /// Вводим входные данные из ТЗ (Но с ошибкой) и сравниваем выходные данные из ТЗ и полученные данные из алгоритма
        /// Получаем False
        /// </summary>
        [TestMethod]
        public void TimeLibrary_TestMethod2_FalseReturned()
        {
            #region Arrange

            List<TimeSpan> startTimesList = new List<TimeSpan>();
            startTimesList.Add(new TimeSpan(10, 00, 00));
            startTimesList.Add(new TimeSpan(11, 00, 00));
            startTimesList.Add(new TimeSpan(15, 00, 00));
            startTimesList.Add(new TimeSpan(15, 30, 00));
            startTimesList.Add(new TimeSpan(16, 50, 00));

            List<int> durationsList = new List<int>();
            durationsList.Add(60);
            durationsList.Add(30);
            durationsList.Add(10);
            durationsList.Add(10);
            durationsList.Add(40);

            int[] durations = durationsList.ToArray();
            TimeSpan[] startTimes = startTimesList.ToArray();

            TimeSpan beginWorkingTime = new TimeSpan(08, 00, 00);
            TimeSpan endWorkingTime = new TimeSpan(18, 00, 00);

            int consultationTime = 20;

            List<string> resultList = new List<string>();
            resultList.Add("08:00 - 08:30");
            resultList.Add("08:30 - 09:00");
            resultList.Add("09:00 - 09:30");
            resultList.Add("09:30 - 10:00");
            resultList.Add("11:30 - 12:00");
            resultList.Add("12:00 - 12:30");
            resultList.Add("12:30 - 13:00");
            resultList.Add("13:00 - 13:30");
            resultList.Add("13:30 - 14:00");
            resultList.Add("14:00 - 14:30");
            resultList.Add("14:30 - 15:00");
            resultList.Add("15:40 - 16:10");
            resultList.Add("16:10 - 16:40");
            resultList.Add("17:30 - 18:00");

            string[] expected = resultList.ToArray();

            #endregion

            #region Act

            string[] result = Calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);

            #endregion

            #region Assert

            CollectionAssert.AreNotEquivalent(expected, result);

            #endregion
        }

        /// <summary>
        /// consultationTime увеличен с 30 до 50
        /// Получаем True
        /// </summary>
        [TestMethod]
        public void TimeLibrary_TestMethod3_SevenReturned()
        {
            #region Arrange

            List<TimeSpan> startTimesList = new List<TimeSpan>();
            startTimesList.Add(new TimeSpan(10, 00, 00));
            startTimesList.Add(new TimeSpan(11, 00, 00));
            startTimesList.Add(new TimeSpan(15, 00, 00));
            startTimesList.Add(new TimeSpan(15, 30, 00));
            startTimesList.Add(new TimeSpan(16, 50, 00));

            List<int> durationsList = new List<int>();
            durationsList.Add(60);
            durationsList.Add(30);
            durationsList.Add(10);
            durationsList.Add(10);
            durationsList.Add(40);

            int[] durations = durationsList.ToArray();
            TimeSpan[] startTimes = startTimesList.ToArray();

            TimeSpan beginWorkingTime = new TimeSpan(08, 00, 00);
            TimeSpan endWorkingTime = new TimeSpan(18, 00, 00);

            int consultationTime = 50;

            List<string> resultList = new List<string>();
            resultList.Add("08:00 - 08:50");
            resultList.Add("08:50 - 09:40");
            resultList.Add("11:30 - 12:20");
            resultList.Add("12:20 - 13:10");
            resultList.Add("13:10 - 14:00");
            resultList.Add("14:00 - 14:50");
            resultList.Add("15:40 - 16:30");

            string[] expected = resultList.ToArray();

            #endregion

            #region Act

            string[] result = Calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);

            #endregion

            #region Assert

            CollectionAssert.AreEquivalent(expected, result);

            #endregion
        }

        /// <summary>
        /// endWorkingTime уменьшен с 18:00 до 12:00
        /// Получаем True
        /// </summary>
        [TestMethod]
        public void TimeLibrary_TestMethod4_FiveReturned()
        {
            #region Arrange

            List<TimeSpan> startTimesList = new List<TimeSpan>();
            startTimesList.Add(new TimeSpan(10, 00, 00));
            startTimesList.Add(new TimeSpan(11, 00, 00));

            List<int> durationsList = new List<int>();
            durationsList.Add(60);
            durationsList.Add(30);

            int[] durations = durationsList.ToArray();
            TimeSpan[] startTimes = startTimesList.ToArray();

            TimeSpan beginWorkingTime = new TimeSpan(08, 00, 00);
            TimeSpan endWorkingTime = new TimeSpan(12, 00, 00);

            int consultationTime = 30;

            List<string> resultList = new List<string>();
            resultList.Add("08:00 - 08:30");
            resultList.Add("08:30 - 09:00");
            resultList.Add("09:00 - 09:30");
            resultList.Add("09:30 - 10:00");
            resultList.Add("11:30 - 12:00");

            string[] expected = resultList.ToArray();

            #endregion

            #region Act

            string[] result = Calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);

            #endregion

            #region Assert

            CollectionAssert.AreEquivalent(expected, result);

            #endregion
        }

        /// <summary>
        /// beginWorkingTime увеличен с 08:00 до 10:00
        /// endWorkingTime уменьшен с 18:00 до 12:00
        /// Получаем True
        /// Вернуло одно значение
        /// </summary>
        [TestMethod]
        public void TimeLibrary_TestMethod5_OneReturned()
        {
            #region Arrange

            List<TimeSpan> startTimesList = new List<TimeSpan>();
            startTimesList.Add(new TimeSpan(10, 00, 00));
            startTimesList.Add(new TimeSpan(11, 00, 00));

            List<int> durationsList = new List<int>();
            durationsList.Add(60);
            durationsList.Add(30);

            int[] durations = durationsList.ToArray();
            TimeSpan[] startTimes = startTimesList.ToArray();

            TimeSpan beginWorkingTime = new TimeSpan(10, 00, 00);
            TimeSpan endWorkingTime = new TimeSpan(12, 00, 00);

            int consultationTime = 30;

            List<string> resultList = new List<string>();
            resultList.Add("11:30 - 12:00");

            string[] expected = resultList.ToArray();

            #endregion

            #region Act

            string[] result = Calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);

            #endregion

            #region Assert

            CollectionAssert.AreEquivalent(expected, result);

            #endregion
        }

        /// <summary>
        /// beginWorkingTime увеличен с 08:00 до 11:00
        /// endWorkingTime уменьшен с 18:00 до 12:00
        /// Получаем True
        /// Расписание пустое
        /// </summary>
        [TestMethod]
        public void TimeLibrary_TestMethod6_EmptyReturned()
        {
            #region Arrange

            List<TimeSpan> startTimesList = new List<TimeSpan>();
            startTimesList.Add(new TimeSpan(10, 00, 00));
            startTimesList.Add(new TimeSpan(11, 00, 00));

            List<int> durationsList = new List<int>();
            durationsList.Add(60);
            durationsList.Add(30);

            int[] durations = durationsList.ToArray();
            TimeSpan[] startTimes = startTimesList.ToArray();

            TimeSpan beginWorkingTime = new TimeSpan(11, 40, 00);
            TimeSpan endWorkingTime = new TimeSpan(12, 00, 00);

            int consultationTime = 30;

            List<string> resultList = new List<string>();

            string[] expected = resultList.ToArray();

            #endregion

            #region Act

            string[] result = Calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);

            #endregion

            #region Assert

            CollectionAssert.AreEquivalent(expected, result);

            #endregion
        }

        /// <summary>
        /// endWorkingTime уменьшен с 18:00 до 12:00
        /// Получаем True
        /// Расписание полное, но без занятого времени
        /// </summary>
        [TestMethod]
        public void TimeLibrary_TestMethod7_NoBusyTimeReturned()
        {
            #region Arrange

            List<TimeSpan> startTimesList = new List<TimeSpan>();

            List<int> durationsList = new List<int>();

            int[] durations = durationsList.ToArray();
            TimeSpan[] startTimes = startTimesList.ToArray();

            TimeSpan beginWorkingTime = new TimeSpan(8, 00, 00);
            TimeSpan endWorkingTime = new TimeSpan(12, 00, 00);

            int consultationTime = 30;

            List<string> resultList = new List<string>();
            resultList.Add("08:00 - 08:30");
            resultList.Add("08:30 - 09:00");
            resultList.Add("09:00 - 09:30");
            resultList.Add("09:30 - 10:00");
            resultList.Add("10:00 - 10:30");
            resultList.Add("10:30 - 11:00");
            resultList.Add("11:00 - 11:30");
            resultList.Add("11:30 - 12:00");

            string[] expected = resultList.ToArray();

            #endregion

            #region Act

            string[] result = Calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);

            #endregion

            #region Assert

            CollectionAssert.AreEquivalent(expected, result);

            #endregion
        }

        /// <summary>
        /// beginWorkingTime увеличен с 08:00 до 09:30
        /// endWorkingTime уменьшен с 18:00 до 12:00
        /// durations равен 10
        /// Получаем True
        /// </summary>
        [TestMethod]
        public void TimeLibrary_TestMethod8_DurationDecreasedReturned()
        {
            #region Arrange

            List<TimeSpan> startTimesList = new List<TimeSpan>();
            startTimesList.Add(new TimeSpan(10, 30, 00));
            startTimesList.Add(new TimeSpan(11, 30, 00));

            List<int> durationsList = new List<int>();
            durationsList.Add(10);
            durationsList.Add(10);

            int[] durations = durationsList.ToArray();
            TimeSpan[] startTimes = startTimesList.ToArray();

            TimeSpan beginWorkingTime = new TimeSpan(09, 30, 00);
            TimeSpan endWorkingTime = new TimeSpan(12, 00, 00);

            int consultationTime = 30;

            List<string> resultList = new List<string>();
            resultList.Add("09:30 - 10:00");
            resultList.Add("10:00 - 10:30");
            resultList.Add("10:40 - 11:10");

            string[] expected = resultList.ToArray();

            #endregion

            #region Act

            string[] result = Calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);

            #endregion

            #region Assert

            CollectionAssert.AreEquivalent(expected, result);

            #endregion
        }

        /// <summary>
        /// beginWorkingTime увеличен с 08:00 до 09:30
        /// endWorkingTime уменьшен с 18:00 до 12:00
        /// durations равен 40
        /// Получаем True
        /// </summary>
        [TestMethod]
        public void TimeLibrary_TestMethod9_DurationIncreasedReturned()
        {
            #region Arrange

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

            List<string> resultList = new List<string>();
            resultList.Add("09:30 - 10:00");
            resultList.Add("10:00 - 10:30");

            string[] expected = resultList.ToArray();

            #endregion

            #region Act

            string[] result = Calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);

            #endregion

            #region Assert

            CollectionAssert.AreEquivalent(expected, result);

            #endregion
        }

        /// <summary>
        /// beginWorkingTime увеличен с 08:00 до 12:00
        /// endWorkingTime уменьшен с 18:00 до 08:00
        /// Получаем True и пустое раписание =)
        /// Потому что время начала больше времени конца
        /// </summary>
        [TestMethod]
        public void TimeLibrary_TestMethod10_EmptyReturned()
        {
            #region Arrange

            List<TimeSpan> startTimesList = new List<TimeSpan>();
            startTimesList.Add(new TimeSpan(12, 00, 00));
            startTimesList.Add(new TimeSpan(14, 00, 00));

            List<int> durationsList = new List<int>();
            durationsList.Add(40);
            durationsList.Add(40);

            int[] durations = durationsList.ToArray();
            TimeSpan[] startTimes = startTimesList.ToArray();

            TimeSpan beginWorkingTime = new TimeSpan(12, 00, 00);
            TimeSpan endWorkingTime = new TimeSpan(08, 00, 00);

            int consultationTime = 30;

            List<string> resultList = new List<string>();

            string[] expected = resultList.ToArray();

            #endregion

            #region Act

            string[] result = Calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);

            #endregion

            #region Assert

            CollectionAssert.AreEquivalent(expected, result);

            #endregion
        }

        /// <summary>
        /// Получаем True и пустое раписание
        /// Потому что время консультации на столько большое, что свободного времени нет
        /// </summary>
        [TestMethod]
        public void TimeLibrary_TestMethod11_NotEnoughtTimeReturned()
        {
            #region Arrange

            List<TimeSpan> startTimesList = new List<TimeSpan>();
            startTimesList.Add(new TimeSpan(8, 00, 00));

            List<int> durationsList = new List<int>();
            durationsList.Add(600);

            int[] durations = durationsList.ToArray();
            TimeSpan[] startTimes = startTimesList.ToArray();

            TimeSpan beginWorkingTime = new TimeSpan(08, 00, 00);
            TimeSpan endWorkingTime = new TimeSpan(18, 00, 00);

            int consultationTime = 30;

            List<string> resultList = new List<string>();

            string[] expected = resultList.ToArray();

            #endregion

            #region Act

            string[] result = Calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);

            #endregion

            #region Assert

            CollectionAssert.AreEquivalent(expected, result);

            #endregion
        }

        /// <summary>
        /// Получаем True и пустое раписание
        /// Потому что время и количество консультаций на столько большое, что свободного времени нет
        /// </summary>
        [TestMethod]
        public void TimeLibrary_TestMethod12_ALotOfConsultationsReturned()
        {
            #region Arrange

            List<TimeSpan> startTimesList = new List<TimeSpan>();
            startTimesList.Add(new TimeSpan(8, 00, 00));
            startTimesList.Add(new TimeSpan(9, 00, 00));
            startTimesList.Add(new TimeSpan(10, 00, 00));
            startTimesList.Add(new TimeSpan(11, 00, 00));
            startTimesList.Add(new TimeSpan(12, 00, 00));
            startTimesList.Add(new TimeSpan(13, 00, 00));
            startTimesList.Add(new TimeSpan(14, 00, 00));
            startTimesList.Add(new TimeSpan(15, 00, 00));
            startTimesList.Add(new TimeSpan(16, 00, 00));
            startTimesList.Add(new TimeSpan(17, 00, 00));

            List<int> durationsList = new List<int>();
            durationsList.Add(60);
            durationsList.Add(60);
            durationsList.Add(60);
            durationsList.Add(60);
            durationsList.Add(60);
            durationsList.Add(60);
            durationsList.Add(60);
            durationsList.Add(60);
            durationsList.Add(60);
            durationsList.Add(60);

            int[] durations = durationsList.ToArray();
            TimeSpan[] startTimes = startTimesList.ToArray();

            TimeSpan beginWorkingTime = new TimeSpan(08, 00, 00);
            TimeSpan endWorkingTime = new TimeSpan(18, 00, 00);

            int consultationTime = 30;

            List<string> resultList = new List<string>();

            string[] expected = resultList.ToArray();

            #endregion

            #region Act

            string[] result = Calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);

            #endregion

            #region Assert

            CollectionAssert.AreEquivalent(expected, result);

            #endregion
        }

        /// <summary>
        /// Получаем True и пустое раписание
        /// Потому что StartTime и Duration имеют разную длинну
        /// </summary>
        [TestMethod]
        public void TimeLibrary_TestMethod13_StartTimeAndDurationAreNotEqualReturned()
        {
            #region Arrange

            List<TimeSpan> startTimesList = new List<TimeSpan>();
            startTimesList.Add(new TimeSpan(8, 00, 00));

            List<int> durationsList = new List<int>();
            durationsList.Add(60);
            durationsList.Add(60);

            int[] durations = durationsList.ToArray();
            TimeSpan[] startTimes = startTimesList.ToArray();

            TimeSpan beginWorkingTime = new TimeSpan(08, 00, 00);
            TimeSpan endWorkingTime = new TimeSpan(18, 00, 00);

            int consultationTime = 30;

            List<string> resultList = new List<string>();

            string[] expected = resultList.ToArray();

            #endregion

            #region Act

            string[] result = Calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);

            #endregion

            #region Assert

            CollectionAssert.AreEquivalent(expected, result);

            #endregion
        }
    }
}
