using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Beadando_1
{
    class Characters : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(name));
        }
        public Characters(int health, int speed, int jumpHeight, int height, int width, string alak)
        {//az alap karakterek típusa
        /*azért nem jó a Player osztály mert ez a játéktérben nem jelenik meg csak a menüben ezért sok felesleges értéke lenne*/
            this.health = health;
            this.speed = speed;
            this.jumpHeight = jumpHeight;
            this.height = height;
            this.width = width;
            this.alak = alak;
        }

        int health;
        int speed;
        int jumpHeight;
        int height;
        int width;
        string alak;

        public int Health
        {
            get
            {
                return health;
            }

            set
            {
                health = value; OnPropertyChanged();
            }
        }

        public int Speed
        {
            get
            {
                return speed;
            }

            set
            {
                speed = value; OnPropertyChanged();
            }
        }

        public int JumpHeight
        {
            get
            {
                return jumpHeight;
            }

            set
            {
                jumpHeight = value; OnPropertyChanged();
            }
        }

        public int Height
        {
            get
            {
                return height;
            }

            set
            {
                height = value;
            }
        }

        public int Width
        {
            get
            {
                return width;
            }

            set
            {
                width = value;
            }
        }

        public string Alak
        {
            get
            {
                return alak;
            }

            set
            {
                alak = value; OnPropertyChanged();
            }
        }
    }
}
