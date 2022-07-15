using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows;
using WPFUI.Models;

namespace WPFUI.Services
{
    public class DrawingService
    {
        private  BitmapImage _spriteSheet = new BitmapImage();

        private  Dictionary<Directions, CroppedBitmap> _snakeHeadSpriteSheet = new Dictionary<Directions, CroppedBitmap>();
        private  Dictionary<Directions, CroppedBitmap> _snakeTailSpriteSheet = new Dictionary<Directions, CroppedBitmap>();
        private  Dictionary<string, CroppedBitmap> _snakeBodySpriteSheet = new Dictionary<string, CroppedBitmap>();

        private Canvas _canvas;

        private  int SPRITEWIDTH = 64;
        private  int SPRITEHEIGHT = 64;
        public DrawingService(Canvas canvas, string snakeColour)
        {
            _canvas = canvas;

            _spriteSheet.BeginInit();
            _spriteSheet.UriSource = new Uri("/Images/Snake/" + snakeColour + "snake.png", UriKind.Relative);
            _spriteSheet.EndInit();

            _spriteSheet.BaseUri = Application.Current.StartupUri;

            _snakeHeadSpriteSheet.Add(Directions.Right, new CroppedBitmap(_spriteSheet, new Int32Rect(256, 0, SPRITEWIDTH, SPRITEHEIGHT)));
            _snakeHeadSpriteSheet.Add(Directions.Left, new CroppedBitmap(_spriteSheet, new Int32Rect(192, 64, SPRITEWIDTH, SPRITEHEIGHT)));
            _snakeHeadSpriteSheet.Add(Directions.Up, new CroppedBitmap(_spriteSheet, new Int32Rect(192, 0, SPRITEWIDTH, SPRITEHEIGHT)));
            _snakeHeadSpriteSheet.Add(Directions.Down, new CroppedBitmap(_spriteSheet, new Int32Rect(256, 64, SPRITEWIDTH, SPRITEHEIGHT)));
            _snakeHeadSpriteSheet.Add(Directions.StartingPosition, new CroppedBitmap(_spriteSheet, new Int32Rect(256, 0, SPRITEWIDTH, SPRITEHEIGHT)));

            _snakeTailSpriteSheet.Add(Directions.Right, new CroppedBitmap(_spriteSheet, new Int32Rect(256, 128, SPRITEWIDTH, SPRITEHEIGHT)));
            _snakeTailSpriteSheet.Add(Directions.Left, new CroppedBitmap(_spriteSheet, new Int32Rect(192, 192, SPRITEWIDTH, SPRITEHEIGHT)));
            _snakeTailSpriteSheet.Add(Directions.Up, new CroppedBitmap(_spriteSheet, new Int32Rect(192, 128, SPRITEWIDTH, SPRITEHEIGHT)));
            _snakeTailSpriteSheet.Add(Directions.Down, new CroppedBitmap(_spriteSheet, new Int32Rect(256, 192, SPRITEWIDTH, SPRITEHEIGHT)));

            _snakeBodySpriteSheet.Add("Horizontal", new CroppedBitmap(_spriteSheet, new Int32Rect(64, 0, SPRITEWIDTH, SPRITEHEIGHT)));
            _snakeBodySpriteSheet.Add("Vertical", new CroppedBitmap(_spriteSheet, new Int32Rect(128, 64, SPRITEWIDTH, SPRITEHEIGHT)));
            _snakeBodySpriteSheet.Add("TopLeft", new CroppedBitmap(_spriteSheet, new Int32Rect(0, 0, SPRITEWIDTH, SPRITEHEIGHT)));
            _snakeBodySpriteSheet.Add("TopRight", new CroppedBitmap(_spriteSheet, new Int32Rect(128, 0, SPRITEWIDTH, SPRITEHEIGHT)));
            _snakeBodySpriteSheet.Add("BottomRight", new CroppedBitmap(_spriteSheet, new Int32Rect(128, 128, SPRITEWIDTH, SPRITEHEIGHT)));
            _snakeBodySpriteSheet.Add("BottomLeft", new CroppedBitmap(_spriteSheet, new Int32Rect(0, 64, SPRITEWIDTH, SPRITEHEIGHT)));


        }
        public void DrawSnake(Snake snake)
        {
            if (snake.SnakeBody.Count == 0)
            {
                DrawSnakeHead(snake.SnakeHead);
            }
            else if (snake.SnakeBody.Count == 1)
            {
                DrawSnakeHead(snake.SnakeHead);
                DrawSnakeTail(snake.SnakeBody[snake.SnakeBody.Count - 1]);
            }
            else
            {
                DrawSnakeHead(snake.SnakeHead);
                DrawSnakeTail(snake.SnakeBody[snake.SnakeBody.Count - 1]);
                DrawSnakeBody(snake.SnakeBody, snake.SnakeHead, snake.SnakeBody[snake.SnakeBody.Count - 1]);
            }
        }
        private void DrawSnakeHead(SnakeHead head)
        {
            Image image = new Image()
            {
                Width = 32,
                Height = 32
            };

            image.Source = _snakeHeadSpriteSheet[head.Direction];

            _canvas.Children.Add(image);

            Canvas.SetLeft(image, head.XCoordinate);
            Canvas.SetBottom(image, head.YCoordinate);
        }
        private void DrawSnakeTail(SnakeBodyPart tail)
        {
            Image image = new Image()
            {
                Width = 32,
                Height = 32
            };

            image.Source = _snakeTailSpriteSheet[tail.Direction];

            _canvas.Children.Add(image);

            Canvas.SetLeft(image, tail.XCoordinate);
            Canvas.SetBottom(image, tail.YCoordinate);
        }
        private void DrawSnakeBody(List<SnakeBodyPart> body, SnakeHead head, SnakeBodyPart tail)
        {
            for(int i = 0; i < body.Count-1; i++)
            {
                DrawSnakeBodyPart(body[i+1], body[i]);
            }
        }
        private void DrawSnakeBodyPart(SnakePart backPart, SnakePart centerPart)
        {
            string keySpriteSheet = "";

            int xDifference = centerPart.XCoordinate - backPart.XCoordinate;
            int yDifference = centerPart.YCoordinate - backPart.YCoordinate;

            if (centerPart.Direction == Directions.Up)
            {
                if(xDifference == -30)
                {
                    keySpriteSheet = "BottomLeft";
                }
                else if(xDifference == 30)
                {
                    keySpriteSheet = "BottomRight";
                }
                else
                {
                    keySpriteSheet = "Vertical";
                }
            }

            if (centerPart.Direction == Directions.Down)
            {
                if (xDifference == -30)
                {
                    keySpriteSheet = "TopLeft";
                }
                else if (xDifference == 30)
                {
                    keySpriteSheet = "TopRight";
                }
                else
                {
                    keySpriteSheet = "Vertical";
                }
            }

            if (centerPart.Direction == Directions.Left)
            {
                if (yDifference == -30)
                {
                    keySpriteSheet = "BottomRight";
                }
                else if (yDifference == 30)
                {
                    keySpriteSheet = "TopRight";
                }
                else
                {
                    keySpriteSheet = "Horizontal";
                }
            }

            if (centerPart.Direction == Directions.Right)
            {
                if (yDifference == -30)
                {
                    keySpriteSheet = "BottomLeft";
                }
                else if (yDifference == 30)
                {
                    keySpriteSheet = "TopLeft";
                }
                else
                {
                    keySpriteSheet = "Horizontal";
                }
            }

            Image image = new Image()
            {
                Width = 32,
                Height = 32
            };

            image.Source = _snakeBodySpriteSheet[keySpriteSheet];

            _canvas.Children.Add(image);

            Canvas.SetLeft(image, centerPart.XCoordinate);
            Canvas.SetBottom(image, centerPart.YCoordinate);
        }
    }
}
