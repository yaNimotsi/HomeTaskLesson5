using System;
using System.IO;

namespace HomeTaskLesson5_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string dNow = " " + DateTime.Now.ToString();
            string filePath = @"E:\GeekBrains\UserText.txt";

            WriteToFileCurrentDate(dNow);
        }

        static void WriteToFileCurrentDate(string date)
        {
            File.AppendAllText(@"E:\GeekBrains\UserText.txt", date, System.Text.Encoding.UTF8);
        }
    }
}
