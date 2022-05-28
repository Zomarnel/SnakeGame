
namespace WPFUI.Models
{
    public class SnakeBodyPart : SnakePart
    {
        public SnakeBodyPart(int xCoordinate, int yCoordinate, Directions direction) : base(xCoordinate, yCoordinate, direction)
        {
        }
        public SnakeBodyPart CloneBodyPart()
        {
            return new SnakeBodyPart(XCoordinate, YCoordinate, Direction);
        }
    }
}
