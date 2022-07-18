using System.Windows;
using System.Windows.Input;
using System;
using System.Linq;
using WPFUI.Models;
using WPFUI.ViewModels;

namespace WPFUI.UI.Windows
{
    public partial class MenuOptions : Window
    {
        private GameSession _gameSession;
        public MenuOptions(GameSession gameSession)
        {
            _gameSession = gameSession;

            InitializeComponent();
            InitializeListBoxes();

            DataContext = _gameSession;

        }
        private void OnMouseEnter(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
        }
        private void OnMouseLeave(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Arrow;
        }

        private void OnClick_ReturnBack(object sender, RoutedEventArgs e)
        {
            ChangeGameSettingsToNew();

            PlayAgainMessage window = new PlayAgainMessage(_gameSession);
            window.Owner = Owner;
            Close();
            window.ShowDialog();
        }
        private void OnClick_SelectRandomOption(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();

            NumbersOfFruits.SelectedItem = NumbersOfFruits.Items[rand.Next(0, NumbersOfFruits.Items.Count)];
            FruitTypes.SelectedItem = FruitTypes.Items[rand.Next(0, FruitTypes.Items.Count)];
            SnakeColours.SelectedItem = SnakeColours.Items[rand.Next(0, SnakeColours.Items.Count)];
            SnakeSpeed.SelectedItem = SnakeSpeed.Items[rand.Next(0, SnakeSpeed.Items.Count)];
        }
        private void InitializeListBoxes()
        {
            NumbersOfFruits.SelectedItem = NumbersOfFruits.Items[_gameSession.GameSettings.GameMode.NumberOfFruitsOnGrid];
            FruitTypes.SelectedItem = FruitTypes.Items[_gameSession.GameSettings.GameMode.FruitTypes.IndexOf(_gameSession.GameSettings.GameMode.FruitType)];
            SnakeColours.SelectedItem = SnakeColours.Items[_gameSession.GameSettings.GameMode.SnakeColours.IndexOf(_gameSession.GameSettings.GameMode.SnakeColour)];
            SnakeSpeed.SelectedItem = SnakeSpeed.Items[_gameSession.GameSettings.GameMode.SnakeSpeeds.IndexOf(_gameSession.GameSettings.GameMode.SnakeSpeed)];
        }
        private void ChangeGameSettingsToNew()
        {
            _gameSession.GameSettings.GameMode.NumberOfFruitsOnGrid = NumbersOfFruits.SelectedIndex;

            switch(FruitTypes.SelectedIndex)
            {
                case 0:
                    _gameSession.GameSettings.GameMode.FruitType = "Apple";
                    break;
                case 1:
                    _gameSession.GameSettings.GameMode.FruitType = "Banana";
                    break;
                case 2:
                    _gameSession.GameSettings.GameMode.FruitType = "Pineapple";
                    break;
                case 3:
                    _gameSession.GameSettings.GameMode.FruitType = "Cherry";
                    break;
                case 4:
                    _gameSession.GameSettings.GameMode.FruitType = "Watermelon";
                    break;
            }

            switch (SnakeColours.SelectedIndex)
            {
                case 0:
                    _gameSession.GameSettings.GameMode.SnakeColour = "Green";
                    break;
                case 1:
                    _gameSession.GameSettings.GameMode.SnakeColour = "Red";
                    break;
                case 2:
                    _gameSession.GameSettings.GameMode.SnakeColour = "Blue";
                    break;
                case 3:
                    _gameSession.GameSettings.GameMode.SnakeColour = "Yellow";
                    break;
            }

            switch (SnakeSpeed.SelectedIndex)
            {
                case 0:
                    _gameSession.GameSettings.GameMode.SnakeSpeed = "Slow";
                    break;
                case 1:
                    _gameSession.GameSettings.GameMode.SnakeSpeed = "Normal";
                    break;
                case 2:
                    _gameSession.GameSettings.GameMode.SnakeSpeed = "Fast";
                    break;
            }
        }
    }
}
