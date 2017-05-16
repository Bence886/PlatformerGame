using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando_1
{
    class Enemy :Character
    {
        public Enemy(float x, float y, int height, int width, float speed, float jump, bool vis, int maxHealth, string alak) 
            : base(x, y, height, width, speed, jump, vis, maxHealth, alak, 30)
        {

        }

        public override void Utkozes(Pawn param1)
        {
            
        }
    }
}
