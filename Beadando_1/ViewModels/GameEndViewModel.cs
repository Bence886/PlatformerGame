using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Beadando_1
{
    class GameEndViewModel :INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(name));
        }

        public GameEndViewModel(string sc)
        {//kiírja az eredményt
        //esetleg fájlba is de nem
            Score = sc;
        }

        string score;

        public string Score
        {
            get
            {
                return score;
            }

            set
            {
                score = value; OnPropertyChanged();
            }
        }
    }
}
