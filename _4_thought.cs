using System;
using System.Collections.Generic;

namespace _4thought
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int nbLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < nbLines; i++)
            {
                int n = int.Parse(Console.ReadLine());
                Solution(n);
            }
        }

        static void Solution(int n)
        {
            char[] operations = { '*', '+', '-', '/' };
            for (int i = 0; i < operations.Length; i++)
            {
                for (int j = 0; j < operations.Length; j++)
                {
                    for (int k = 0; k < operations.Length; k++)
                    {
                        List<char> op = new List<char> { operations[i], operations[j], operations[k] };
                        if (EvaluateExpression(op, n))
                        {
                            Console.WriteLine($"4 {operations[i]} 4 {operations[j]} 4 {operations[k]} 4 = {n}");
                            return;
                        } 
                    }
                }
            }
            Console.WriteLine("no solution");
        }

        static bool EvaluateExpression(List<char> operations, int n)
        {
            List<int> numbers = new List<int> { 4, 4, 4, 4 };
            int index;
            while (operations.Count > 0)
            {
                index = 0;
                if (operations[index] == '+' || operations[index] == '-') { 
                    for (int i=1; i< operations.Count; i++)
                    {   
                        if ((operations[index] == '+' || operations[index] == '-') && (operations[i] == '*' || operations[i] == '/'))
                        {
                            index = i;
                            break;
                        }
                    }
                }
                int result;
                // now we have correct index
                if (operations[index] == '+')
                    result = Add(numbers[index], numbers[index + 1]);
                else if (operations[index] == '-')
                    result = Sub(numbers[index], numbers[index + 1]);
                else if (operations[index] == '*')
                    result = Mul(numbers[index], numbers[index + 1]);
                else
                    result = Div(numbers[index], numbers[index + 1]);

                operations.RemoveAt(index);
                numbers.RemoveAt(index + 1);
                numbers[index] = result;
            }
            return numbers[0] == n;
        }

        static int Add(int n1, int n2)
        {
            return n1 + n2;
        }

        static int Sub(int n1, int n2)
        {
            return n1 - n2;
        }

        static int Mul(int n1, int n2)
        {
            return n1 * n2;
        }

        static int Div(int n1, int n2)
        {
            return n1 / n2;
        }
    }
}