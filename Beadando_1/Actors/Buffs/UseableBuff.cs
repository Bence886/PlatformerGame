using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando_1
{
    class UseableBuff :BaseBuff
    {
        public UseableBuff(float x, float y, int height, int width, bool vis, string alak) : base(x, y, height, width, vis, 1, alak)
        {

        }

        public virtual void Use(Player player)
        {

        }
    }
}
