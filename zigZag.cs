using System;

namespace Zigzag
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            const int AsciiA = 97;
            const int Distance = 25;
            int size = Convert.ToInt32(Math.Ceiling((decimal)n / Distance)) + 1;

            char[] answer = new char[size];
            answer[0] = 'a';
            int asciiLetter; 

            if (size == 2)
            {
                answer[1] = (char)(AsciiA + n);
            }
            else if (size == 3)
            {   
                asciiLetter = Convert.ToInt32(Math.Ceiling((decimal)n / 2));
                answer[1] = (char)(AsciiA + asciiLetter);
                if (n % 2 == 0)
                    answer[2] = 'a';
                else
                    answer[2] = 'b';
            }
            else
            {
                int sum = (size - 3) * Distance;
                asciiLetter = Convert.ToInt32(Math.Ceiling((decimal)(n - sum) / 2));

                for (int i = 1; i < size; i++)
                {
                    if (i % 2 == 0)
                        answer[i] = 'a';
                    else
                        answer[i] = 'z';
                }

                if (answer[size - 1] == 'a' && n % 2 == 1)
                    answer[size - 1] = 'b';

                else if (answer[size - 1] == 'z' && n % 2 == 0)
                    answer[size - 1] = 'y';

                answer[1] = (char)(AsciiA + asciiLetter);
            }

            foreach (char c in answer)
            {
                Console.Write(c);
            }
        }
    }
}