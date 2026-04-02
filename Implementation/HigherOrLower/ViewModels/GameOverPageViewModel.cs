using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HigherOrLower.Services;

namespace HigherOrLower.ViewModels;

[QueryProperty(nameof(PlayerName), "playerName")]
public partial class GameOverPageViewModel : ObservableObject
{
    private readonly IGameService _gameService;

    public GameOverPageViewModel(IGameService gameService)
    {
        _gameService = gameService;

        var state = _gameService.LoadGame();
        if (state is not null)
        {
            Score = state.Score;
        }
    }

    [ObservableProperty]
    public partial string? PlayerName { get; set; }

    [ObservableProperty]
    public partial int Score { get; set; }

    [RelayCommand]
    private static async Task PlayAgain()
    {
        await Shell.Current.GoToAsync("//StartPage");
    }
}