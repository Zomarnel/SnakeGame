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

        public string FruitImageUri => $"/Images/Fruits/{GameSettings.GameMode.FruitType}.gif";
        private FruitsControl _fruitsControl { get; init; } 
        private DrawingService _drawingService { get; init; }
        public GameSession(Canvas drawingCanvas)
        {
            Snake = new Snake(StartingPositionX, StartingPositionY);

            GameSettings = SavingService.LoadGameSettingsOrCreateNew();

            _fruitsControl = new FruitsControl(GameSettings.GameMode.NumberOfFruitsOnGrid, GameSettings.GameMode.FruitType, Snake, drawingCanvas);

            _drawingService = new DrawingService(drawingCanvas, GameSettings.GameMode.SnakeColour);
        }
        public void DrawSnake()
        {
            _drawingService.RemoveSnakeFromCanvas();
            _drawingService.DrawSnake(Snake);
        }
        public void MoveSnake()
        {
            if(Snake.SnakeDirection != Directions.StartingPosition)
            {
                Snake.Move();
            }
        }
        public void CheckForFruitCollisionWithSnake()
        {
            CurrentScore += _fruitsControl.CheckForFruitCollision(Snake);
        }
        public void SaveSession()
        {
            SavingService.Save(GameSettings);
        }
        public void GameOver()
        {
            _drawingService.RemoveSnakeFromCanvas();
            _fruitsControl.RemoveFruitImagesFromCanvas();
        }
    }
}
