using System;
using System.Text;
using System.Text.Json;
using System.IO;


namespace HomeTaskLesson5_5
{
    class Program
    {
        static void Main(string[] args)
        {
            while (StartMenu())
            {

            }
        }

        /// <summary>
        /// Стартовое меню приложения
        /// </summary>
        /// <returns></returns>
        static bool StartMenu()
        {
            //1 добавить задачу(и)
            //2 загрузить текущие задачи
            //3 Отметить задачу, как выполненную
            //4 записать массив задач в файл
            //5 закрыть приложение

            Console.WriteLine("Введите номер команды, который вы хотите выполнить:" +
                "\n 1 Добавить задачу" +
                "\n 2 Загрузить текущие задачи" +
                "\n 3 Отметить задачу, как выполненную" +
                "\n 4 Обновить массив задач" +
                "\n 5 Закрыть приложение");
            int userVal = UserVal();

            switch (userVal)
            {
                case 1:
                    AddTask();
                    return true;
                case 2:
                    return true;
                case 3:
                    return true;
                case 4:
                    return true;
                case 5:
                    return false;
                default:
                    Console.WriteLine("\nВведено недопустимое значение. Следуйте инструкциям\n");
                    return true;
            }
        }
        /// <summary>
        /// Возврат значения введенного пользователем для стартового меню
        /// </summary>
        /// <returns></returns>
        static int UserVal()
        {
            int.TryParse(Console.ReadLine(), out int userVal);
            return userVal;
        }

        /// <summary>
        /// Возврат значения введенного пользователем для добавления ззадачи
        /// </summary>
        /// <returns></returns>
        static string UserValToAddTask()
        {
            return "";
        }

        /// <summary>
        /// Добавление новых задач
        /// </summary>
        static void AddTask()
        {
            PrinTasksFormJson();

            Console.WriteLine("Введите текст нового задания");
        }

        /// <summary>
        /// Печать текущих задач в консоль
        /// </summary>
        static void PrinTasksFormJson()
        {
            if (!IsTasksClear()) return;
            ToDo[] json = JsonSerializer.Deserialize<ToDo[]>("tasks.json");

            for (int i = 0; i < json.Length; i++)
            {
                if (json[i].IsDone)
                {
                    Console.WriteLine($"{i + 1} \"+\" {json[i].Title}");
                }
                else
                {
                    Console.WriteLine($"{i + 1} {json[i].Title}");
                }
            }
        }
        /// <summary>
        /// Проверка пуст ли файл задач
        /// </summary>
        /// <returns></returns>
        static bool IsTasksClear()
        {
            long fileSize = new FileInfo("tasks.json").Length;
            if (fileSize > 8) return true;
            return false;
        }
    }
}
