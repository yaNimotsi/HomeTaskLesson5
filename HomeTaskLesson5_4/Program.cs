using System;
using System.IO;
using System.Text;

namespace HomeTaskLesson5_4
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathFolder = @"E:\WorkFolder";
            string pathFileToWrite = @"E:\GeekBrains\SubFoldersAndFiles.txt";

            string[] AllSubFolders = GetAllFolder(pathFolder);

            PrintFolderAndFiles(AllSubFolders, pathFileToWrite);
            
        }

        static string[] GetAllFolder(string startFolderPath)
        {
            return Directory.GetDirectories(startFolderPath, "*", SearchOption.AllDirectories);
        }

        static string[] GetFilesInFolder(string folderPath)
        {
            string[] pathsToFiles = Directory.GetFiles(folderPath);

            string[] nameFiles = new string[pathsToFiles.Length];
            for (int i = 0; i < pathsToFiles.Length; i++)
            {
                nameFiles[i] = Path.GetFileName(pathsToFiles[i]);
            }

            return nameFiles;
        }

        static void PrintFolderAndFiles(string[] AllFolders, string pathFileToWrite)
        {
            File.WriteAllText(pathFileToWrite, "", Encoding.UTF8);
            for (int i = 0; i < AllFolders.Length; i++)
            {
                if (AllFolders[i] == null) continue;
                else
                {
                    string[] filesInFolder = GetFilesInFolder(AllFolders[i]);

                    File.AppendAllText(pathFileToWrite, $"Текущая папка {AllFolders[i]}", Encoding.UTF8);

                    if (filesInFolder.Length > 0)
                    {
                        File.AppendAllText(pathFileToWrite, "\nФайлы в указанной папке:\n", Encoding.UTF8);
                        foreach (string str in filesInFolder)
                        {
                            File.AppendAllText(pathFileToWrite, $"{str}\n", Encoding.UTF8);
                        }
                        File.AppendAllText(pathFileToWrite, "\n", Encoding.UTF8);
                    }
                    else
                    {
                        File.AppendAllText(pathFileToWrite, "\nВ указанной папке нет файлов!\n", Encoding.UTF8);
                    }
                }
            }
        }
    }
}
