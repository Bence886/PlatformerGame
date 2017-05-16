using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando_1
{
    class JumpBuff : BaseBuff
    {
        public JumpBuff(float x, float y, int height, int width, bool vis) : base(x, y, height, width, vis, 1, "JumpBuff")
        {

        }

        public override void Effect(Player player)
        {
            player.JumpHeight += 100;
        }

        public override void Clear(Player play)
        {
            play.JumpHeight -= 100;
        }
    }
}
