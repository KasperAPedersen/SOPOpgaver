using System.Text;

namespace Menu;

public class CMenu
{
    public struct MenuOption (string name, Action action)
    {
        public string Name { get; set; } = name;
        public Action Action { get; set; } = action;
    }

    internal List<MenuOption> Items { get; } = new();

    private static int width = 80;
    internal int selectedIndex = 0;

    internal void UpdateIndex(int index)
    {
        if (index < 0) index = Items.Count - 1;
        if (index > Items.Count - 1) index = 0;

        selectedIndex = index;
    }

    internal void Run()
    {
        while (true)
        {
            Draw();
            ConsoleKey key = Console.ReadKey().Key;

            switch (key)
            {
                case ConsoleKey.Escape:
                    return;
                case ConsoleKey.Enter:
                    Items[selectedIndex].Action();
                    break;
                case ConsoleKey.UpArrow:
                    UpdateIndex(selectedIndex - 1);
                    break;
                case ConsoleKey.DownArrow:
                    UpdateIndex(selectedIndex + 1);
                    break;
            }
        }
    }
    
    internal void Draw()
    {
        Console.Clear();
        
        string horizontalLine = new string('-', width - 2); // 2 = 2 corners
        
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine($"X{horizontalLine}X");
        
        for (int i = 0; i < Items.Count; i++)
        {
            string itemName = (i == selectedIndex ? "-> " : "") + Items[i].Name; // add arrow if current index
            int itemLength = itemName.Length;
            int rightPadding = width - itemLength - 4; // 4 = 2 spaces + 2 brackets
            stringBuilder.AppendLine($"| {itemName}{new string(' ', rightPadding)} |");
        }
        
        stringBuilder.AppendLine($"X{horizontalLine}X");
        
        Console.WriteLine(stringBuilder.ToString());
    }
}

public class CMenuBuilder
{
    private CMenu menu = new CMenu();
    
    public CMenuBuilder AddItem(CMenu.MenuOption item)
    {
        menu.Items.Add(item);
        return this;
    }
    
    public CMenu Build()
    {
        return menu;
    }
}