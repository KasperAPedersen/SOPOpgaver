namespace ExcelToSQL;
using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            CMenu menu = new();
            menu.menuOptions = [
                new CMenu.MenuOption("Exit", () => { Environment.Exit(0); }),
                new CMenu.MenuOption("Convert Excel to SQL", ConvertExcelToSQL)
            ];
            menu.Display();
            Console.CursorVisible = false;
            
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
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private static void ConvertExcelToSQL()
    {
        try
        {
            Console.Clear();
            string pathBase = "C:\\Users\\zbc23kaped\\source\\repos\\SOPOpgaver\\ProduktDatabase\\ExcelToSQL";
            Console.WriteLine("Enter the name of the Excel file (without extension): ");
            string pathExcel = $"{pathBase}\\{Console.ReadLine()}.xlsx";
            string pathCreateTable = $"{pathBase}\\CreateTable.sql";
            string pathSQLData = $"{pathBase}\\DataInsert.sql";

            List<string> fileData = CReadExcel.ReadFile(pathExcel);
            CCreateSQL.WriteToFile(pathCreateTable, CCreateSQL.JSONToSQLTables(fileData[1]));
            CCreateSQL.WriteToFile(pathSQLData, CCreateSQL.JSONToSQLData(fileData[1]));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}