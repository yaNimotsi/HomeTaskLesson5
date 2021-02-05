using System;
using System.Text;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;

namespace HomeTaskLesson5_5
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ToDo> taskList = new List<ToDo>();
            while (StartMenu(ref taskList))
            {
                //Console.Clear();
            }
        }

        /// <summary>
        /// Стартовое меню приложения
        /// </summary>
        /// <returns></returns>
        static bool StartMenu(ref List<ToDo> taskList)
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
                "\n 0 Закрыть приложение");
            int userVal = UserVal();

            switch (userVal)
            {
                case 1:
                    AddTask(ref taskList);
                    return true;
                case 2:
                    PrinTasksFormJson(ref taskList);
                    return true;
                case 3:
                    TaskComplate(ref taskList);
                    return true;
                case 0:
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
        /// Добавление новых задач
        /// </summary>
        static void AddTask(ref List<ToDo> taskList)
        {
            Console.Clear();

            PrinTasksFormJson(ref taskList);

            string userAnswer = "";

            while (true)
            {
                Console.WriteLine("Введите текст нового задания. Если хотите выйти в меню выше, введите \"Выход\"");
                userAnswer = Console.ReadLine().ToLower();
                
                if (userAnswer == "выход") break;

                ToDo newTask = new ToDo(userAnswer, false);
                taskList.Add(newTask);
            }

            AddTasksToJson(taskList);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userVal"></param>
        /// <returns></returns>
        static void AddTasksToJson(List<ToDo> taskList)
        {
            //string json = JsonSerializer.Serialize<List<ToDo>>(taskList);
            string json = JsonSerializer.Serialize(taskList.ToArray());

            File.WriteAllText(@"E:\GeekBrains\tasks.json", json, Encoding.ASCII);

        }

        /// <summary>
        /// Печать текущих задач в консоль
        /// </summary>
        static void PrinTasksFormJson(ref List<ToDo> startTaskList)
        {
            Console.Clear();

            if (!IsJSONTasksClear(out string jsonText)) return;

            List<ToDo> json = JsonSerializer.Deserialize<List<ToDo>>(jsonText);

            for (int i = 0; i < json.Count; i++)
            {
                startTaskList.Add(json[i]);

                if (json[i].IsDone)
                {
                    Console.WriteLine($"{i + 1} [X] {json[i].Title}");
                }
                else
                {
                    Console.WriteLine($"{i + 1} {json[i].Title}");
                }
            }
        }
        /// <summary>
        /// Проверка существование файла и наличия информации в нем
        /// </summary>
        /// <returns></returns>
        static bool IsJSONTasksClear(out string jsonText)
        {
            if (File.Exists(@"E:\GeekBrains\tasks.json") == false) File.WriteAllText(@"E:\GeekBrains\tasks.json", "");

            jsonText = File.ReadAllText(@"E:\GeekBrains\tasks.json");

            if (jsonText.Length > 0) return true;
            else return false;
        }

        /// <summary>
        /// Отметить задачу, как выполненную
        /// </summary>
        /// <param name="taskList">Общий список задач</param>
        static void TaskComplate(ref List<ToDo> taskList)
        {
            Console.Clear();
            Console.WriteLine("Текущий список задач:");

            PrinTasksFormJson(ref taskList);

            while (true)
            {
                Console.WriteLine("Введите номер задачи, которая выполнена. Если хотите выйти, введите 0");
                int userVal = UserVal()-1;

                if (userVal == -1)  break;

                if (userVal < 0 || userVal > taskList.Count) Console.WriteLine("Задачи с заданным номером не существует!");

                taskList[userVal].IsDone = true;
            }
            AddTasksToJson(taskList);
        }
    }
}
