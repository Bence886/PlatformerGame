using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Beadando_1
{
    class SinglePlayerViewModel :INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(name));
        }

        string name= "Játékos"; //alap név
        Characters[] chars;
        Characters selected;
        int db;
        public SinglePlayerViewModel()
        {
            db = 0; //alap karakter
            chars = CharacterGen.GetCharacters();//karakterek lekérése
            selected = chars[db];//kiválasztott karakter
        }

        public void Left(object sender, RoutedEventArgs e)
        {//karakter váltás oda
            if (++db > chars.Length-1)
            {
                db = 0;
            }
            Selected = chars[db];
        }

        public void Right(object sender, RoutedEventArgs e)
        {//vissza
            if (--db < 0)
            {
                db = chars.Length-1;
            }
            Selected = chars[db];
        }

        public Characters Selected
        {
            get
            {
                return selected;
            }

            set
            {
                selected = value; OnPropertyChanged();
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value; OnPropertyChanged();
            }
        }
    }
}
