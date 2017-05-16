using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando_1
{
    class RiotFistBuff :UseableBuff
    {
        public RiotFistBuff(float x, float y, int height, int width, bool vis) : base(x, y, height, width, vis, "Fist")
        {

        }

        public override void Use(Player player)
        {
            float x = player.X;
            float y = player.Y;

            BuffUseEffect buf = new BuffUseEffect(x, y, 10, 10, true, "Fist", player);

        }
    }
}
