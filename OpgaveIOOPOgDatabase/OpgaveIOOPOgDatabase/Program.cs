using MySqlConnector;
using OpgaveIOOPOgDatabase;
using System.Diagnostics;
using System.ServiceProcess;

CPanel outer = new CPanelBuilder().AddPosition(15, 0).AddSize(Console.WindowWidth, Console.WindowHeight - 5).AddAlignment(CRender.Alignment.None).Build();
CPanel inner = new CPanelBuilder().AddPosition(0, 0).AddSize(25, 20).AddAlignment(CRender.Alignment.TopRight).AddParent(outer).Build();

CText t = new CTextBuilder().AddPosition(0, 0).AddParent(inner).AddAlignment(CRender.Alignment.TopCenter).Build();

CText t1 = new CTextBuilder().AddPosition(0, 0).AddParent(inner).AddAlignment(CRender.Alignment.TopLeft).Build();

Console.SetCursorPosition(0, Console.WindowHeight - 5);
