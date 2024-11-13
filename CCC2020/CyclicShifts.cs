using System;

namespace CyclicShifts
{   
    // J4 Cyclic Shifts CCC 2020
    // Passes all test cases
    internal class Program
    {
        static void Main(string[] args)
        {
            string T = Console.ReadLine();
            string S = Console.ReadLine();

            for (int i=0; i< S.Length; i++)
            {
                string shiftedS = S.Substring(i) + S.Substring(0, i);
                if (T.Contains(shiftedS)) { 
                    Console.WriteLine("yes");
                    return;
                }
            }
            Console.WriteLine("no");
        }
    }
}