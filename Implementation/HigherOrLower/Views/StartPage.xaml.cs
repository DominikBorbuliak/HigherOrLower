using HigherOrLower.ViewModels;

namespace HigherOrLower.Views;

public partial class StartPage : ContentPage
{
    public StartPage(StartPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}