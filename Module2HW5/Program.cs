using Module2HW5.Services;
using Module2HW5.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Module2HW5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<IConfigService, ConfigService>()
                .AddTransient<IFileService, FileService>()
                .AddTransient<IActionsService, ActionsService>()
                .AddSingleton<ILoggerService, LoggerService>()
                .AddTransient<Startup>()
                .BuildServiceProvider();

            var start = serviceProvider.GetService<Startup>();
            start.Run();
        }
    }
}
