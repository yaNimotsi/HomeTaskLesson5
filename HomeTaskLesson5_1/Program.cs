using System;
using System.IO;

namespace HomeTaskLesson5_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите набор данных для последующего сохранения \n" +
                "в текстовый файл.");
            string userVal = Console.ReadLine();

            WriteUserTextToFile(userVal);
        }

        static void WriteUserTextToFile(string userVal)
        {
            File.WriteAllText(@"E:\GeekBrains\UserText.txt", userVal, System.Text.Encoding.UTF8);
        }
    }
}
