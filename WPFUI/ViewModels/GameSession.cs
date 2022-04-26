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
        public GameSession(Point startingPosition)
        {
            Snake = new Snake(startingPosition.X, startingPosition.Y);
            OnRaisedDrawSnake += Snake.Draw;
        }
        public void DrawSnake(Canvas canvas)
        {
            OnRaisedDrawSnake?.Invoke(this, canvas);
        }
    }
}
