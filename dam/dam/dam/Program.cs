namespace dam;

using Microsoft.Extensions.DependencyInjection;

class Program
{
    public static void Main(string[] args)
    {
        ServiceCollection serviceCollection = new();
        CDependencyInjection.ConfigureServices(serviceCollection);
        
        ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
        
        var game = serviceProvider.GetService<CGame>();
        game?.Start();
    }
}