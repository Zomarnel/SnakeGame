﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.ComponentModel;
using WPFUI.UI.Windows;
using WPFUI.ViewModels;
using WPFUI.Models;

namespace WPFUI.UI
{
    public partial class MainWindow : Window
    {
        private GameSession _gameSession = new GameSession();

        private bool _hasCarriedOutMovement = false;

        private DispatcherTimer _updateTimer = new DispatcherTimer();
        private DispatcherTimer _moveSnakeTimer = new DispatcherTimer(); 

        private int _updateInterval = 1;
        private int _moveSnakeInterval = 100;
        public MainWindow()
        {
            InitializeComponent();
            InitializeTimers();
            CreatePlayGroundGrid();

            DataContext = _gameSession; 
        }

        #region SnakeMovement
        private void OnKeyDown(object sender, KeyEventArgs e)
        {

            if (!_hasCarriedOutMovement)
            {
                if (e.Key == Key.Left && _gameSession.Snake.SnakeDirection != Directions.Right && _gameSession.Snake.SnakeDirection != Directions.StartingPosition)
                {
                    _gameSession.Snake.SetNewDirection(Directions.Left);
                }
                if (e.Key == Key.Right && _gameSession.Snake.SnakeDirection != Directions.Left)
                {
                    _gameSession.Snake.SetNewDirection(Directions.Right);
                }
                if (e.Key == Key.Down && _gameSession.Snake.SnakeDirection != Directions.Up)
                {
                    _gameSession.Snake.SetNewDirection(Directions.Down);
                }
                if (e.Key == Key.Up && _gameSession.Snake.SnakeDirection != Directions.Down)
                {
                    _gameSession.Snake.SetNewDirection(Directions.Up);
                }

                _hasCarriedOutMovement = true;
            }
        }
        private void MoveSnake(object sender, EventArgs e)
        {
            _gameSession.MoveSnake();

            CollisionsCheck();

            _hasCarriedOutMovement = false;
        }
        private void CollisionsCheck()
        {
            if (!_gameSession.Snake.SnakeHead.IsInsidePlayGroundBoundaries)
            {
                GameOver();
            }else if (_gameSession.Snake.IsHeadTouchingBody())
            {
                GameOver();
            }else
            {
                _gameSession.CheckForFruitCollisionWithSnake();
            }
        }
        private void UpdateGame(object sender, EventArgs e)
        {
            CanvasPlayGround.Children.Clear();

            _gameSession.DrawSnake(CanvasPlayGround);

            _gameSession.DrawFruitsOnPlayGround(CanvasPlayGround);
        }

        #endregion SnakeMovement

        #region Initialization
        private void InitializeTimers()
        {
            _updateTimer.Interval = TimeSpan.FromMilliseconds(_updateInterval);
            _updateTimer.Tick += UpdateGame;
            
            _moveSnakeTimer.Interval = TimeSpan.FromMilliseconds(_moveSnakeInterval);
            _moveSnakeTimer.Tick += MoveSnake;

            StartTimers();
        }
        private void CreatePlayGroundGrid()
        {
            int xCoordinate = 0;
            int yCoordinate = 0;

            bool isDark = false;

            for (int i = 0; i < 17; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    Rectangle rectangle = new Rectangle()
                    {
                        Width = 30,
                        Height = 30,
                        StrokeThickness = 0
                    };

                    if (isDark)
                    {
                        rectangle.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#a2d149"));
                    }
                    else
                    {
                        rectangle.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#aad751"));
                    }


                    CanvasPlayGroundGrid.Children.Add(rectangle);

                    Canvas.SetLeft(rectangle, xCoordinate);
                    Canvas.SetBottom(rectangle, yCoordinate);

                    isDark = !isDark;
                    yCoordinate += 30;
                }

                yCoordinate = 0;
                xCoordinate += 30;
            }
        }

        #endregion Initialization

        #region Timers
        private void StopTimers()
        {
            _updateTimer.Stop();
            _moveSnakeTimer.Stop();
        }
        private void StartTimers()
        {
            _updateTimer.Start();
            _moveSnakeTimer.Start();
        }

        #endregion Timers
        private void GameOver()
        {
            StopTimers();

            this.Opacity = 0.5;

            PlayAgainMessage playAgainMessage = new PlayAgainMessage(_gameSession.Score, _gameSession.GameSettings);
            playAgainMessage.Owner = this;
            playAgainMessage.ShowDialog();

            _gameSession = new GameSession();

            DataContext = _gameSession;

            this.Opacity = 1;

            StartTimers();
        }
        private void MainWindow_OnClosing(object sender, CancelEventArgs e)
        {
            _gameSession.SaveSession();
        }
    }
}
