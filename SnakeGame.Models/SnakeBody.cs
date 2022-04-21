namespace SnakeGame.Models
{
    public class SnakeBody
    {
        public bool GoLeftDirection { get; set; }
        public bool GoRightDirection { get; set; }
        public bool GoUpDirection { get; set; }
        public bool GoDownDirection { get; set; }

        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }

        public SnakeBody(int xCoordinate, int yCoordinate)
        {
            XCoordinate = xCoordinate;  
            YCoordinate = yCoordinate;  

        }
    }
}
