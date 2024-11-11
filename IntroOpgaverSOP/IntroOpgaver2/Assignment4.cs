namespace IntroOpgaver2;

internal class Assignment4
{
    static internal void Run()
    {
        Console.Clear();

        bool keepRunning = true;
        while (keepRunning)
        {
            Console.WriteLine("[create <filename>] Create new file\n[write <filename>] Writes text to file\n[read <filename>] Reads text in file\n[quit] exit\n\n");
            string tmp = Console.ReadLine();
            if (tmp == null) break;
            try
            {
                string[] sInput = tmp.Split(' ');

                string path = $"C:\\Users\\zbc23kaped\\{sInput[1]}.txt";

                switch (sInput[0])
                {
                    case "create":
                        if (sInput[1].IndexOfAny(Path.GetInvalidFileNameChars()) == -1)
                        {
                            if (!File.Exists(path))
                            {
                                File.Create(path).Close();
                                StreamWriter file = new(path);
                                Console.Write("Enter text to file: ");
                                file.Write(Console.ReadLine());
                                file.Close();
                            }
                            else
                            {
                                Console.WriteLine($"{path} already exists");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"{sInput[1]} isn't a valid filename");
                        }
                        break;
                    case "write":
                        if (File.Exists(path))
                        {
                            StreamWriter file = new(path, true);
                            Console.Write("Enter text to file: ");
                            file.Write(Console.ReadLine());
                            file.Close();
                        }
                        else
                        {
                            Console.WriteLine($"{path} doesn't exists");
                        }
                        break;
                    case "read":
                        if (File.Exists(path))
                        {
                            StreamReader file = new(path);
                            Console.Write($"\n\n{file.ReadToEnd()}\n\n");
                            file.Close();
                        }
                        else
                        {
                            Console.WriteLine($"{path} doesn't exists");
                        }
                        break;
                    case "quit":
                        keepRunning = false;
                        break;
                    default:
                        keepRunning = false;
                        break;
                }
            } catch (Exception)
            {
                break;
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