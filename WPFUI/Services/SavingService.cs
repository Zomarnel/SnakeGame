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
                return new GameDetails();
            }

            try
            {
                JObject data = JObject.Parse(File.ReadAllText(SAVE_GAME_FILE_NAME));

                return CreateGameDetails(data);
            }catch
            {
                throw new System.Exception("Is this ok?");
            }
        }
        private static GameDetails CreateGameDetails(JObject data)
        {
            return new GameDetails((int)data[nameof(GameDetails.Record)], (int)data[nameof(GameDetails.PlayGroundWidth)], (int)data[nameof(GameDetails.PlayGroundHeight)],
                                   (int)data[nameof(GameDetails.NumberOfFruitsOnGrid)], (string)data[nameof(GameDetails.FruitImageName)], (string)data[nameof(GameDetails.SnakeColour)],
                                   (string)data[nameof(GameDetails.SnakeSpeed)], (string)data[nameof(GameDetails.PlayGroundTheme)], (string)data[nameof(GameDetails.PlayMode)]);

        }
    }
}
