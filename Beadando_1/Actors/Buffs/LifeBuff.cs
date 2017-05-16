using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando_1
{
    class LifeBuff : BaseBuff
    {
        public LifeBuff(float x, float y, int height, int width, bool vis) : base(x, y, height, width, vis, 0, "HealthBuff")
        {

        }

        public override void Effect(Player player)
        {
            if (player.Health < player.MaxHealth)
            {
                player.Damaged(-1);
            }
        }
    }
}
