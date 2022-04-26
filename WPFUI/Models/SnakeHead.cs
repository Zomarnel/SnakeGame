
namespace WPFUI.Models
{
    public class SnakeHead : SnakePart
    {
        public int OldXCoordinate { get; set; }
        public int OldYCoordinate { get; set; }
        public SnakeHead(int xCoordinate, int yCoordinate) : base(xCoordinate, yCoordinate)
        {
            OldXCoordinate = xCoordinate;
            OldYCoordinate = yCoordinate;
        }
        public bool Move(Snake.Directions snakeDirection)
        {
            OldXCoordinate = XCoordinate;
            OldYCoordinate = YCoordinate;

            if(snakeDirection == Snake.Directions.Left && XCoordinate > 0)
            {
                XCoordinate -= 30;
            }
            else if(snakeDirection == Snake.Directions.Right && XCoordinate < 470)
            {
                XCoordinate += 30;
            }
            else if(snakeDirection == Snake.Directions.Down && YCoordinate > 0)
            {
                YCoordinate -= 30;
            }
            else if(snakeDirection == Snake.Directions.Up && YCoordinate < 420)
            {
                YCoordinate += 30;
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}
