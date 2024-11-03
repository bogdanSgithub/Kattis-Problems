using System;

// 4.1 Medium
namespace Zigzag
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            const int AsciiA = 97;
            const int Distance = 25;
            int size = Convert.ToInt32(Math.Ceiling((decimal) n / Distance)) + 1;

            char[] answer = new char[size];
            // theres only 2 variables in our answer, the second letter and the last letter. everything else is a or z.
            for (int i = 0; i < size; i++)
            {
                if (i % 2 == 0)
                    answer[i] = 'a';
                else
                    answer[i] = 'z';
            }
            // this takes care of if size == 2 which is when n < 26
            int secondLetter = n;

            if (size == 3)
            {   
                secondLetter = Convert.ToInt32(Math.Ceiling((decimal) n / 2));
                if (n % 2 != 0)
                    answer[size-1] = 'b';
            }
            else if (size > 3)
            {
                int sum = (size - 3) * Distance;
                secondLetter = Convert.ToInt32(Math.Ceiling((decimal)(n - sum) / 2));

                if (answer[size - 1] == 'a' && n % 2 == 1)
                    answer[size - 1] = 'b';

                else if (answer[size - 1] == 'z' && n % 2 == 0)
                    answer[size - 1] = 'y';
            }

            answer[1] = (char)(AsciiA + secondLetter);
            foreach (char c in answer)
                Console.Write(c);
        }
    }
}