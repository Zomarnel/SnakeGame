using WPFUI.Models;

namespace WPFUI.Services
{
    public static class GameModeService
    {
        public static GameMode ReturnClassicGameMode()
        {
            return new GameMode()
            {
                NumberOfFruitsOnGrid = 1,
                FruitType = "Apple",
                PlayMode = "Vanilla",
                SnakeColour = "Green",
                SnakeSpeed = "Normal"
            };
        }
    }
}

