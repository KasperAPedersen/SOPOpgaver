namespace IntroOpgaver2;

internal class Assignment2
{
    static internal void Run()
    {
        Console.Clear();

        Console.WriteLine(Calculate(34, 67));
        Console.WriteLine(Calculate(123, 789));

        Console.WriteLine("\n\nPress Enter to return to menu");
        while (true)
        {
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                break;
            }
        }
    }

    static internal int Calculate(int iNum1, int iNum2)
    {
        int sum = 0;
        for (int i = 0; i < iNum1; i++) sum += iNum2;
        return sum;
    }
}