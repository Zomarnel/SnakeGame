using WPFUI.Models;
using WPFUI.Services;
using System.Windows.Controls;
using System.ComponentModel;

namespace WPFUI.ViewModels
{
    public class GameSession : INotifyPropertyChanged
    {
        public Snake Snake { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;   
        public GameDetails GameSettings { get; set; }

        public int StartingPositionX = 90;
        public int StartingPositionY = 210;
        public int CurrentScore { get; set; } = 0;
        private FruitsControl FruitsControl { get; set; } = new FruitsControl();
        public GameSession()
        {
            Snake = new Snake(StartingPositionX, StartingPositionY);

            GameSettings = SavingService.LoadGameSettingsOrCreateNew();
        }
        public void DrawSnake(Canvas canvas)
        {
            DrawingService ds = new DrawingService(canvas);

            ds.DrawSnake(Snake);
        }
        public void MoveSnake()
        {
            if(Snake.SnakeDirection != Directions.StartingPosition)
            {
                Snake.Move();
            }
        }
        public void DrawFruitsOnPlayGround(Canvas playGround)
        {
            FruitsControl.DisplayCurrentFruits(playGround);
        }
        public void CheckForFruitCollisionWithSnake()
        {
            CurrentScore += FruitsControl.CheckForFruitCollision(Snake);
        }
        public void SaveSession()
        {
            SavingService.Save(GameSettings);
        }
    }
}
