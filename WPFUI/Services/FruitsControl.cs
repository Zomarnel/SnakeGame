using WPFUI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System;
using WpfAnimatedGif;

namespace WPFUI.Services
{
    public class FruitsControl
    {
        private List<Fruit> _currentFruits = new List<Fruit>();

        private List<Image> _storedImageFruits = new List<Image>();

        private Canvas _canvas;
        public FruitsControl(int numberOfFruits, string fruitImage, Snake snake, Canvas canvas)
        {
            _canvas = canvas;

            InitializeCurrentFruits(numberOfFruits, fruitImage, snake);

            DisplayCurrentFruits();
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

            if(fruitsToRemove.Any())
            {
                RemoveFruitsFromCurrentFruits(fruitsToRemove, snake);
            }

            return score;
        }
        private void DisplayCurrentFruits()
        {
            RemoveFruitImagesFromCanvas();

            foreach(Fruit fruit in _currentFruits)
            {
                Image fruitImage = new Image();
                fruitImage.Width = 30;
                fruitImage.Height = 30;

                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri($"/Images/Fruits/{fruit.ImageName}.gif", UriKind.Relative);
                bitmap.EndInit();

                fruitImage.Source = bitmap;

                ImageBehavior.SetAnimatedSource(fruitImage, bitmap);

                _canvas.Children.Add(fruitImage);

                Canvas.SetLeft(fruitImage, fruit.XCoordinate);
                Canvas.SetBottom(fruitImage, fruit.YCoordinate);

                _storedImageFruits.Add(fruitImage);
            }
        }
        private void InitializeCurrentFruits(int num, string fruitImage, Snake snake)
        {
            Random random = new Random();

            int xCoordinate = 0;
            int yCoordinate = 0;

            bool coordinatesChosen = false;

            for (int i = 0; i < num; i++)
            {
                while(!coordinatesChosen)
                {
                    xCoordinate = random.Next(0, 17) * 30;
                    yCoordinate = random.Next(0, 15) * 30;

                    if (!_currentFruits.Any(f => f.XCoordinate == xCoordinate && f.YCoordinate == yCoordinate)
                        && !(snake.SnakeHead.XCoordinate == xCoordinate && snake.SnakeHead.YCoordinate == yCoordinate)
                        && !snake.SnakeBody.Any(s => s.XCoordinate == xCoordinate && s.YCoordinate == yCoordinate))
                    {
                        coordinatesChosen = true;
                    }
                }

                _currentFruits.Add(new Fruit(fruitImage, xCoordinate, yCoordinate));
                coordinatesChosen = false;
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

                haveCoordinatesBeenChosen = false;
            }

            DisplayCurrentFruits();
        }
        public void RemoveFruitImagesFromCanvas()
        {
            foreach (Image img in _storedImageFruits)
            {
                _canvas.Children.Remove(img);
            }

            _storedImageFruits.Clear();
        }
    }
}
