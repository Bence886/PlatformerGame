using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando_1
{
    class CollisionAB
    {
        public static bool Collide(Pawn rect1, Pawn rect2)
        {//ütközés
            if (rect1.X < rect2.X + rect2.Width && //A-bal oldala jobbrább van mint B-jobb oldala
                rect1.X + rect1.Width > rect2.X && // A-jobb oldala balrább van mint B-bal oldala 
                rect1.Y < rect2.Y + rect2.Height && // A-teteje feljebb van mint B-allja
                rect1.Height + rect1.Y > rect2.Y) //A-allja lejebb van mint B-teteje
                    return true;

            return false;
        }
        /*
            if (rect1.X < rect2.X + rect2.Width &&
                rect1.X + rect1.Width > rect2.X &&
                rect1.Y < rect2.Y + rect2.Height &&
                rect1.Height + rect1.Y > rect2.Y)*/
    }
}
