using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando_1
{
    class StaticActorController
    {
        Pawn pawn;
        public StaticActorController(Pawn pwn)
        {
            this.pawn = pwn;//ezt irányítja
            MainWindow.timer.Tick += Timer; //timerre feliratkozik
        }
        public void Timer(object sender, EventArgs e)
        {
            if (pawn is Point && pawn.X <0)
            {//ha kiment a képből "meghal"
                pawn.Visible = false;
            }
            if (pawn is Platform)
            {//ha platform akkor sebességnyit mozog
                pawn.X -= (pawn as Platform).Speed;
            } //a mozgás sebessége esetleges nehézségi beállítás
            else
            {//minden más egyet
                pawn.X -= 1;
            }
        }
    }
}
