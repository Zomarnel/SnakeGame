﻿using System;
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

        private DispatcherTimer _gameTimer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            CreatePlayGroundGrid();

            _gameTimer.Interval = TimeSpan.FromMilliseconds(70);
            _gameTimer.Tick += DrawSnake;
            _gameTimer.Start();
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

            if(e.Key == Key.Left && _gameSession.Snake.Direction != Snake.Directions.Right)
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

        }
    }
}
