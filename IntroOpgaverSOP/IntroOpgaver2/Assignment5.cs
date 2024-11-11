using System.Text;
using System.Text.Json;

namespace IntroOpgaver2;

internal class Assignment5
{
    static internal void Run()
    {
        Console.Clear();
        StringBuilder sInput = new StringBuilder();
        bool isValidated = false;

        while (!isValidated)
        {
            Console.Clear();
            Console.WriteLine("[Enter] to validate\n[F1] to exit\n");
            Console.Write(sInput.ToString());

            ConsoleKeyInfo pressedKey = Console.ReadKey();
            if (pressedKey.Key == ConsoleKey.Enter)
            {
                // validate
                try
                {
                    JsonDocument jText = JsonDocument.Parse(sInput.ToString());
                    Console.Clear();
                    Console.Write("The entered text is valid.");
                    isValidated = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{e.Message}\n\nPress Enter to continue");
                    Console.ReadKey();
                }
            }
            else if (pressedKey.Key == ConsoleKey.Backspace)
            {
                if (sInput.Length > 0)
                {
                    sInput.Remove(sInput.Length - 1, 1);
                }
            }
            else if (pressedKey.Key == ConsoleKey.F1)
            {
                break;
            } else
            {
                sInput.Append(pressedKey.KeyChar);
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
