using System.Windows;
using System.Windows.Input;

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

        private void OnMouseEnter(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void OnMouseLeave(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Arrow;
        }
    }
}
