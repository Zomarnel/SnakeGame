using System.Windows;
using System.Windows.Input;
using WPFUI.Models;
using WPFUI.ViewModels;

namespace WPFUI.UI.Windows
{
    public partial class MenuOptions : Window
    {
        private GameSession _gameSession;
        public MenuOptions(GameSession gameSession)
        {
            InitializeComponent();

            _gameSession = gameSession;
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
            PlayAgainMessage window = new PlayAgainMessage(_gameSession);
            window.Owner = Owner;
            Close();
            window.ShowDialog();
        }
    }
}
