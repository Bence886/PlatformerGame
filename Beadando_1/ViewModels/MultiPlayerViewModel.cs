using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Beadando_1
{
    class MultiPlayerViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(name));
        }

        string name = "Játékos";
        Characters[] chars;
        Characters selected;
        Key jumpk;
        Key leftk;
        Key rightk;
        Key buf;

        public List<Gamer> players { get; private set; }
        int db;
        public MultiPlayerViewModel()
        {
            db = 0;
            players = new List<Gamer>();
            chars = CharacterGen.GetCharacters();
            selected = chars[db];
            jumpk = Key.Up;
            leftk = Key.Left;
            rightk = Key.Right;
            buf = Key.Space;
        }

        public void Left(object sender, RoutedEventArgs e)
        {
            if (++db > chars.Length - 1)
            {
                db = 0;
            }
            Selected = chars[db];
        }

        public void Right(object sender, RoutedEventArgs e)
        {
            if (--db < 0)
            {
                db = chars.Length - 1;
            }
            Selected = chars[db];
        }

        public void AddNext(object sender, RoutedEventArgs e)
        {
            if (players.Count < 24)
            {//játékos hozzáadása értékek alap helyzetbe állítása
                players.Add(new Gamer(name, selected, jumpk, leftk, rightk, buf, players.Count));
                name = "Játékos_" + players.Count;
                jumpk = Key.Up; OnPropertyChanged("Jumpk");
                leftk = Key.Left; OnPropertyChanged("Leftk");
                rightk = Key.Right; OnPropertyChanged("Rightk");
                buf = Key.Space; OnPropertyChanged("Buf");
                OnPropertyChanged("Name");
            }
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
        /*gombok bekérése gyönyörű kasztolással*/
        public string Jumpk
        {
            get
            {
                return jumpk.ToString();
            }
            set
            {
                try
                {
                    jumpk = (Key)Enum.Parse(typeof(Key), value.ToUpper()); OnPropertyChanged();
                }
                catch
                {
                    jumpk = Key.Space; OnPropertyChanged();
                }
            }
        }

        public string Leftk
        {
            get
            {
                return leftk.ToString();
            }
            set
            {
                try
                {
                    leftk = (Key)Enum.Parse(typeof(Key), value.ToUpper()); OnPropertyChanged();
                }
                catch (ArgumentException)
                {
                    leftk = Key.Left; OnPropertyChanged();
                }
            }
        }

        public string Rightk
        {
            get
            {
                return rightk.ToString();
            }

            set
            {
                try
                {
                    rightk = (Key)Enum.Parse(typeof(Key), value.ToUpper()); OnPropertyChanged();
                }
                catch (System.ArgumentException)
                {
                    rightk = Key.Right; OnPropertyChanged();
                }
            }
        }

        public string Buf
        {
            get
            {
                return buf.ToString();
            }

            set
            {
                try
                {
                    buf = (Key)Enum.Parse(typeof(Key), value.ToUpper()); OnPropertyChanged();
                }
                catch (ArgumentException)
                {
                    buf = Key.Space; OnPropertyChanged();
                }
            }
        }
    }
}

