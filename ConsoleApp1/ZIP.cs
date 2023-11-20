using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace ConsoleApp1
{
    class ZIP : IWorkWithFile
    {
        static string archiveName = "";
        static string archivePath = "";

        const string enterArchive = "Введите название архива";
        const string defaultPath = "D:\\Учеба\\Универ\\разработка безопасного ПО\\Практика 1\\ConsoleApp1\\Пользовательские файлы\\";
        const string errorExist = "Такой архив уже существует.";
        const string messageOK = "Готово!";
        const string errorNotExist = "Такого архива нет";

        static public void Create()
        {
            Console.WriteLine(enterArchive);
            archiveName = Console.ReadLine();
            archivePath = defaultPath + $"{archiveName}.zip";

            if (File.Exists(archivePath))
            {
                Console.WriteLine(errorExist);
                return;
            }

            ZipFile.CreateFromDirectory("D:\\Учеба\\Универ\\разработка безопасного ПО\\Практика 1\\ConsoleApp1\\emptyFolder", archivePath);
            Console.WriteLine(messageOK);
        }

        static public void Write()
        {
            Console.WriteLine(enterArchive);
            archiveName = Console.ReadLine();
            archivePath = defaultPath + $"{archiveName}.zip";

            if (!File.Exists(archivePath))
            {
                Console.WriteLine(errorNotExist);
                return;
            }

            Console.Write("Введите путь к файлу ");
            string filePath = Console.ReadLine();
            filePath = filePath.Replace("\"", "");

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Такого файла нет");
                return;
            }

            using (var archive = ZipFile.Open(archivePath, ZipArchiveMode.Update))
            {
                // Создать новую запись в архиве с именем файла
                var entry = archive.CreateEntry(Path.GetFileName(filePath));

                // Открыть поток для записи данных в новую запись
                using (var stream = entry.Open())
                {
                    // Прочитать данные из файла и записать их в поток
                    using (var fileStream = File.OpenRead(filePath))
                    {
                        fileStream.CopyTo(stream);
                    }
                }
            }

            Console.WriteLine(messageOK);
        }

        static public void Read()
        {
            Console.WriteLine(enterArchive);
            archiveName = Console.ReadLine();
            archivePath = defaultPath + $"{archiveName}.zip";

            if (!File.Exists(archivePath))
            {
                Console.WriteLine(errorNotExist);
                return;
            }

            Console.Write("Введите название файла для извлечения: ");
            string fileName = Console.ReadLine();

            using (var archive = ZipFile.OpenRead(archivePath))
            {
                // Найти запись с именем файла
                var entry = archive.GetEntry(fileName);
                if (entry != null)
                {
                    // Открыть поток для чтения данных из записи
                    using (var stream = entry.Open())
                    {
                        // Прочитать данные из потока и вывести информацию о файле в консоль
                        var buffer = new byte[entry.Length];
                        stream.Read(buffer, 0, buffer.Length);
                        Console.WriteLine("File name: {0}", entry.Name);
                        Console.WriteLine("File size: {0} bytes", entry.Length);
                        Console.WriteLine("File content: {0}", Encoding.UTF8.GetString(buffer));
                    }
                }
                else
                {
                    Console.WriteLine("File not found in archive.");
                }

                Console.WriteLine(messageOK);
            }
        }

        public static void Delete()
        {
            Console.WriteLine(enterArchive);
            archiveName = Console.ReadLine();
            archivePath = defaultPath + $"{archiveName}.zip";

            if (!File.Exists(archivePath))
            {
                Console.WriteLine(errorNotExist);
                return;
            }

            File.Delete(archivePath);
            Console.WriteLine(messageOK);
        }
    }
}
