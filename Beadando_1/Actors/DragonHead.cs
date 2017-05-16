using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando_1
{
    class DragonHead :Dragon
    {
        public DragonHead(float x, float y, int height, int width, float speed, float jump, bool vis) 
            : base(x, y, height, width, speed, jump, vis, 1, "DragonHead")
        {
            MainWindow.timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            X--;
            Y = ((float)Math.Sin(0.1*X)*30)+500;

            if (X < -100)
            {
                Visible = false;
            }
        }

        public override void Utkozes(Pawn param1)
        {
            if (param1 is BuffUseEffect)
            {
                Damaged(1);
                base.Utkozes(param1);
            }
        }
    }
}
