using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Beadando_1
{
    class OptionsViewMenu :INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string name = "")
    {
        PropertyChangedEventHandler handler = PropertyChanged;
        if (handler != null) handler(this, new PropertyChangedEventArgs(name));
    }
    int seed;



        public int Seed
        {
            get
            {
                return seed;
            }

            set
            {
                seed = value; OnPropertyChanged();
            }
        }
    }
}