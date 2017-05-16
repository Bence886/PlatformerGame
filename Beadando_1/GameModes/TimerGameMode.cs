using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando_1
{
    class TimerGameMode : GameMode
    {
        int end;
        public TimerGameMode(List<Gamer> names) : base(names)
        {
            end = (DateTime.Now.Second -1);
        }

        public override bool GameEnd(List<Pawn> a)
        {//kilépési feltétel egy perc letelése
            if (DateTime.Now.Second == end || !a.Exists(b => b is Player))
            {
                return true;
            }
            return false;
        }
    }
}
