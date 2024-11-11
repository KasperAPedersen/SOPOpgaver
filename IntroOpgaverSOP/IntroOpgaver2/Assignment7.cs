using System.Text.RegularExpressions;

namespace IntroOpgaver2;

internal class Assignment7
{
    static internal void Run()
    {
        Console.Clear();

        string[] emails = { "Abc.bnm.gh2106@Data.ZBC.dk", "14564@101.233.120", "CAB@Xyz.dk"};
        foreach(string email in emails)
        {
            Console.WriteLine(Validate(email) ? "Valid" : "Invalid");
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

    static internal bool Validate(string email)
    {
        Regex reg = new Regex(@"([\w-._])+@([\w._-])+\.[a-zA-Z]{2,4}");
        return reg.IsMatch(email) ? true : false;
    }
}