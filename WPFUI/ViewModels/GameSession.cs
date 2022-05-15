using WPFUI.Models;
using System.Drawing;
using System.Windows.Controls;
using System;

namespace WPFUI.ViewModels
{
    public class GameSession
    {
        public Snake Snake { get; set; }

        public event EventHandler<Canvas> OnRaisedDrawSnake;
        public GameSession(int startingPositionX, int startingPositionY)
        {
            Snake = new Snake(startingPositionX, startingPositionY);
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
