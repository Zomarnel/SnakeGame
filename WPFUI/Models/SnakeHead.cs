namespace WPFUI.Models
{
    public class SnakeHead : SnakePart
    {
        public SnakeHead(int xCoordinate, int yCoordinate, Directions direction) : base(xCoordinate, yCoordinate, direction)
        {
        }
        public void Move()
        {
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
        }
    }
}
