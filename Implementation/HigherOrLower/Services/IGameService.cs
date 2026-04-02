using HigherOrLower.Models;

namespace HigherOrLower.Services;

public interface IGameService
{
    void NewGame();
    GuessResponse Guess(bool isHigher);
    GameState? LoadGame();
}