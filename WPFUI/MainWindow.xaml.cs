using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using SnakeGame.ViewModels;

namespace WPFUI
{
    public partial class MainWindow : Window
    {
        private GameSession _gameSession = new GameSession();
        public MainWindow()
        {
            InitializeComponent();
            InitializePlayer();
        }
        private void InitializePlayer()
        {
            Rectangle rectangle = new Rectangle()
            {
                Width = (int)_gameSession.Player.XCoordinate,
                Height = (int)_gameSession.Player.YCoordinate,
                Fill = Brushes.Green
            };

            CanvasPlayGround.Children.Add(rectangle);
        }
    }
}
