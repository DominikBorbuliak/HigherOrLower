using HigherOrLower.ViewModels;

namespace HigherOrLower.Views;

public partial class GameOverPage : ContentPage
{
    public GameOverPage(GameOverPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}