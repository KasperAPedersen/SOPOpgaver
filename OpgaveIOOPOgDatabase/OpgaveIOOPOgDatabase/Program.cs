using MySqlConnector;
using OpgaveIOOPOgDatabase;
using System.Diagnostics;
using System.ServiceProcess;

CPanel outer = new CPanelBuilder().AddPosition(0, 0).AddSize(Console.WindowWidth, Console.WindowHeight - 5).Build();
//CPanel inner = new CPanelBuilder().AddPosition(0, 0).AddSize(25, 12).AddAlignment(CRender.Alignment.TopRight).AddParent(outer).Build();

_ = new CTextBuilder().AddPosition(1, 0).AddText("CRUD app").AddParent(outer).AddAlignment(CRender.Alignment.TopLeft).Build();
//_ = new CTextBuilder().AddPosition(0, 0).AddText("Status").AddParent(inner).AddAlignment(CRender.Alignment.TopCenter).Build();

_ = new CTextBuilder().AddPosition(0, 0).AddText("blah").AddParent(outer).AddAlignment(CRender.Alignment.BottomCenter).Build();


CTable t = new CTableBuilder().AddPosition(4, 3).AddSize(Console.WindowWidth, Console.WindowHeight).AddParent(outer).AddHeaders(["Fornavn", "Efternavn", "Adresse", "By", "Postnr", "Udd.", "Udd. Slut", "Job", "Job Start", "Job Slut", "Edit", "Slet"]).Build();
Console.SetCursorPosition(0, Console.WindowHeight - 5);


bool keepRunning = true;
while(keepRunning)
{
    Console.SetCursorPosition(0, Console.WindowHeight - 5);
    switch(Console.ReadKey().Key)
    {
        case ConsoleKey.LeftArrow:
            t.selectIndex--;
            t.Render();
            break;
        case ConsoleKey.RightArrow:
            t.selectIndex++;
            t.Render();
            break;
        case ConsoleKey.UpArrow:
            t.contentIndex--;
            t.Render();
            break;
        case ConsoleKey.DownArrow:
            t.contentIndex++;
            t.Render();
            break;
    }
}