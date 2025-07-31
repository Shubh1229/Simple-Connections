using SimpleConnections;
using SimpleConnections.factory;
using SimpleConnections.model;
using Terminal.Gui;

Console.Clear();
Application.Init();

try
{
    PageFactory page = new PageFactory(PAGETYPE.MAINMENU);
    Application.Run(page.Build());
}
finally
{
    Application.Shutdown();
    Environment.Exit(0);
}