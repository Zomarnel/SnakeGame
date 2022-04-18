

namespace SnakeGame.Models
{
    public class Player
    {
        public double XCoordinate { get; set; }
        public double YCoordinate { get; set; }
        public Player(double xCoordinate, double yCoordinate)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;  
        }
    }
}
