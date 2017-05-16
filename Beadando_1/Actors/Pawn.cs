using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Beadando_1
{
    abstract class Pawn :INotifyPropertyChanged
    {
        public Pawn(float x, float y,int height, int width, bool vis, string alak)
        {
            this.x = x;
            this.y = y;
            this.height = height;
            this.width = width;
            visible = vis;
            this.alak = alak;
        }


        private float x;
        private float y; //position of the left top corner
        int height, width;
        private bool visible; //visibility (collision maybe if additional collision not needed)
        string alak; //a textúra neve

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(name));
        }

        public string Alak
        {
            get { return alak; }
        }

        public int Height
        {
            get { return height; }
            set { height = value; OnPropertyChanged(); }
        }
        public int Width
        {
            get { return width; }
            set { width = value; OnPropertyChanged(); }
        }

        public bool Visible
        {
            get{ return visible;}
            set{ visible = value;}
        }

        public float X
        {
            get{ return x; }
            set { x = value; OnPropertyChanged(); }
        }

        public float Y
        {
            get{ return y; }
            set { y = value; OnPropertyChanged(); }
        }
        public virtual void Utkozes(Pawn param1) { }
    }
}
