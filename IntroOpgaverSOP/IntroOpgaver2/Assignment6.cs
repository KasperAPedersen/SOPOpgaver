namespace IntroOpgaver2;

internal class Assignment6
{
    static internal void Run()
    {
        Console.Clear();
        Console.Write("Enter Email: ");
        string uInput = Console.ReadLine();
        if (uInput.Length >= 5)
        {
            if (uInput.Contains("@"))
            {
                string[] aInput = uInput.Split('@');
                if (aInput[0].Length >= 1)
                {
                    if (aInput[1].Contains("."))
                    {
                        if (aInput[1].Length > 2)
                        {
                            string[] domainAddress = aInput[1].Split('.');
                            bool isNumeric = true;
                            foreach (string s in domainAddress)
                            {
                                int result;
                                if (!int.TryParse(s, out result)) isNumeric = false;
                                if (result > 255) isNumeric = false;
                            }
                            if (isNumeric)
                            {
                                if (domainAddress.Length == 4)
                                {
                                    Console.WriteLine("Valid");
                                }
                                else
                                {
                                    Console.WriteLine("Invalid");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Valid");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid - Domain short");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid - Missing .");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid - short");
                }
            }
            else
            {
                Console.WriteLine("Invalid - Missing @");
            }

        }
        else
        {
            Console.WriteLine("Invalid - short");
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
