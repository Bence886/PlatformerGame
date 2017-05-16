using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando_1
{ 
    class SpeedBuff :BaseBuff
    {
        public SpeedBuff(float x, float y, int height, int width, bool vis) : base(x, y, height, width, vis, 1, "SpeedBuff")
        {
            
        }

        public override void Effect(Player player)
        {
            player.Speed -= 2;
        }

        public override void Clear(Player play)
        {
            play.Speed += 2;
        }
    }
}
