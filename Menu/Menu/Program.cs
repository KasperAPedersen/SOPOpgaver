namespace Menu;

class Program
{
    static void Main(string[] args)
    {
        CMenu menu = new CMenuBuilder()
            .AddItem(new CMenu.MenuOption("Option 1", () =>
            {
                CMenu menu = new CMenuBuilder()
                    .AddItem(new CMenu.MenuOption("Option 1.1", () =>
                    {
                        Console.WriteLine("Option 1.1");
                        Console.ReadKey();
                    }))
                    .AddItem(new CMenu.MenuOption("Option 1.2", () =>
                    {
                        Console.WriteLine("Option 1.2");
                        Console.ReadKey();
                    }))
                    .Build();
                
                menu.Run();
            }))
            .AddItem(new CMenu.MenuOption("Option 2", () =>
            {
                CMenu menu = new CMenuBuilder()
                    .AddItem(new CMenu.MenuOption("Option 2.1", () =>
                    {
                        Console.WriteLine("Option 2.1");
                        Console.ReadKey();
                    }))
                    .AddItem(new CMenu.MenuOption("Option 2.2", () =>
                    {
                        Console.WriteLine("Option 2.2");
                        Console.ReadKey();
                    }))
                    .Build();
                
                menu.Run();
            }))
            .AddItem(new CMenu.MenuOption("Option 3", () =>
            {
                CMenu menu = new CMenuBuilder()
                    .AddItem(new CMenu.MenuOption("Option 3.1", () =>
                    {
                        Console.WriteLine("Option 3.1");
                        Console.ReadKey();
                    }))
                    .AddItem(new CMenu.MenuOption("Option 3.2", () =>
                    {
                        Console.WriteLine("Option 3.2");
                        Console.ReadKey();
                    }))
                    .Build();
                
                menu.Run();
            }))
            .Build();
        
        menu.Run();

        Console.ReadKey();
    }
}