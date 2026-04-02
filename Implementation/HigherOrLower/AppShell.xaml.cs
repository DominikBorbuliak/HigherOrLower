using HigherOrLower.Views;

namespace HigherOrLower;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(GamePage), typeof(GamePage));
        Routing.RegisterRoute(nameof(GameOverPage), typeof(GameOverPage));
    }
}