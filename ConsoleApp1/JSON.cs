using System;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace ConsoleApp1
{
    class JSON
    {
        static string fileName = "";
        static string filePath = "";

        const string enterFileName = "Введите название файла";
        const string defaultPath = "D:\\Учеба\\Универ\\разработка безопасного ПО\\Практика 1\\ConsoleApp1\\Пользовательские файлы\\";
        const string messageOK = "Готово!";
        const string errorNotExist = "Такого файла нет";

        static public void Create()
        {
            Console.WriteLine(enterFileName);
            fileName = Console.ReadLine();
            filePath = defaultPath + $"{fileName}.json";
            File.Create(filePath).Close();
            Console.WriteLine(messageOK);
        }
        static public void Write()
        {
            Console.WriteLine(enterFileName);
            fileName = Console.ReadLine();
            filePath = defaultPath + $"{fileName}.json";

            if (!File.Exists(filePath))
            {
                Console.WriteLine(errorNotExist);
                return;
            }
                        
            Computer computer = new Computer();

            var options1 = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };

            string jsonString = JsonSerializer.Serialize(computer);

            File.AppendAllText(filePath, jsonString + "\n");
            Console.WriteLine(messageOK);
        }
        static public void Read()
        {
            Console.WriteLine(enterFileName);
            fileName = Console.ReadLine();
            filePath = defaultPath + $"{fileName}.json";

            if (!File.Exists(filePath))
            {
                Console.WriteLine(errorNotExist);
                return;
            }

            // Открытие файла JSON для чтения
            FileStream fileStream = new FileStream(filePath, FileMode.Open);

            // Создание объекта StreamReader для чтения данных из файла
            StreamReader streamReader = new StreamReader(fileStream);

            // Считывание данных из файла и вывод в консоль
            Console.WriteLine(streamReader.ReadToEnd());

            // Закрытие потоков
            streamReader.Close();
            fileStream.Close();
            Console.WriteLine(messageOK);
        }
        static public void Delete()
        {
            Console.WriteLine(enterFileName);
            fileName = Console.ReadLine();
            filePath = defaultPath + $"{fileName}.json";

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
