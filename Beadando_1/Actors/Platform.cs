using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando_1
{
    class Platform : Pawn
    {
        public Platform(float x, float y,int height, int width, bool vis, string alak) : base(x, y,height, width, vis, alak)
        {
            speed = 1;
        }
        int speed;

        public int Speed
        {
            get
            {
                return speed;
            }

            set
            {
                speed = value;
            }
        }
    }
}