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
        private GameSession _gameSession = new GameSession(new System.Drawing.Point()
        {
            X = 150,
            Y = 90
        });
        public MainWindow()
        {
            InitializeComponent();
            CreatePlayGroundGrid();

            DispatcherTimer gameTimer = new DispatcherTimer();
            gameTimer.Interval = TimeSpan.FromMilliseconds(100);
            gameTimer.Tick += DrawSnake;
            gameTimer.Start();
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
        private void DrawSnake(object sender, EventArgs e)
        {
            if(_gameSession.Snake.Direction != Snake.Directions.Null)
            {
                _gameSession.MoveSnake();
            }

            CanvasPlayGround.Children.Clear();

            _gameSession.DrawSnake(CanvasPlayGround);
        }
        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            switch(e.Key)
            {
                case Key.Left:
                    _gameSession.Snake.Direction = Snake.Directions.Left;
                    break;
                case Key.Right:
                    _gameSession.Snake.Direction = Snake.Directions.Right;
                    break;
                case Key.Down:
                    _gameSession.Snake.Direction = Snake.Directions.Down;
                    break;
                case Key.Up:
                    _gameSession.Snake.Direction = Snake.Directions.Up;
                    break;
            }
        }
    }
}
