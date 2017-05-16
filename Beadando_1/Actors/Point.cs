using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando_1
{
    public delegate void GetPointhandler(object sender, string name, int val);

    class Point : Pawn
    {
        public event GetPointhandler GetPoints;
        protected void Collected(string name)
        {//pont szerzés event
            if (GetPoints != null)
                GetPoints(this, name, value);
        }

        public Point(float x, float y, int height, int width, bool vis, int value) 
            : base(x, y, height, width, vis, "Point")
        {
            this.value = value;
            GetPoints += GameMode.Score;
        }

        int value;

        public int Value
        {
            get { return value; }
        }

        public override void Utkozes(Pawn param1)
        { //eventel átadja a GameMode-nak a játékost aki pontot szerzett
            if (param1 is Player)
            {
                Collected((param1 as Player).Name);
                this.Visible = false;
            }
        }
    }
}
