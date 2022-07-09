using System.Collections.Generic;
using System.Linq;

namespace WPFUI.Models
{
    public class Snake
    {
        public SnakeHead SnakeHead { get; set; }
        public List<SnakeBodyPart> SnakeBody { get; set; }
        public Directions SnakeDirection => SnakeHead.Direction;
        public Snake(int startingPositionX, int startingPositionY)
        {
            SnakeHead = new SnakeHead(startingPositionX, startingPositionY, Directions.StartingPosition);

            SnakeBody = new List<SnakeBodyPart>();

            for (int i = 0; i < 0; i++)
            {
                AddNewSnakePart();
            }
        }
        public void Move()
        {
            if (SnakeBody.Count > 0)
            {
                for (int i = SnakeBody.Count - 1; i > 0; i--)
                {
                    SnakeBody[i] = SnakeBody[i - 1].ClonePartAsBody();
                }

                SnakeBody[0] = SnakeHead.ClonePartAsBody();
            }

            SnakeHead.Move();
        }
        public void SetNewDirection(Directions newDirection)
        {
            SnakeHead.Direction = newDirection;
        }
        public void AddNewSnakePart()
        {
            if (SnakeBody.Count == 0)
            {
                SnakeBody.Add(new SnakeBodyPart(SnakeHead.XCoordinate - 30, SnakeHead.YCoordinate, Directions.Right));
                return;
            }

            SnakeBodyPart lastSnakePart = SnakeBody[SnakeBody.Count - 1];

            SnakeBodyPart partToAdd;

            switch (lastSnakePart.Direction)
            {
                case Directions.Left:
                    partToAdd = new SnakeBodyPart(lastSnakePart.XCoordinate + 30, lastSnakePart.YCoordinate, lastSnakePart.Direction);
                    break;
                case Directions.Right:
                    partToAdd = new SnakeBodyPart(lastSnakePart.XCoordinate - 30, lastSnakePart.YCoordinate, lastSnakePart.Direction);
                    break;
                case Directions.Up:
                    partToAdd = new SnakeBodyPart(lastSnakePart.XCoordinate, lastSnakePart.YCoordinate - 30, lastSnakePart.Direction);
                    break;
                case Directions.Down:
                    partToAdd = new SnakeBodyPart(lastSnakePart.XCoordinate, lastSnakePart.YCoordinate + 30, lastSnakePart.Direction);
                    break;
                default:
                    throw new System.Exception();
            }

            if (!partToAdd.IsInsidePlayGroundBoundaries)
            {
                if (lastSnakePart.Direction == Directions.Left || lastSnakePart.Direction == Directions.Right)
                {
                    partToAdd = new SnakeBodyPart(lastSnakePart.XCoordinate, lastSnakePart.YCoordinate + 30, Directions.Down);

                    if (!partToAdd.IsInsidePlayGroundBoundaries)
                    {
                        partToAdd = new SnakeBodyPart(lastSnakePart.XCoordinate, lastSnakePart.YCoordinate - 30, Directions.Up);
                    }
                }
                else
                {
                    partToAdd = new SnakeBodyPart(lastSnakePart.XCoordinate - 30, lastSnakePart.YCoordinate, Directions.Right);

                    if (!partToAdd.IsInsidePlayGroundBoundaries)
                    {
                        partToAdd = new SnakeBodyPart(lastSnakePart.XCoordinate + 30, lastSnakePart.YCoordinate, Directions.Left);
                    }
                }
            }

            SnakeBody.Add(partToAdd);
        }
        public bool IsHeadTouchingBody()
        {
            if(SnakeBody.Any(sb => sb.XCoordinate == SnakeHead.XCoordinate && sb.YCoordinate == SnakeHead.YCoordinate))
            {
                return true;
            }

            return false;
        }
    }
}
