using System.ComponentModel;

namespace WPFUI.Models
{
    public class GameDetails : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;   
        public int Record { get; set; }
        public GameMode GameMode { get; set; }
        public GameDetails(int record, GameMode gameMode)
        {
            Record = record;
            GameMode = gameMode;
        }
    }
}
