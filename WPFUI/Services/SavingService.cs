using WPFUI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace WPFUI.Services
{
    public static class SavingService
    {
        private const string SAVE_GAME_FILE_NAME = "GAMEINFORMATION.json";
        public static void Save(GameDetails gameDetails)
        {
            File.WriteAllText(SAVE_GAME_FILE_NAME,
                              JsonConvert.SerializeObject(gameDetails, Formatting.Indented));
        }
        public static GameDetails LoadGameSettingsOrCreateNew()
        {
            if(!File.Exists(SAVE_GAME_FILE_NAME))
            {
                return new GameDetails(0, GameModeService.ReturnClassicGameMode());
            }

            JObject data = JObject.Parse(File.ReadAllText(SAVE_GAME_FILE_NAME));

            return CreateGameDetails(data);

        }
        private static GameDetails CreateGameDetails(JObject data)
        {
            return new GameDetails((int)data[nameof(GameDetails.Record)], CreateGameMode(data));
        }

        private static GameMode CreateGameMode(JObject data)
        {
            return new GameMode()
            {
                NumberOfFruitsOnGrid = (int)data[nameof(GameDetails.GameMode)][nameof(GameMode.NumberOfFruitsOnGrid)],
                FruitType = (string)data[nameof(GameDetails.GameMode)][nameof(GameMode.FruitType)],
                PlayMode = (string)data[nameof(GameDetails.GameMode)][nameof(GameMode.PlayMode)],
                SnakeColour = (string)data[nameof(GameDetails.GameMode)][nameof(GameMode.SnakeColour)],
                SnakeSpeed = (string)data[nameof(GameDetails.GameMode)][nameof(GameMode.SnakeSpeed)]
            };
        }
    }
}
