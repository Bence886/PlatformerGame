using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando_1
{
    class UsedMario :BuffUseEffect
    {
        public UsedMario(float x, float y, int height, int width, bool vis, string alak, Player player) : base(x, y, height, width, vis, alak, player)
        {
            tox = (int)player.X;
            toy = (int)player.Y-100;
            CanDamage = true;
            met = new List<string>();
        }
        int toy;
        int tox;
       
        protected override void Timer_Tick(object sender, EventArgs e)
        {
            if (X > 1500)
            {
                Visible = false;
            }
            if (Y < toy)
            {
                Y+=5;
            } else
            {
                X++;
            }
        }
        List<string> met;

        public override void Utkozes(Pawn param1)
        {
            if ((param1 is Character) && !met.Exists(a=>a == param1.Alak))
            {
                met.Add(param1.Alak);
                (param1 as Character).Damaged(1);
            }
        }
    }
}
