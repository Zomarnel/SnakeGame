using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using WPFUI.ViewModels;
using WPFUI.Models;

namespace WPFUI.UI
{
    public partial class MainWindow : Window
    {
        private GameSession _gameSession = new GameSession(150, 90);

        private bool _hasCarriedOutMovement = false;

        private int _updateInterval = 1;
        private int _moveSnakeInterval = 90;
        public MainWindow()
        {
            InitializeComponent();
            InitializeTimers();
            CreatePlayGroundGrid();
        }

        #region SnakeMovement
        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (!_hasCarriedOutMovement)
            {
                if (e.Key == Key.Left && _gameSession.Snake.Direction != Snake.Directions.Right && _gameSession.Snake.Direction != Snake.Directions.StartingPosition)
                {
                    _gameSession.Snake.Direction = Snake.Directions.Left;
                }
                if (e.Key == Key.Right && _gameSession.Snake.Direction != Snake.Directions.Left)
                {
                    _gameSession.Snake.Direction = Snake.Directions.Right;
                }
                if (e.Key == Key.Down && _gameSession.Snake.Direction != Snake.Directions.Up)
                {
                    _gameSession.Snake.Direction = Snake.Directions.Down;
                }
                if (e.Key == Key.Up && _gameSession.Snake.Direction != Snake.Directions.Down)
                {
                    _gameSession.Snake.Direction = Snake.Directions.Up;
                }

                _hasCarriedOutMovement = true;
            }
        }
        private void MoveSnake(object sender, EventArgs e)
        {
            _gameSession.MoveSnake();

            CollisionCheck();

            _hasCarriedOutMovement = false;
        }
        private void CollisionCheck()
        {
            if (_gameSession.Snake.SnakeHead.XCoordinate < 0 || _gameSession.Snake.SnakeHead.XCoordinate > 480 || _gameSession.Snake.SnakeHead.YCoordinate < 0 || _gameSession.Snake.SnakeHead.YCoordinate > 420)
            {
                GameOver();
            }
        }
        private void DrawSnake(object sender, EventArgs e)
        {
            CanvasPlayGround.Children.Clear();

            _gameSession.DrawSnake(CanvasPlayGround);
        }
        #endregion SnakeMovement

        #region Initialization
        private void InitializeTimers()
        {
            DispatcherTimer updateTimer = new DispatcherTimer();
            DispatcherTimer moveSnakeTimer = new DispatcherTimer();

            updateTimer.Interval = TimeSpan.FromMilliseconds(_updateInterval);
            updateTimer.Tick += DrawSnake;
            updateTimer.Start();

            moveSnakeTimer.Interval = TimeSpan.FromMilliseconds(_moveSnakeInterval);
            moveSnakeTimer.Tick += MoveSnake;
            moveSnakeTimer.Start();
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
        private void GameOver()
        {
            _gameSession = new GameSession(150, 90);
        }

    }
}
