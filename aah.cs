using System;

namespace Aah
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string justinString = Console.ReadLine();
            string doctorString = Console.ReadLine();
            if (justinString.Length < doctorString.Length)
                Console.WriteLine("no");
            else
                Console.WriteLine("go");
        }
    }
}