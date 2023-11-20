using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp1
{
    class Drives
    {        
        public static void showInfo()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine("Диск: {0}", drive.Name);
                Console.WriteLine("  Тип диска: {0}", drive.DriveType);
                if (drive.IsReady == true)
                {
                    Console.WriteLine($"  Метка тома: {drive.VolumeLabel}");
                    Console.WriteLine($"  Файловая система: {drive.DriveFormat}");
                    Console.WriteLine($"  Доступно места:{drive.AvailableFreeSpace} байт");
                    Console.WriteLine($"  Всего свободного места:{drive.TotalFreeSpace} байт");
                    Console.WriteLine($"  Общий размер диска: {drive.TotalSize} байт");
                }
            }
        }
    }       

}
