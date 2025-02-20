namespace dam;

using Microsoft.Extensions.DependencyInjection;

public static class CDependencyInjection
{
    public static void ConfigureServices(IServiceCollection services)
    {
        
        services.AddSingleton(provider =>
        {
            List<CPlayer> players = new List<CPlayer>
            {
                new CPlayer("Player 1"),
                new CPlayer("Player 2")
            };
            return players;
        });
        
        services.AddSingleton<IBoard, CBoard>();
        services.AddSingleton<IRender, CRender>();
        services.AddSingleton<IMove, CMove>();
        services.AddSingleton<IScoreboard, CScoreboard>();
        services.AddSingleton<ITurnController, CTurnController>();
        services.AddSingleton<IInput, CInput>();
        services.AddSingleton<IStatus, CStatus>();
        
        services.AddSingleton<CGame>();
    }
}