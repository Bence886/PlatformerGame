using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando_1
{
    class TrickyPlatformController :StaticActorController
    { //lezuhanó platform irányítása
        TrickyPlatform pl;
        public TrickyPlatformController(Pawn pwn, TrickyPlatform pl) : base (pwn)
        {
            this.pl = pl;//ezt irányítja
            MainWindow.timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (pl.Utkozott)
            {//ha ütközött zuhan
                pl.Y++;
            }
            else
            {//egyébként rendesen viselkedik
                pl.X -= pl.Speed;
            }
            if (pl.Y > 650 || pl.X < -99)
            {//meghal ha kiér (nem kerül vissza mint a sima platform[?])
                pl.Visible = false;
            }
        }
    }
}
