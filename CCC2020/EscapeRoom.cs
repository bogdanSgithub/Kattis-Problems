using System;
using System.Collections.Generic;

namespace EscapeRoom
{   
    // 7.33/10
    // J5 EscapeRoom CCC 2020
    internal class Program
    {
        static bool found = false;
        static int M;
        static int N;
        static int[,] room;
        static HashSet<Tuple<int, int>> seenCoords = new HashSet<Tuple<int, int>>();

        static void Main(string[] args)
        {
            M = int.Parse(Console.ReadLine());
            N = int.Parse(Console.ReadLine());
            room = new int[M,N];
            for (int i=0; i<M; i++)
            {
                string row = Console.ReadLine();
                string[] numbers = row.Split(" ");
                for (int j = 0; j < N; j++)
                {
                    room[i, j] = int.Parse(numbers[j]);
                }
            }
            /*
            M = 3;
            N = 4;
            room = new int[,] { { 3, 10, 8, 14 }, { 1, 11, 4, 5 }, { 6, 2, 3, 9 } };
            */
            TryCoordinate(new Tuple<int, int>(1, 1));
        }

        static List<Tuple<int, int>> Factor(int number)
        {
            List<Tuple<int, int>> factors = new List<Tuple<int, int>>();
            int max = (int)Math.Sqrt(number);

            for (int factor = 1; factor <= max; factor++)
            {
                if (number % factor == 0)
                {
                    factors.Add(new Tuple<int, int>(factor, number / factor));
                }
            }
            return factors;
        }

        static void TryCoordinate(Tuple<int, int> coords)
        {
            Console.WriteLine($"x: {coords.Item1}, y: {coords.Item2}");
            if (coords.Item1 == M && coords.Item2 == N)
            {
                found = true;
                Console.WriteLine("yes");
                Environment.Exit(0);
            }

            int x = coords.Item1 - 1;
            int y = coords.Item2 - 1;

            int number = room[x, y];
            List<Tuple<int, int>> factors = Factor(number);

            foreach (var factor in factors)
            {
                if (ProcessValidCoordinate(factor))
                    TryCoordinate(factor);

                Tuple<int, int> otherCoords = new Tuple<int, int>(factor.Item2, factor.Item1);
                if (ProcessValidCoordinate(otherCoords))
                    TryCoordinate(otherCoords);
            }
        }

        static bool ProcessValidCoordinate(Tuple<int, int> coords)
        {
            if (coords.Item1 > M || coords.Item2 > N)
                return false;
            if (seenCoords.Contains(coords))
                return false;

            seenCoords.Add(coords);
            return true;
        }
    }
}
