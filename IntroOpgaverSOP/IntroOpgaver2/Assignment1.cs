namespace IntroOpgaver2;

internal class Assignment1
{
    static internal void Run()
    {
        Console.Clear();
        int[] iNum = [2, 2, 2, 4];
        float[] fNum = [2f, 5f, 2f, -8.3f];
        decimal[] decNum = [672345.23489m, 33478789.34789m];
        double[] dNum = [55.88E20d, 667.89E56d];


        for (int i = 0; i < iNum.Length; i += 2)
        {
            try
            {
                Console.WriteLine($"{iNum[i]} * {iNum[i + 1]} / ( {iNum[i]} - {iNum[i + 1]} ) + {iNum[i + 1]} = {iNum[i] * iNum[i + 1] / (iNum[i] - iNum[i + 1]) + iNum[i + 1]}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        for (int i = 0; i < fNum.Length; i += 2)
        {
            try
            {
                Console.WriteLine($"{fNum[i]} * {fNum[i + 1]} / ( {fNum[i]} - {fNum[i + 1]} ) + {fNum[i + 1]} = {fNum[i] * fNum[i + 1] / (fNum[i] - fNum[i + 1]) + fNum[i + 1]}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        for (int i = 0; i < decNum.Length; i += 2)
        {
            try
            {
                Console.WriteLine($"{decNum[i]} * {decNum[i + 1]} / ( {decNum[i]} - {decNum[i + 1]} ) + {decNum[i + 1]} = {decNum[i] * decNum[i + 1] / (decNum[i] - decNum[i + 1]) + decNum[i + 1]}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        for (int i = 0; i < dNum.Length; i += 2)
        {
            try
            {
                Console.WriteLine($"{dNum[i]} * {dNum[i + 1]} / ( {dNum[i]} - {dNum[i + 1]} ) + {dNum[i + 1]} = {dNum[i] * dNum[i + 1] / (dNum[i] - dNum[i + 1]) + dNum[i + 1]}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        Console.WriteLine("\n\nPress Enter to return to menu");
        while (true)
        {
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                break;
            }
        }
    }
}