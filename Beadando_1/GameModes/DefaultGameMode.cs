using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando_1
{
    class DefaultGameMode :GameMode
    {
        public DefaultGameMode(List<Gamer> names) : base(names)
        {//öröklés miatt kell
        }
    }
}
