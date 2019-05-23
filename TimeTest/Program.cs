using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTest
{
    class Program
    {
        public static List<ScheduleTable> scheduleTables = new List<ScheduleTable>();

        static void Main(string[] args)
        {
            //DateTime dtNow = DateTime.Now;
            //DateTime dtNowUTC = DateTime.UtcNow;

            //Console.WriteLine("dtNow :" + dtNow + "\n dtNowUTC:" + dtNowUTC);

            //TimeSpan tNow = DateTime.Now.TimeOfDay;

            //TimeSpan t1 = TimeSpan.Parse("18:00:00");
            //int it = 10;
            //TimeSpan test = t1 + TimeSpan.Parse("00:" + it + ":00");

            //double totalTimein = test.TotalMinutes;

            // Console.WriteLine("\ntNOw :" + tNow + "\n t1:" + t1);

            //TimeSpan t2 = t1.Add(TimeSpan.Parse("00:30:00"));
            //Console.WriteLine("\nt2 :" + t2);



            //var result = TimeValidation(TimeSpan.Parse("25:00:00"), TimeSpan.Parse("00:00:00"), TimeSpan.Parse("00:00:00"));

            //=================create========
            TimeSpan startTime = TimeSpan.Parse("21:00:00");
            TimeSpan endTime = TimeSpan.Parse("22:25:00");
            TimeSpan intervalTime = TimeSpan.Parse("00:25:00");
            if (TimeValidation(startTime, endTime, intervalTime) == true)
            {
                AddTimeInList(startTime, endTime, intervalTime);
            }
            else
            {
                Console.WriteLine("Invalid to create...");
            }
            
            foreach (ScheduleTable i in scheduleTables)
            {
                Console.WriteLine("ID: " + i.ID + "\tSchduleTime: " + i.SchduleTime + "\tSchduleIterval: " + i.SchduleIterval + "\n");
            }

            Console.WriteLine("===###########===\n\n");

            //=================update========
            TimeSpan sTime = TimeSpan.Parse("20:00:00");
            TimeSpan eTime = TimeSpan.Parse("22:50:00");
            TimeSpan iTime = TimeSpan.Parse("00:20:00");
            if (TimeValidation(sTime, eTime, iTime) == true)
            {
                UpdateSchedule(sTime, eTime, iTime);
            }
            else
            {
                Console.WriteLine("Invalid to update...");
            }

            foreach (ScheduleTable i in scheduleTables)
            {
                Console.WriteLine("ID: " + i.ID + "\tSchduleTime: " + i.SchduleTime + "\tSchduleIterval: " + i.SchduleIterval + "\n");
            }

            Console.WriteLine("===###########===\n\n");

            foreach (ScheduleTable i in scheduleTables.OrderBy(a => a.SchduleTime))
            {
                Console.WriteLine("ID: " + i.ID + "\tSchduleTime: " + i.SchduleTime + "\tSchduleIterval: " + i.SchduleIterval + "\n");
            }
            Console.ReadKey();

        }


        static void AddTimeInList(TimeSpan sTime, TimeSpan eTime, TimeSpan iTime)
        {
            

            while ((sTime + iTime <= eTime))
            {
                var startTime = scheduleTables.Count == 0 ? sTime : sTime += iTime;
                int count = scheduleTables.Count;

                ScheduleTable scheduleObj = new ScheduleTable()
                {
                    ID = ++count,
                    SchduleTime = startTime,
                    SchduleIterval = iTime.Minutes
                };

                if (sTime + iTime <= eTime)
                {
                    scheduleTables.Add(scheduleObj);
                }
            }
        }



        static bool TimeValidation(TimeSpan sTime, TimeSpan eTime, TimeSpan iTime)
        {
            int flagForStartTime = 0, flagForEndTime = 0;

            if ((sTime > TimeSpan.Parse("00:00:00") || sTime <= TimeSpan.Parse("23:59:59")) &&
                 (sTime + iTime) < TimeSpan.Parse("23:59:59"))//Checking for start time
            {
                flagForStartTime = 1;
            }


            if ((eTime > TimeSpan.Parse("00:00:00") || eTime < TimeSpan.Parse("23:59:59")) &&
                 (eTime >= sTime + iTime) /*&& ((eTime + iTime) < TimeSpan.Parse("24:00:00")*/)
            {
                flagForEndTime = 1;
            }

            return (flagForStartTime == 1 && flagForEndTime == 1) ? true : false;
        }



        static void UpdateSchedule(TimeSpan sTime, TimeSpan eTime, TimeSpan iTime)
        {
            if (TimeValidation(sTime, eTime, iTime) == false ||
                    IsValidForUpdate(sTime, eTime, iTime) == false)
            {
                Console.WriteLine("###Invalid to update...\n\n\n");
            }
            else
            {
                AddTimeInList(sTime, eTime, iTime);
            }
        }

        static bool IsValidForUpdate(TimeSpan sTime, TimeSpan eTime, TimeSpan iTime)
        {
            List<ScheduleTable> sDataSorted = new List<ScheduleTable>();
            sDataSorted = scheduleTables.OrderBy(a => a.ID).ToList();

            //int flag = 0;
            for (int i = 0; sTime + iTime <= eTime; i++)
            {
                TimeSpan endTime = scheduleTables[i].SchduleTime + 
                                    TimeSpan.Parse("00:" + scheduleTables[i].SchduleIterval + ":00") -
                                    TimeSpan.Parse("00:01:00");


                TimeSpan endTime2 = sTime + iTime;

                if ((sTime >= scheduleTables[i].SchduleTime &&
                        sTime <= endTime) &&
                    (endTime2 >= scheduleTables[i].SchduleTime &&
                         endTime2 <= endTime)
                   )
                {
                    return false;
                }
                else
                {
                    //flag = 1;
                    continue;
                }
            }
            return true;
        }




        static void aaa()
        {

        }
    }




    public class ScheduleTable
    {
        public int ID { get; set; }
        public TimeSpan SchduleTime { get; set; }
        public int SchduleIterval { get; set; }
    }
}
