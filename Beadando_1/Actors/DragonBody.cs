using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando_1
{
    class DragonBody :Dragon
    {

        Dragon Prewious;
        Dragon next;

        public Dragon Prewious1
        {
            get
            {
                return Prewious;
            }

            set
            {
                Prewious = value;
            }
        }
        public Dragon Next
        {
            get
            {
                return next;
            }

            set
            {
                next = value;
            }
        }

        public DragonBody(float x, float y, int height, int width, float speed, float jump, bool vis, Dragon prew, Dragon next) 
            : base(x, y, height, width, speed, jump, vis, 1, "DragonBody")
        {
            Prewious1 = prew;
            this.Next = next;
            MainWindow.timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (Prewious1.Visible == true)
            {
                X = Prewious1.X + 50;
                Y = ((float)Math.Sin(0.1 * X) * 30) + 500;
            } else if (Prewious is DragonHead && next != null)
            {
                GameViewModel.actors.Remove(this);
                (next as DragonBody).Prewious = new DragonHead(X-50, Y, 50, 50, 0, 0, true);
                GameViewModel.actors.Add((next as DragonBody).Prewious);
            }
            if (Prewious.Visible == false)
            {
                X--;
                Y = ((float)Math.Sin(0.1 * X) * 30) + 500;
            }

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
