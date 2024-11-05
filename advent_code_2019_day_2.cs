namespace _2019Day2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.IO.StreamReader readingFile = new System.IO.StreamReader("input.txt");
            string line = readingFile.ReadLine();
            string[] numbers = line.Split(",");
            for (int i=0; i<99; i++)
            {
                for (int j = 0; j < 99; j++)
                {
                    if (Solution(line.Split(","), $"{i}", $"{j}"))
                        Console.WriteLine($"{i} {j}");
                }
            }*/
        }

        static bool Solution(string[] numbers, string noun, string verb)
        {
            numbers[1] = noun;
            numbers[2] = verb;

            for (int i = 0; i < numbers.Length; i += 4)
            {
                int n = int.Parse(numbers[i]);
                if (n == 99)
                    break;
                else if (n == 1)
                {
                    int added = int.Parse(numbers[int.Parse(numbers[i + 1])]) + int.Parse(numbers[int.Parse(numbers[i + 2])]);
                    int index = int.Parse(numbers[i + 3]);
                    //Console.WriteLine(n);
                    numbers[index] = $"{added}";

                }
                else if (n == 2)
                {
                    int multiplied = int.Parse(numbers[int.Parse(numbers[i + 1])]) * int.Parse(numbers[int.Parse(numbers[i + 2])]);
                    int index = int.Parse(numbers[i + 3]);
                    numbers[index] = $"{multiplied}";
                }
            }
            return numbers[0] == "19690720";
        }
    }
}
