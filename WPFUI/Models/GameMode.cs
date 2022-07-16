
namespace WPFUI.Models
{
    public class GameMode
    {
        public enum NumbersOfFruitsOnGrid
        {
            One,
            Two,
            Three,
            Four,
            Five
        };
        public enum FruitTypes
        {
            Apple,
            Banana,
            Pineapple,
            Cherry,
            Watermelon
        };
        public enum PlayModes
        {
            Vanilla,
            Walls,
            Infinite,
            FlyingFruit
        };
        public enum SnakeColours
        {
            Green,
            Red,
            Blue,
            Yellow
        };
        public enum SnakeSpeeds
        {
            Slow,
            Normal,
            Fast,
            Impossible
        };

        public int NumberOfFruitsOnGrid { get; set; }
        public string FruitType { get; set; }
        public string PlayMode { get; set; }
        public string SnakeColour { get; set; }
        public string SnakeSpeed { get; set; }
    }
}
