using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WPFUI.Models
{
    public abstract class SnakePart
    {
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public Directions Direction { get; set; }
        public SnakePart(int xCoordinate, int yCoordinate, Directions direction)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;

            Direction = direction;
        }
        internal void DrawPartOnCanvas(Canvas canvas)
        {
            Rectangle rectangle = new Rectangle()
            {
                Width = 30,
                Height = 30,
                Fill = Brushes.Red,
            };

            canvas.Children.Add(rectangle);
            Canvas.SetLeft(rectangle, XCoordinate);
            Canvas.SetBottom(rectangle, YCoordinate);
        }
    }
}
