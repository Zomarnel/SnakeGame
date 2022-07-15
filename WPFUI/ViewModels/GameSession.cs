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

        private int _currentScore = 0;
        public int CurrentScore
        {
            get => _currentScore;

            set
            {
                _currentScore = value;

                if(_currentScore > GameSettings.Record)
                {
                    GameSettings.Record = _currentScore;
                }
            }
        }
        private FruitsControl FruitsControl { get; set; } 
        public GameSession()
        {
            Snake = new Snake(StartingPositionX, StartingPositionY);

            GameSettings = SavingService.LoadGameSettingsOrCreateNew();

            FruitsControl = new FruitsControl(GameSettings.GameMode.NumberOfFruitsOnGrid, GameSettings.GameMode.FruitType, Snake);
        }
        public void DrawSnake(Canvas canvas)
        {
            DrawingService ds = new DrawingService(canvas, GameSettings.GameMode.SnakeColour);

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
