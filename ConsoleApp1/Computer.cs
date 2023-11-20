using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Computer
    {
        public string videoCard { get; set; }
        public string ram { get; set; }
        public string rom { get; set; }
        public string os { get; set; }
        public string cpu { get; set; }
        public Computer()
        {
            Console.WriteLine("Введите видеокарту:");
            this.videoCard = Console.ReadLine();
            Console.WriteLine("Введите ОЗУ:");
            this.ram = Console.ReadLine();
            Console.WriteLine("Введите жесткий диск:");
            this.rom = Console.ReadLine();
            Console.WriteLine("Введите операционную систему:");
            this.os = Console.ReadLine();
            Console.WriteLine("Введите процессор:");
            this.cpu = Console.ReadLine();
        }
    }

}
