using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HigherOrLower.Services;

namespace HigherOrLower.ViewModels;

public partial class StartPageViewModel : ObservableObject
{
    private readonly IGameService _gameService;

    public StartPageViewModel(IGameService gameService)
    {
        _gameService = gameService;
    }

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(StartCommand))]
    public partial string? PlayerName { get; set; }

    [RelayCommand(CanExecute = nameof(CanStart))]
    private async Task Start()
    {
        _gameService.NewGame();
        await Shell.Current.GoToAsync($"GamePage?playerName={Uri.EscapeDataString(PlayerName!)}");
    }

    private bool CanStart()
    {
        return !string.IsNullOrWhiteSpace(PlayerName);
    }
}