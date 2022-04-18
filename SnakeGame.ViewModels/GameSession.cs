using SnakeGame.Models;

namespace SnakeGame.ViewModels
{
    public class GameSession
    {
        public Player Player { get; set; }

        public GameSession()
        {
            Player = new Player(100, 100);
        }
    }
}
