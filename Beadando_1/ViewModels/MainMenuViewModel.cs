using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Beadando_1
{
    enum gamemode_type{Normál, Extrém, Időkorlát, Gyakorlás}
    class MainMenuViewModel :INotifyPropertyChanged
    {
        public event GameEndEventHandler GameEnds;
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(name));
        }
        
        /*
         *Csak a seed és a játékmód miatt kell
         */

        gamemode_type selectedGamemode;

        public gamemode_type SelectedGamemode
        {
            get{ return selectedGamemode; }
            set{ selectedGamemode = value; OnPropertyChanged(); }
        }

        public Array GameModeList
        {
            get { return Enum.GetValues(typeof(gamemode_type)); }
        }
    }
}
