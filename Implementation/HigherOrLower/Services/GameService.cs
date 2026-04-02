using System.Text.Json;
using HigherOrLower.Models;
using Microsoft.Extensions.Logging;

namespace HigherOrLower.Services;

public class GameService : IGameService
{
    private readonly string _filePath = Path.Combine(FileSystem.AppDataDirectory, Settings.StateFileName);
    private readonly ILogger<GameService> _logger;

    public GameService(ILogger<GameService> logger)
    {
        _logger = logger;
    }

    public void NewGame()
    {
        var currentNumber = Random.Shared.Next(Settings.MinNumber, Settings.MaxNumber + 1);
        var state = new GameState(currentNumber, 0, Settings.StartingLives);

        Save(state);
    }

    public GuessResponse Guess(bool isHigher)
    {
        var state = LoadGame()
            ?? throw new InvalidOperationException("No active game!");

        var nextNumber = Random.Shared.Next(Settings.MinNumber, Settings.MaxNumber + 1);
        var isCorrect = isHigher
            ? nextNumber >= state.CurrentNumber
            : nextNumber <= state.CurrentNumber;

        var newState = isCorrect
            ? state with { CurrentNumber = nextNumber, Score = state.Score + 1 }
            : state with { CurrentNumber = nextNumber, Lives = state.Lives - 1 };

        Save(newState);

        if (newState.Lives <= 0)
        {
            return new GuessResponse(GuessResult.GameOver, newState);
        }

        return isCorrect
            ? new GuessResponse(GuessResult.Correct, newState)
            : new GuessResponse(GuessResult.Wrong, newState);
    }

    public GameState? LoadGame()
    {
        if (!File.Exists(_filePath))
        {
            return null;
        }

        try
        {
            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<GameState>(json);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to load game state from {FilePath}", _filePath);
            return null;
        }
    }

    private void Save(GameState gameState)
    {
        var json = JsonSerializer.Serialize(gameState);
        File.WriteAllText(_filePath, json);
    }
}