using HigherOrLower.Services;
using HigherOrLower.ViewModels;
using HigherOrLower.Views;
using Microsoft.Extensions.Logging;

namespace HigherOrLower;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddTransient<IGameService, GameService>();

        builder.Services.AddTransient<StartPageViewModel>();
        builder.Services.AddTransient<GamePageViewModel>();
        builder.Services.AddTransient<GameOverPageViewModel>();

        builder.Services.AddTransient<StartPage>();
        builder.Services.AddTransient<GamePage>();
        builder.Services.AddTransient<GameOverPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}