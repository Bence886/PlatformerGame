using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando_1
{
    class TrickyPlatform : Platform
    {
        public TrickyPlatform(float x, float y, int height, int width, bool vis) :base(x, y, height, width, vis, "TrickyPlatform")
        {
        }

        bool utkozott = false;

        public bool Utkozott
        {
            get
            {
                return utkozott;
            }

            private set
            {
                utkozott = value;
            }
        }

        public override void Utkozes(Pawn param1)
        { //ha játékossal ütközik akkor elkezd leesni
            if (param1 is Player)
            {
                Utkozott = true;
            }
        }
    }
}
