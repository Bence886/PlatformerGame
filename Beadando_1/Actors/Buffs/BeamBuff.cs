using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando_1
{
    class BeamBuff :UseableBuff
    {
        public BeamBuff(float x, float y, int height, int width, bool vis) : base(x, y, height, width, vis, "BeamItem")
        {

        }

        public override void Use(Player player)
        {
            float x = player.X;
            float y = player.Y;

            BuffUseEffect buf = new BuffUseEffect(x, y, 10, 10, true, "Beam", player);

        }
    }
}
