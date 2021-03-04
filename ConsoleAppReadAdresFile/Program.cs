using ReadAdresInfoLib;
using System;

namespace ConsoleAppReadAdresFile
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            AdresInfoReader r = new AdresInfoReader();
            r.readData();
            r.printData("Berlare");
        }
    }
}
