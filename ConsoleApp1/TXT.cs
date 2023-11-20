using System;
using System.IO;

namespace ConsoleApp1
{
    class TXT : IWorkWithFile
    {
        static string fileName = "";
        static string filePath = "";

        const string enterFileName = "Введите название файла";
        const string defaultPath = "D:\\Учеба\\Универ\\разработка безопасного ПО\\Практика 1\\ConsoleApp1\\Пользовательские файлы\\";
        const string messageOK = "Готово!";
        const string errorNotExist = "Такого файла нет";

        public static void Create()
        {
            Console.WriteLine(enterFileName);
            fileName = Console.ReadLine();
            filePath = defaultPath + $"{fileName}.txt";
            File.Create(filePath).Close();
            Console.WriteLine(messageOK);
        }
        public static void Write()
        {
            Console.WriteLine(enterFileName);
            fileName = Console.ReadLine();
            filePath = defaultPath + $"{fileName}.txt";

            if (!File.Exists(filePath))
            {
                Console.WriteLine(errorNotExist);
                return;
            }

            Console.WriteLine("Введите строку для записи в файл:");
            string text = Console.ReadLine();

            File.AppendAllText(filePath, text + "\n");
            Console.WriteLine(messageOK);
        }
        public static void Read()
        {
            Console.WriteLine(enterFileName);
            fileName = Console.ReadLine();
            filePath = defaultPath + $"{fileName}.txt";

            if (!File.Exists(filePath))
            {
                Console.WriteLine(errorNotExist);
                return;
            }

            Console.WriteLine("Содержимое файла:");
            string fileContent = File.ReadAllText(filePath);

            Console.WriteLine(fileContent);
            Console.WriteLine(messageOK);
        }
        public static void Delete()
        {
            Console.WriteLine(enterFileName);
            fileName = Console.ReadLine();
            filePath = defaultPath + $"{fileName}.txt";

            if (!File.Exists(filePath))
            {
                Console.WriteLine(errorNotExist);
                return;
            }

            File.Delete(filePath);
            Console.WriteLine(messageOK);
        }
    }
}
