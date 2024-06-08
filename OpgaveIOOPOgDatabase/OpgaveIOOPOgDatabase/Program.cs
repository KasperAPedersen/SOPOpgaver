using MySqlConnector;
using OpgaveIOOPOgDatabase;
using System.Diagnostics;
using System.ServiceProcess;

CPanel outer = new CPanelBuilder().AddPosition(0, 0).AddSize(Console.WindowWidth, Console.WindowHeight - 5).AddAlignment(CRender.Alignment.None).Build();
CPanel inner = new CPanelBuilder().AddPosition(0, 0).AddSize(25, 12).AddAlignment(CRender.Alignment.TopRight).AddParent(outer).Build();

_ = new CTextBuilder().AddPosition(1, 0).AddText("CRUD app").AddParent(outer).AddAlignment(CRender.Alignment.TopLeft).Build();
_ = new CTextBuilder().AddPosition(0, 0).AddText("Status").AddParent(inner).AddAlignment(CRender.Alignment.TopCenter).Build();

_ = new CTextBuilder().AddPosition(0, 0).AddText("Made by Swoopai").AddParent(outer).AddAlignment(CRender.Alignment.BottomCenter).Build();

Console.SetCursorPosition(0, Console.WindowHeight - 5);
