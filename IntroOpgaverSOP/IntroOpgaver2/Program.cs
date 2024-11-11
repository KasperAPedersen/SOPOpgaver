using IntroOpgaver2;

Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.CursorVisible = false;

CMenu menu = new();
menu.menuOptions = CreateMenuOptions();
menu.Display();

while (true)
{
    switch(Console.ReadKey().Key)
    {
        case ConsoleKey.Enter:
            menu.menuOptions[menu.menuIndex].Action();
            menu.Display();
            break;
        case ConsoleKey.DownArrow:
            menu.UpdateIndex(menu.menuIndex + 1);
            break;
        case ConsoleKey.UpArrow:
            menu.UpdateIndex(menu.menuIndex - 1);
            break;
    }
}

static List<CMenu.MenuOption> CreateMenuOptions()
{
    return
    [
        new ("Exit", () => { Environment.Exit(0); }),
        new ("Opg. 1 - Matematik", Assignment1.Run),
        new ("Opg. 2 - Loop med summering", Assignment2.Run),
        new ("Opg. 3 - Beregne fakultetet af et tal", Assignment3.Run),
        new ("Opg. 4 - Læs og skriv til en fil", Assignment4.Run),
        new ("Opg. 5 - JSON string editor og syntax checker", Assignment5.Run),
        new ("Opg. 6 - Email checker - med loop, if, regler", Assignment6.Run),
        new ("Opg. 7 - Email checker - regulær udtryk", Assignment7.Run)
    ];
}