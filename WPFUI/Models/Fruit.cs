
namespace WPFUI.Models
{
    public class Fruit
    {
        public string ImageName { get; init; }
        public int XCoordinate { get; init; }
        public int YCoordinate { get; init; }
        public Fruit(string imageName, int xCoordinate, int yCoordinate)
        {
            ImageName = imageName;  
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
        }
    }
}
