using WPFUI.Models;
using System.Windows.Controls;
using System;

namespace WPFUI.ViewModels
{
    public class GameSession
    {
        public Snake Snake { get; set; }

        public event EventHandler<Canvas> OnRaisedDrawSnake;

        public int StartingPositionX = 150;
        public int StartingPositionY = 90;
        public GameSession()
        {
            Snake = new Snake(StartingPositionX, StartingPositionY);
            OnRaisedDrawSnake += Snake.Draw;
        }
        public void DrawSnake(Canvas canvas)
        {
            OnRaisedDrawSnake?.Invoke(this, canvas);
        }
        public void MoveSnake()
        {
            if(Snake.Direction != Snake.Directions.StartingPosition)
            {
                Snake.Move();
            }
        }

    }
}
