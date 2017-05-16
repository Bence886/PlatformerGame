using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando_1
{
    class Mario :UseableBuff
    {
        public Mario(float x, float y, int height, int width, bool vis) : base(x, y, height, width, vis, "Mario_Mixer")
        {

        }

        public override void Use(Player player)
        {
            BuffUseEffect buf = new UsedMario(player.X, -10, 224, 128, true, "Mario_Mixer", player);
            //player.Damaged(1); //túl erős ezért egy életet is levesz :D
        }

    }
}
