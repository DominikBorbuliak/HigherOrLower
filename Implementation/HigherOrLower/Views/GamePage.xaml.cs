using HigherOrLower.ViewModels;

namespace HigherOrLower.Views;

public partial class GamePage : ContentPage
{
    public GamePage(GamePageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}