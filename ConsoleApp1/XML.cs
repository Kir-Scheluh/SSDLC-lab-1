using System;
using System.IO;
using System.Xml;

namespace ConsoleApp1
{
    class XML : IWorkWithFile
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
            filePath = defaultPath + $"{fileName}.xml";

            XmlDocument doc = new XmlDocument();
            XmlNode root = doc.CreateElement("root");
            doc.AppendChild(root);
            doc.Save(filePath);
            Console.WriteLine(messageOK);
        }

        static public void Write()
        {
            Console.WriteLine(enterFileName);
            fileName = Console.ReadLine();
            filePath = defaultPath + $"{fileName}.xml";

            if (!File.Exists(filePath))
            {
                Console.WriteLine(errorNotExist);
                return;
            }

            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);

            Console.Write("Введите имя элемента: ");
            string elementName = Console.ReadLine();

            Console.Write("Введите значение элемента: ");
            string elementValue = Console.ReadLine();

            XmlNode element = CreateXMLElement(doc, elementName, elementValue);
            doc.DocumentElement.AppendChild(element);
            doc.Save(filePath);
            Console.WriteLine(messageOK);
        }

        static public void Read()
        {
            Console.WriteLine(enterFileName);
            fileName = Console.ReadLine();
            filePath = defaultPath + $"{fileName}.xml";

            if (!File.Exists(filePath))
            {
                Console.WriteLine(errorNotExist);
                return;
            }

            string xmlContent = ReadXML();
            Console.WriteLine(xmlContent);

            Console.WriteLine(messageOK);
        }

        static public void Delete()
        {
            Console.WriteLine(enterFileName);
            fileName = Console.ReadLine();
            filePath = defaultPath + $"{fileName}.xml";

            if (!File.Exists(filePath))
            {
                Console.WriteLine(errorNotExist);
                return;
            }

            File.Delete(filePath);
            Console.WriteLine(messageOK);
        }

        static private string ReadXML()
        {
            string xmlContent = "";
            try
            {
                using StreamReader reader = new StreamReader(filePath);
                xmlContent = reader.ReadToEnd();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while reading XML file: " + ex.Message);
            }
            return xmlContent;
        }
        static private XmlNode CreateXMLElement(XmlDocument doc, string elementName, string elementValue)
        {
            XmlNode element = doc.CreateElement(elementName);
            element.InnerText = elementValue;
            return element;
        }
    }
}