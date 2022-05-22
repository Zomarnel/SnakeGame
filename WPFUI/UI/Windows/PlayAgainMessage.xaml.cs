using System.Windows;

namespace WPFUI.UI.Windows
{
    public partial class PlayAgainMessage : Window
    {
        public PlayAgainMessage()
        {
            InitializeComponent();
        }
        private void OnClick_StartNewGame(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
