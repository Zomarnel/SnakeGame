namespace WPFUI.Models
{
    public class SnakePart
    {
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public bool IsInsidePlayGroundBoundaries => CheckIfInsideBoundaries();  
        public Directions Direction { get; set; }
        public SnakePart(int xCoordinate, int yCoordinate, Directions direction)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;

            Direction = direction;
        }
        public SnakeBodyPart ClonePartAsBody()
        {
            return new SnakeBodyPart(XCoordinate, YCoordinate, Direction);  
        }
        private bool CheckIfInsideBoundaries()
        {
            if(XCoordinate < 0 || XCoordinate > 480 || YCoordinate < 0 || YCoordinate > 420)
            {
                return false;
            }

            return true;
        }
    }
}
