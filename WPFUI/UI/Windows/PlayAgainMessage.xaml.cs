using System.Windows;
using System.Windows.Input;
using System.ComponentModel;
using WPFUI.Models;
using WPFUI.Services;
using WpfAnimatedGif;
using System.Windows.Media.Imaging;

namespace WPFUI.UI.Windows
{
    public partial class PlayAgainMessage : Window
    {
        private GameDetails _gameSettings;
        public PlayAgainMessage(int playerScore, GameDetails gameSettings, string fruitImageName)
        {
            InitializeComponent();

            _gameSettings = gameSettings;

            ScoreLabel.Content = playerScore.ToString();

            if(_gameSettings.Record < playerScore)
            {
                _gameSettings.Record = playerScore;
            }

            RecordLabel.Content = _gameSettings.Record.ToString();
            
            BitmapImage img = new BitmapImage();
            img.BeginInit();
            img.UriSource = new System.Uri(fruitImageName, System.UriKind.Relative);
            img.EndInit();

            ImageBehavior.SetAnimatedSource(FruitImage, img);
        }
        private void OnClick_StartNewGame(object sender, RoutedEventArgs e)
        {
            Close();
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
            SavingService.Save(_gameSettings);
        }
    }
}
