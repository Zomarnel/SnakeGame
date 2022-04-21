using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Collections.Generic;
using SnakeGame.ViewModels;
using System.Linq;

namespace WPFUI
{
    public partial class MainWindow : Window
    {
        private GameSession _gameSession = new GameSession();

        private List<Rectangle> _storedRectangles;

        #region Hardcoded Variables
        private int CellHeight = 30;
        private int CellWidth = 30;

        private int SnakeSpeed = 30;

        #endregion Hardcoded Variables

        public MainWindow()
        {
            InitializeComponent();
            CreateGrid();
            InitializePlayer();
            InitializeTimer();
        }

        #region Events
        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            _gameSession.Player.SnakeHead.GoLeftDirection = false;
            _gameSession.Player.SnakeHead.GoRightDirection = false;
            _gameSession.Player.SnakeHead.GoUpDirection = false;
            _gameSession.Player.SnakeHead.GoDownDirection = false;

            switch (e.Key)
            {
                case Key.Left:
                    _gameSession.Player.SnakeHead.GoLeftDirection = true;
                    break;
                case Key.Right:
                    _gameSession.Player.SnakeHead.GoRightDirection = true;
                    break;
                case Key.Up:
                    _gameSession.Player.SnakeHead.GoUpDirection = true;
                    break;
                case Key.Down:
                    _gameSession.Player.SnakeHead.GoDownDirection = true;
                    break;
            }
        }
        private void MovePlayer(object sender, EventArgs e)
        {
            if (_gameSession.Player.SnakeHead.GoLeftDirection && _gameSession.Player.SnakeHead.XCoordinate >= 30)
            {
                _gameSession.Player.SnakeHead.XCoordinate -= SnakeSpeed;
            }
            else if (_gameSession.Player.SnakeHead.GoRightDirection && _gameSession.Player.SnakeHead.XCoordinate <= 450)
            {
                _gameSession.Player.SnakeHead.XCoordinate += SnakeSpeed;
            }
            else if (_gameSession.Player.SnakeHead.GoUpDirection && _gameSession.Player.SnakeHead.YCoordinate <= 390)
            {
                _gameSession.Player.SnakeHead.YCoordinate += SnakeSpeed;
            }
            else if (_gameSession.Player.SnakeHead.GoDownDirection && _gameSession.Player.SnakeHead.YCoordinate >= 30)
            {
                _gameSession.Player.SnakeHead.YCoordinate -= SnakeSpeed;
            }

            DrawSnake();
        }

        #endregion Events

        #region Functions
        private void InitializePlayer()
        {
            _storedRectangles = new List<Rectangle>();
            BuildRectangleOnCanvas(CanvasPlayGround, Brushes.Red, _gameSession.Player.SnakeHead.XCoordinate, _gameSession.Player.SnakeHead.YCoordinate);
            CanvasPlayGround.Focus();
        }
        private void InitializeTimer()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += MovePlayer;
            timer.Interval = TimeSpan.FromMilliseconds(70);
            timer.Start();
        }
        private void CreateGrid()
        {
            int xCoordinate = 0;
            int yCoordinate = 0;

            bool drawDarker = false;

            for(int i = 0; i < 17; i++)
            {
                for(int j = 0; j < 15; j++)
                {
                    if(!drawDarker)
                    {
                        BuildRectangleOnCanvas(CanvasPlayGround, (SolidColorBrush)new BrushConverter().ConvertFrom("#aad751"), xCoordinate, yCoordinate);
                    }else
                    {
                        BuildRectangleOnCanvas(CanvasPlayGround, (SolidColorBrush)new BrushConverter().ConvertFrom("#a2d149"), xCoordinate, yCoordinate);
                    }

                    drawDarker = !drawDarker;

                    yCoordinate += CellHeight;
                }

                yCoordinate = 0;
                xCoordinate += CellWidth;
            }
        }
        private void BuildRectangleOnCanvas(Canvas canvas, SolidColorBrush color, int xCoordinate, int yCoordinate)
        {
            Rectangle rectangle = new Rectangle()
            {
                Width = CellWidth,
                Height = CellHeight,
                Fill = color
            };

            canvas.Children.Add(rectangle);
            _storedRectangles?.Add(rectangle);   

            Canvas.SetLeft(rectangle, xCoordinate);
            Canvas.SetBottom(rectangle, yCoordinate);
        }
        private void RemoveRectangleOnCanvas()
        {
            if(_storedRectangles.Any())
            {
                foreach(Rectangle rectangle in _storedRectangles)
                {
                    CanvasPlayGround.Children.Remove(rectangle);
                }
            }

            _storedRectangles = new List<Rectangle>();
        }
        private void DrawSnake()
        {
            RemoveRectangleOnCanvas();
            BuildRectangleOnCanvas(CanvasPlayGround, Brushes.Red, _gameSession.Player.SnakeHead.XCoordinate, _gameSession.Player.SnakeHead.YCoordinate);
        }

        #endregion Functions
    }
}
