using System;
using System.IO;

namespace HomeTaskLesson5_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string dNow = " " + DateTime.Now.ToString();
            string filePath = @"E:\GeekBrains\startup.txt";

            WriteToFileCurrentDate(filePath, dNow);
        }

        static void WriteToFileCurrentDate(string filePath ,string date)
        {
            File.AppendAllText(filePath, date, System.Text.Encoding.UTF8);
        }
    }
}
