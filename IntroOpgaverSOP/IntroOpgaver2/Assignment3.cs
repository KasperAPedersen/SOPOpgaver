using System.Numerics;

namespace IntroOpgaver2;
internal class Assignment3
{
    static internal void Run()
    {
        Console.Clear();

        Console.WriteLine(Calculate(26));
        Console.WriteLine(Calculate(35));

        Console.WriteLine("\n\nPress Enter to return to menu");
        while (true)
        {
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                break;
            }
        }
    }

    static internal BigInteger Calculate(int iNum1)
    {
        BigInteger sum = 1;
        for (int i = 1; i <= iNum1; i++) sum = BigInteger.Multiply(i, sum);
        return sum;
    }
}