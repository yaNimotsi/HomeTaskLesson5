using System;
using System.IO;

namespace HomeTaskLesson5_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите набор числе в диапазоне от 0 до 255");
            string userVal = Console.ReadLine();

            byte[] byteArrNums;

            if (!CheckUsrValForCorrect(userVal, out byteArrNums))
            {
                Console.WriteLine("Введена пустая строка или какое-то значение не удоволетворяет требованиям ввода");
                return;
            }

            string filePath = @"E:\GeekBrains\Base C#\‪UserText.bin";

            WriteNumsToBinaryFile(filePath, byteArrNums);
        }

        /// <summary>
        /// Проверка на корректность введенных данных. В случае успеха получение списка занчений в виде массива типа Byte
        /// </summary>
        /// <param name="userVal">Пользовательская последовательность</param>
        /// <param name="byteArrNums">Выходной байт массив</param>
        /// <returns></returns>
        static bool CheckUsrValForCorrect(string userVal, out byte[] byteArrNums)
        {
            string[] arrNums = userVal?.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            byteArrNums = new Byte[arrNums.Length];
            
            if (arrNums.Length == 0) return false;

            for (int i = 0; i < arrNums.Length; i++)
            {
                if (!Byte.TryParse(arrNums[i], out byte num))
                {
                    return false;
                }
                byteArrNums[i] = num;
            }

            return true;
        }
        /// <summary>
        /// Запись в текстовый документ байт массив
        /// </summary>
        /// <param name="filePath">Путь к файлу, в который произойдет запись</param>
        /// <param name="userVal">Байт массив для записи</param>
        static void WriteNumsToBinaryFile(string filePath, byte[] userVal)
        {
            File.WriteAllBytes(filePath, userVal);
        }
    }
}
