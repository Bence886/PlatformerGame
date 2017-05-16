using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando_1
{
    abstract class BaseBuff :Pawn
    { //base class of the positive / negative buffs

        public BaseBuff(float x, float y,int height, int width, bool vis, int duration, string alak) : base(x, y, height, width, vis, alak)
        {
            this.DefaultDuration = duration;
        }

        int defaultDuration; //the duration of the buff

        //the current time of the buff can be more than the default duration if more of the seme buff is collected
        int currentDuration;
        DateTime end;

        public int CurrentDuration
        {
            get{ return currentDuration; }
            set{ currentDuration = value; }
        }

        public int DefaultDuration
        {
            get{ return defaultDuration; }
            private set { defaultDuration = value; }
        }

        public DateTime End
        {
            get
            {
                return end;
            }

            set
            {
                end = value;
            }
        }

        public void Collected()
        {
            CurrentDuration += DefaultDuration;
        }

        public override void Utkozes(Pawn param1)
        {
            if (param1 is Player)
            {
                base.Visible = false;
            }
        }

        public virtual void Effect(Player player)
        {
        }

        public virtual void Clear(Player play)
        {

        }
    }
}
