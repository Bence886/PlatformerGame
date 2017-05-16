using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando_1
{
    class BuffUseEffect :Pawn
    {
        public Player player { get; private set; }
        public BuffUseEffect(float x, float y, int height, int width, bool vis, string alak, Player player) : base(x, y, height, width, vis, alak)
        {
            this.player = player;
            MainWindow.timer.Tick += Timer_Tick;
            startWidth = width;
            GameViewModel.actors.Add(this);
        }
        int startWidth;
        bool canDamage = false;

        public bool CanDamage
        {
            get
            {
                return canDamage;
            }

            set
            {
                canDamage = value;
            }
        }

        protected virtual void Timer_Tick(object sender, EventArgs e)
        {
            if (Alak == "Beam")
            {
                canDamage = true;
                if (Width < 299)
                {
                    X = player.X + 50;
                    Y = player.Y -80;
                    Height = 190;
                    Width = startWidth+=5;
                } else
                {
                    Visible = false;
                }
            } else
            {
                if (Width < startWidth * 10)
                {
                    Height += 1;
                    Width += 1;
                }
                if (Width >= startWidth * 10)
                {
                    CanDamage = true;
                    Height += 1;
                    Width += 1;
                }
                if (Width > startWidth * 20)
                {
                    //GlassBrokeEffect gb = new GlassBrokeEffect(X, Y - 100, 500, 250, true);
                    MainWindow.timer.Tick -= Timer_Tick;
                    Visible = false;
                }
            }
        }

        public override void Utkozes(Pawn param1)
        {
            if (canDamage && param1 is Player)
            {
                Visible = false;
            }
        }
    }
}
