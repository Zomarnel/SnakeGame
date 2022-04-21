
namespace SnakeGame.Models
{
    public class Player
    {
        public SnakeBody SnakeHead { get; set; }
        public SnakeBody SnakeTail { get; set; }
        public List<SnakeBody> SnakeBody { get; set; }
        public Player()
        {
            SnakeHead = new SnakeBody(90, 210);
        }
    }
}
