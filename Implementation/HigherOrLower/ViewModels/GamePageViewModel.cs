using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HigherOrLower.Models;
using HigherOrLower.Services;

namespace HigherOrLower.ViewModels;

[QueryProperty(nameof(PlayerName), "playerName")]
public partial class GamePageViewModel : ObservableObject
{
    private readonly IGameService _gameService;

    public GamePageViewModel(IGameService gameService)
    {
        _gameService = gameService;

        var state = _gameService.LoadGame();
        if (state is not null)
        {
            CurrentNumber = state.CurrentNumber;
            Score = state.Score;
            Lives = state.Lives;
        }
    }

    [ObservableProperty]
    public partial string? PlayerName { get; set; }

    [ObservableProperty]
    public partial string? Feedback { get; set; }

    [ObservableProperty]
    public partial int CurrentNumber { get; set; }

    [ObservableProperty]
    public partial int Score { get; set; }

    [ObservableProperty]
    public partial int Lives { get; set; }

    [RelayCommand]
    private async Task Guess(bool isHigher)
    {
        var response = _gameService.Guess(isHigher);

        CurrentNumber = response.GameState.CurrentNumber;
        Score = response.GameState.Score;
        Lives = response.GameState.Lives;
        Feedback = response.GuessResult switch
        {
            GuessResult.Correct => "✅ Correct!",
            GuessResult.GameOver => "💀 Game Over!",
            _ => "❌ Wrong!"
        };

        if (response.GuessResult == GuessResult.GameOver)
        {
            await Shell.Current.GoToAsync(
                $"GameOverPage?playerName={Uri.EscapeDataString(PlayerName ?? string.Empty)}");
        }
    }
}