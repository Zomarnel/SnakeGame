using System.Collections.Generic;

namespace WPFUI.Models
{
    public class GameMode
    {
        public readonly List<int> NumbersOfFruitsOnGrid = new List<int>()
        {
            1,
            2,
            3,
            4,
            5
        };
        public readonly List<string> FruitTypes = new List<string>()
        {
            "Apple",
            "Banana",
            "Pineapple",
            "Cherry",
            "Watermelon"
        };
        public readonly List<string> SnakeColours = new List<string>()
        {
            "Green",
            "Red",
            "Blue",
            "Yellow"
        };
        public readonly List<string> SnakeSpeeds = new List<string>()
        {
            "Slow",
            "Normal",
            "Fast"
        };

        public int NumberOfFruitsOnGrid { get; set; }
        public string FruitType { get; set; }
        public string SnakeColour { get; set; }
        public string SnakeSpeed { get; set; }
    }
}
