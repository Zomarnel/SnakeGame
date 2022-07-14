using System.ComponentModel;

namespace WPFUI.Models
{
    public class GameDetails : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;   
        public int Record { get; set; }
        public int PlayGroundWidth { get; set; }
        public int PlayGroundHeight { get; set; }
        public int NumberOfFruitsOnGrid { get; set; }
        public string FruitImageName { get; set; }
        public string SnakeColour { get; set; }
        public string SnakeSpeed { get; set; }
        public string PlayGroundTheme { get; set; }
        public string PlayMode { get; set; }

        public GameDetails(int record = 0, int playGroundWidth = 470, int playGroundHeight = 420, int numberOfFruitsOnGrid = 1,
                           string fruitImageName = "apple", string snakeColour = "blue", string snakeSpeed = "normal",
                           string playGroundTheme = "sunny", string playMode = "vanilla")
        {
            Record = record;

            NumberOfFruitsOnGrid = numberOfFruitsOnGrid;
            FruitImageName = fruitImageName;

            SnakeColour = snakeColour;
            SnakeSpeed = snakeSpeed;

            PlayGroundWidth = playGroundWidth;
            PlayGroundHeight = playGroundHeight;
            PlayGroundTheme = playGroundTheme;
            PlayMode = playMode;
        }
    }
}
