using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando_1
{
    class GlassBrokeEffect:Pawn
    {
        public GlassBrokeEffect(float x, float y, int height, int width, bool vis) : base(x, y, height, width, vis, "BrokenGlass")
        {
            MainWindow.timer.Tick += Timer_Tick;
            end = DateTime.Now.AddSeconds(10);
            GameViewModel.actors.Add(this);
        }
        DateTime end;

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (end< DateTime.Now)
            {
                Visible = false;
            }
        }
    }
}
