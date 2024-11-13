using System.Text;

namespace _2019Day1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            var lines = File.ReadLines("input.txt");
            int n;
            foreach (var line in lines) {
                n = int.Parse(line);
                while (n >= 0)
                {
                    n = FuelRequired(n);
                    if (n > 0)
                        sum += n;
                }
            }
                
            Console.WriteLine(sum);
        }

        static int FuelRequired(int n)
        {
            return n / 3 - 2;
        }
    }
}
