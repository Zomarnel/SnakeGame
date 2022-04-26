using System.Collections.Generic;
using System.Windows.Controls;

namespace WPFUI.Models
{
    public class Snake
    {
        public SnakeHead SnakeHead { get; set; }
        public List<SnakeBodyPart> SnakeBody { get; set; }
        public enum Directions
        {
            Left,
            Right,
            Up,
            Down,
            Null
        }
        public Directions Direction { get; set; }
        public Snake(int startingPositionX, int startingPositionY)
        {
            SnakeHead = new SnakeHead(startingPositionX, startingPositionY);

            SnakeBody = new List<SnakeBodyPart>()
            {
                new SnakeBodyPart(startingPositionX-30, startingPositionY),
                new SnakeBodyPart(startingPositionX-60, startingPositionY)
            };

            Direction = Directions.Null;
        }
        internal void Draw(object sender, Canvas canvas)
        {
            SnakeHead.DrawPartOnCanvas(canvas);
            
            foreach(SnakeBodyPart snakeBodyPart in SnakeBody)
            {
                snakeBodyPart.DrawPartOnCanvas(canvas);
            }
        }
        public void Move()
        {
            if(SnakeBody.Count > 0 && SnakeHead.Move(Direction))
            {
                for (int i = SnakeBody.Count - 1; i > 0; i--)
                {
                    SnakeBody[i].XCoordinate = SnakeBody[i - 1].XCoordinate;
                    SnakeBody[i].YCoordinate = SnakeBody[i - 1].YCoordinate;
                }

                SnakeBody[0].XCoordinate = SnakeHead.OldXCoordinate;
                SnakeBody[0].YCoordinate = SnakeHead.OldYCoordinate;
            }

        }
    }
}
