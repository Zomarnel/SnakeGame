using System;
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
        private GameSession _gameSession;

        private bool _hasCarriedOutMovement = false;

        private DispatcherTimer _speedGameTimer = new DispatcherTimer();
        private DispatcherTimer _moveSnakeTimer = new DispatcherTimer(); 

        private int _speedGameInterval = 1;
        private int _moveSnakeInterval = 100;

        public MainWindow()
        {
            InitializeComponent();
            InitializeTimers();
            CreatePlayGroundGrid();

            _gameSession = new GameSession(CanvasPlayGround);

            ImplementGameMode();

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
                else if (e.Key == Key.Right && _gameSession.Snake.SnakeDirection != Directions.Left)
                {
                    _gameSession.Snake.SetNewDirection(Directions.Right);
                }
                else if (e.Key == Key.Down && _gameSession.Snake.SnakeDirection != Directions.Up)
                {
                    _gameSession.Snake.SetNewDirection(Directions.Down);
                }
                else if (e.Key == Key.Up && _gameSession.Snake.SnakeDirection != Directions.Down)
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

            _gameSession.DrawSnake();

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
        private void SpeedGame(object sender, EventArgs e)
        {
        }

        #endregion SnakeMovement

        #region Initialization
        private void InitializeTimers()
        {

            _speedGameTimer.Interval = TimeSpan.FromMilliseconds(_speedGameInterval);
            _speedGameTimer.Tick += SpeedGame;
            
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
            _speedGameTimer.Stop();
            _moveSnakeTimer.Stop();
        }
        private void StartTimers()
        {
            _speedGameTimer.Start();
            _moveSnakeTimer.Start();
        }

        #endregion Timers
        private void GameOver()
        {
            StopTimers();

            this.Opacity = 0.5;

            PlayAgainMessage playAgainMessage = new PlayAgainMessage(_gameSession.CurrentScore, _gameSession.GameSettings);
            playAgainMessage.Owner = this;
            playAgainMessage.ShowDialog();

            _gameSession.GameOver();

            _gameSession = new GameSession(CanvasPlayGround);

            DataContext = _gameSession;

            this.Opacity = 1;

            ImplementGameMode();

            _moveSnakeTimer.Interval = TimeSpan.FromMilliseconds(_moveSnakeInterval);
            StartTimers();
        }
        private void MainWindow_OnClosing(object sender, CancelEventArgs e)
        {
            _gameSession.SaveSession();
        }
        private void ImplementGameMode()
        {
            GameMode gameMode = _gameSession.GameSettings.GameMode;
            
            switch(gameMode.SnakeSpeed)
            {
                case "Slow":
                    _moveSnakeInterval = 120;
                    break;
                case "Normal":
                    _moveSnakeInterval = 100;
                    break;
                case "Fast":
                    _moveSnakeInterval = 80;
                    break;
            }

        }
    }
}
