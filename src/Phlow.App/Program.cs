using Avalonia;
using System;
using Velopack;

namespace Phlow.App;

sealed class Program
{
    [STAThread]
    public static void Main(string[] args)
    {
        // Velopack must be first — it may exit the process for update hooks
        VelopackApp.Build().Run();

        BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
    }

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace();
}
