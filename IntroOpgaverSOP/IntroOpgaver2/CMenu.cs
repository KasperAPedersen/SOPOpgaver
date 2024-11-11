namespace IntroOpgaver2
{
    internal class CMenu
    {

        public readonly struct MenuOption(string Text, Action Action)
        {
            public string Text { get; } = Text;
            public Action Action { get; } = Action;
        }

        public static int width = 60;
        public int menuIndex = 0;

        public List<MenuOption> menuOptions { get; set; } = new List<MenuOption>();

        internal void Display()
        {
            Console.Clear();
            Console.Title = "HF1 Opgaver";

            Console.WriteLine($"┌{new string('─', width - 2)}┐");
            
            for (int i = 0; i < menuOptions.Count; i++)
            {
                string text = menuIndex == i ? StyleActiveItem(menuOptions[i].Text) : menuOptions[i].Text;
                Console.WriteLine($"│ {text}{new string(' ', width - (menuOptions[i].Text.Length + 3))}│");
            }

            Console.WriteLine($"└{new string('─', width - 2)}┘");
        }

        internal void UpdateIndex(int newIndex)
        {
            if (newIndex >= menuOptions.Count) newIndex = 0;
            if (newIndex < 0) newIndex = menuOptions.Count - 1;

            Console.SetCursorPosition(0, menuIndex + 1);
            Console.WriteLine($"│ {menuOptions[menuIndex].Text}{new string(' ', width - (menuOptions[menuIndex].Text.Length + 3))}│");

            menuIndex = newIndex;

            Console.SetCursorPosition(0, menuIndex + 1);
            Console.WriteLine($"│ {StyleActiveItem(menuOptions[menuIndex].Text)}{new string(' ', width - (menuOptions[menuIndex].Text.Length + 3))}│");
        }

        internal static string StyleActiveItem(string text)
        {
            return $"\u001b[6m\u001b[38;5;9m{text}\u001b[0m";
        }
    }
}
