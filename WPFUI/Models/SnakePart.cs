
namespace WPFUI.Models
{
    public abstract class SnakePart
    {
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }

        public SnakePart(int xCoordinate, int yCoordinate)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
        }
    }
}
