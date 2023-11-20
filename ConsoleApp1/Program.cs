using System;

namespace ConsoleApp1
{
    class Program
    {
        public static object JsonConvert { get; private set; }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Меню:\n" +
                "1. Вывести информацию в консоль о логических дисках, именах, метке тома, размере и типе файловой системы.\n" +
                "2. Работа с файлами ( класс File, FileInfo, FileStream и другие)\n" +
                "3. Работа с форматом JSON\n" +
                "4. Работа с форматом XML\n" +
                "5. Создание zip архива, добавление туда файла, определение размера архива\n");
                Console.WriteLine("Введите пункт меню");
                string menu = Console.ReadLine();
                string sub_menu;
                switch (menu)
                {
                    case "1": //Информация о дисках
                        Drives.showInfo();
                        break;
                    case "2": //Работа с файлами
                        Console.WriteLine("Что вы хотите сделать?\n" +
                            "1. Создать файл\n" +
                            "2. Записать в файл строку, введённую пользователем\n" +
                            "3. Прочитать файл в консоль\n" +
                            "4. Удалить файл\n" +
                            "5. Назад\n");
                        sub_menu = Console.ReadLine();
                        switch (sub_menu)
                        {
                            case "1": // Создание файла с расширением .txt
                                TXT.Create();
                                break;
                            case "2": // Запись в файл строки, введенной пользователем
                                TXT.Write();
                                break;
                            case "3": // Чтение файла и вывод его содержимого в консоль
                                TXT.Read();
                                break;
                            case "4":
                                TXT.Delete();
                                break;
                            case "5":
                                break;
                            default:
                                Console.WriteLine("Неизвестная команда");
                                break;
                        }
                        break;
                    case "3": // JSON
                        Console.WriteLine("Что вы хотите сделать?\n" +
                            "1. Создать файл формате JSON\n" +
                            "2. Создать новый объект. Выполнить сериализацию объекта в формате JSON и записать в файл.\n" +
                            "3. Прочитать файл в консоль\n" +
                            "4. Удалить файл\n" +
                            "5. Назад\n");
                        sub_menu = Console.ReadLine();

                        switch (sub_menu)
                        {
                            case "1": //Создать новый файл
                                JSON.Create();
                                break;
                            case "2": //Записать в файл строку
                                JSON.Write();
                                break;
                            case "3": //Чтение в консоль
                                JSON.Read();
                                break;
                            case "4":
                                JSON.Delete();
                                break;
                            case "5":
                                break;
                            default:
                                Console.WriteLine("Неизвестная команда");
                                break;
                        }
                        break;
                    case "4":
                        Console.WriteLine("Что вы хотите сделать?\n" +
                            "1. Создать файл формате XML\n" +
                            "2. Записать в файл новые данные из консоли\n" +
                            "3. Прочитать файл в консоль\n" +
                            "4. Удалить файл\n" +
                            "5. Назад\n");
                        sub_menu = Console.ReadLine();

                        switch (sub_menu)
                        {
                            case "1": //Создать новый файл
                                XML.Create();
                                break;
                            case "2": //Записать в файл строку
                                XML.Write();
                                break;
                            case "3": //Чтение в консоль
                                XML.Read();
                                break;
                            case "4":
                                XML.Delete();
                                break;
                            case "5":
                                break;
                            default:
                                Console.WriteLine("Неизвестная команда");
                                break;
                        }
                        break;
                    case "5":
                        Console.WriteLine("Что вы хотите сделать?\n" +
                            "1. Создать архив в форматер zip\n" +
                            "2. Добавить файл, выбранный пользователем, в архив\n" +
                            "3. Разархивировать файл и вывести данные о нем\n" +
                            "4. Удалить файл и архив\n" +
                            "5. Назад\n");
                        sub_menu = Console.ReadLine();

                        switch (sub_menu)
                        {
                            case "1":
                                ZIP.Create();
                                break;
                            case "2":
                                ZIP.Write();
                                break;
                            case "3":
                                ZIP.Read();
                                break;
                            case "4":
                                ZIP.Delete();
                                break;
                            case "5":
                                break;
                            default:
                                Console.WriteLine("Неизвестная команда");
                                break;
                        }
                        break;
                    default:
                        Console.WriteLine("Неизвестная команда");
                        break;
                }

            }
        }
    }
}
