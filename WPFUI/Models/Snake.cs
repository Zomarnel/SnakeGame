using System.Collections.Generic;
using System.Windows.Controls;

namespace WPFUI.Models
{
    public class Snake
    {
        public SnakeHead SnakeHead { get; set; }
        public List<SnakeBodyPart> SnakeBody { get; set; }
        public Snake(int startingPositionX, int startingPositionY)
        {
            SnakeHead = new SnakeHead(startingPositionX, startingPositionY);

            SnakeBody = new List<SnakeBodyPart>();
            /*{
                new SnakeBodyPart(startingPositionX-30, startingPositionY),
                new SnakeBodyPart(startingPositionX-60, startingPositionY)
            };*/
        }
        internal void Draw(object sender, Canvas canvas)
        {
            SnakeHead.DrawPartOnCanvas(canvas);
            
            foreach(SnakeBodyPart snakeBodyPart in SnakeBody)
            {
                snakeBodyPart.DrawPartOnCanvas(canvas);
            }
        }
    }
}
