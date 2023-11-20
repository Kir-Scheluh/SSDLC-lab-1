using System;

namespace ConsoleApp1
{
    interface IWorkWithFile
    {
        static string fileName = "";
        static string filePath = "";

        static public void Create() => throw new NotImplementedException();
        static public void Write() => throw new NotImplementedException();
        static public void Read() => throw new NotImplementedException();
        static public void Delete() => throw new NotImplementedException();
    }

}
