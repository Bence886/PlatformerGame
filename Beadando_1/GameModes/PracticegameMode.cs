using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando_1
{
    class PracticeGameMode :GameMode
    {
        public PracticeGameMode(List<Gamer> names) : base(names)
        { }

        public override bool GameEnd(List<Pawn> a)
        {//sosincs játék vége
            return false;
        }
    }
}
