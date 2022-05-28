namespace WPFUI.Models
{
    public class SnakeHead : SnakePart
    {
        public int OldXCoordinate { get; set; }
        public int OldYCoordinate { get; set; }
        public SnakeHead(int xCoordinate, int yCoordinate, Directions direction) : base(xCoordinate, yCoordinate, direction)
        {
            OldXCoordinate = xCoordinate;
            OldYCoordinate = yCoordinate;
        }
        public bool Move()
        {
            OldXCoordinate = XCoordinate;
            OldYCoordinate = YCoordinate;

            if (Direction == Directions.Left)
            {
                XCoordinate -= 30;
            }
            else if (Direction == Directions.Right)
            {
                XCoordinate += 30;
            }
            else if (Direction == Directions.Down)
            {
                YCoordinate -= 30;
            }
            else if (Direction == Directions.Up)
            {
                YCoordinate += 30;
            }
            else
            {
                return false;
            }

            return true;
        }
        public SnakeBodyPart CloneSnakeHead()
        {
            return new SnakeBodyPart(OldXCoordinate, OldYCoordinate, Direction);
        }
    }
}
