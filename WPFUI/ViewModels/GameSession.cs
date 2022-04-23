using WPFUI.Models;
using System.Drawing;

namespace WPFUI.ViewModels
{
    public class GameSession
    {
        public Snake Snake { get; set; }
        public GameSession(Point startingPosition)
        {
            Snake = new Snake(startingPosition.X, startingPosition.Y);
        }
    }
}
