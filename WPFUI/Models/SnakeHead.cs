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

            if (snakeDirection == Snake.Directions.Left)
            {
                XCoordinate -= 30;
            }
            else if (snakeDirection == Snake.Directions.Right)
            {
                XCoordinate += 30;
            }
            else if (snakeDirection == Snake.Directions.Down)
            {
                YCoordinate -= 30;
            }
            else if (snakeDirection == Snake.Directions.Up)
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
