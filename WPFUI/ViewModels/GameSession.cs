using WPFUI.Models;
using WPFUI.Services;
using System.Windows.Controls;
using System.Collections.Generic;
using System;
using System.ComponentModel;

namespace WPFUI.ViewModels
{
    public class GameSession : INotifyPropertyChanged
    {
        public Snake Snake { get; set; }

        public event EventHandler<Canvas> OnRaisedDrawSnake;

        public event PropertyChangedEventHandler PropertyChanged;   

        public int StartingPositionX = 90;
        public int StartingPositionY = 210;
        public int Score { get; set; } = 0;
        public FruitsControl FruitsControl { get; set; } = new FruitsControl();
        private List<Fruit> CurrentFruits { get; init; }

        public GameSession()
        {
            Snake = new Snake(StartingPositionX, StartingPositionY);
            OnRaisedDrawSnake += Snake.Draw;

            CurrentFruits = FruitsControl.ReturnNewListOfFruits();
        }
        public void DrawSnake(Canvas canvas)
        {
            OnRaisedDrawSnake?.Invoke(this, canvas);
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
            FruitsControl.DisplayCurrentFruits(playGround, CurrentFruits);
        }
        public void CheckForFruitCollisionWithSnake()
        {
            Score += FruitsControl.CheckForFruitCollision(Snake, CurrentFruits);
        }
    }
}
