internal class Program
    {
        public static void Checker(string[] input)
        {
            long sizee = long.Parse(input[0]);
            long second = long.Parse(input[1]);
            double res = 0;
            for (int i = 0; i < sizee; ++i)
            {
                var inp = Console.ReadLine();
                long f = long.Parse(inp);
                double sec = double.Parse(inp);
                res = res + sec * second/100 - f * second / 100;
            }
            Console.WriteLine($"{res:f2}");
        }
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; ++i)
            {
                var input = Console.ReadLine().Split();
                Checker(input);
            }
        }
    }
