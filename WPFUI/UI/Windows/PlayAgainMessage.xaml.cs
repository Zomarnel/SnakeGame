using System.Windows;
using System.Windows.Input;
using System.ComponentModel;
using WPFUI.Models;
using WPFUI.Services;
using WpfAnimatedGif;
using System.Windows.Media.Imaging;
using WPFUI.ViewModels;

namespace WPFUI.UI.Windows
{
    public partial class PlayAgainMessage : Window
    {
        private GameSession _gameSession;
        public PlayAgainMessage(GameSession gameSession)
        {
            InitializeComponent();

            _gameSession = gameSession;

            ScoreLabel.Content = gameSession.CurrentScore.ToString();

            RecordLabel.Content = _gameSession.GameSettings.Record.ToString();
            
            BitmapImage img = new BitmapImage();
            img.BeginInit();
            img.UriSource = new System.Uri($"/Images/Fruits/{_gameSession.GameSettings.GameMode.FruitType}.gif", System.UriKind.Relative);
            img.EndInit();

            ImageBehavior.SetAnimatedSource(FruitImage, img);
        }
        private void OnClick_StartNewGame(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void OnClick_OpenMenu(object sender, RoutedEventArgs e)
        {
            MenuOptions menu = new MenuOptions(_gameSession);
            menu.Owner = Owner;
            Close();
            menu.ShowDialog();

        }
        private void OnMouseEnter(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
        }
        private void OnMouseLeave(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Arrow;
        }
        private void PlayAgainWindow_OnClosing(object sender, CancelEventArgs e)
        {
            SavingService.Save(_gameSession.GameSettings);
        }
    }
}
