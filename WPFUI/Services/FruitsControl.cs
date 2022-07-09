using WPFUI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System;

namespace WPFUI.Services
{
    public class FruitsControl
    {
        private List<Fruit> _currentFruits;
        public FruitsControl()
        {
            _currentFruits = new List<Fruit>()
            {
                new Fruit("apple", 330, 210)
            };
        }
        public int CheckForFruitCollision(Snake snake)
        {
            List<Fruit> fruitsToRemove = new List<Fruit>();

            int score = 0;

            foreach(Fruit fruit in _currentFruits)
            {
                if(fruit.XCoordinate == snake.SnakeHead.XCoordinate && fruit.YCoordinate == snake.SnakeHead.YCoordinate)
                {
                    fruitsToRemove.Add(fruit);
                    snake.AddNewSnakePart();
                    score += 1;
                }
            }

            RemoveFruitsFromCurrentFruits(fruitsToRemove, snake);

            return score;
        }
        public void DisplayCurrentFruits(Canvas playGround)
        {
            foreach(Fruit fruit in _currentFruits)
            {
                Image fruitImage = new Image();
                fruitImage.Width = 30;
                fruitImage.Height = 30;

                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri($"/Images/Fruits/{fruit.ImageName}.png", UriKind.Relative);
                bitmap.EndInit();

                fruitImage.Source = bitmap;

                playGround.Children.Add(fruitImage);

                Canvas.SetLeft(fruitImage, fruit.XCoordinate);
                Canvas.SetBottom(fruitImage, fruit.YCoordinate);
            }
        }
        private void RemoveFruitsFromCurrentFruits(List<Fruit> fruitsToRemove, Snake snake)
        {
            Random random = new Random();

            int xCoordinate = 0;
            int yCoordinate = 0;

            bool haveCoordinatesBeenChosen = false;
            
            foreach(Fruit fruit in fruitsToRemove)
            {
                while (!haveCoordinatesBeenChosen)
                {
                    xCoordinate = random.Next(0, 17) * 30;
                    yCoordinate = random.Next(0, 15) * 30;

                    if (!_currentFruits.Any(f => f.XCoordinate == xCoordinate && f.YCoordinate == yCoordinate)
                        && !(snake.SnakeHead.XCoordinate == xCoordinate && snake.SnakeHead.YCoordinate == yCoordinate)
                        && !snake.SnakeBody.Any(s => s.XCoordinate == xCoordinate && s.YCoordinate == yCoordinate))
                    {
                        haveCoordinatesBeenChosen = true;
                    }
                }

                _currentFruits.Remove(fruit);
                _currentFruits.Add(new Fruit(fruit.ImageName, xCoordinate, yCoordinate));
            }
        }
    }
}
