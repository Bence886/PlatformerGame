using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Beadando_1
{
    class Player :Character
    {
        public Player(string name, float x, float y, int height, int width, float speed, float jump, bool vis, int maxHealth, string alak, Key jumpk, Key left, Key right, Key buf, int id) 
            : base(x, y, height, width, speed, jump, vis, maxHealth, alak, id)
        {
            ActiveBuffs1 = new List<BaseBuff>();
            this.name = name;
            this.Jumpk = jumpk;
            this.Left = left;
            this.Right = right;
            this.Buf = buf;
        }

        List<BaseBuff> ActiveBuffs; //active buffs on the player
        UseableBuff skill; //az elnyomható buff (alap gomb a space)
        string name; //a játékos neve a sebző dolgok felveszik hogy őt már sebezték így csak egyszer sebződik és nem hal meg azonnal
        bool jumping = false;
        bool falling = true;
        bool standing = false;
        float fallSpeed = 1.5f;
        Key jumpk;
        Key left;
        Key right;
        Key buf;

        protected override void Died()
        {
            base.Visible = false;
            jumping = false;
            falling = false;
            standing = true;
        }

        public void Timer(object sender, EventArgs e)
        {//a passzív buffok idejét számolja / velszi le
            List<BaseBuff> a = new List<BaseBuff>(ActiveBuffs1);
            foreach (BaseBuff akt in a)
            {
                if (akt.End < DateTime.Now)
                {
                    akt.Clear(this);
                    ActiveBuffs1.Remove(akt);
                }
            }
        }

        public bool Standing
        {
            get { return standing; }
            set { standing = value; }
        }

        public string Name
        {
            get{ return name; }
        }

        public bool Jumping
        {
            get{ return jumping; }
            set{ jumping = value; }
        }

        public bool Falling
        {
            get { return falling; }
            set { falling = value; }
        }

        public float FallSpeed
        {
            get{ return fallSpeed; }
            set{ fallSpeed = value; }
        }

        public Key Jumpk
        {
            get
            {
                return jumpk;
            }

            private set
            {
                jumpk = value;
            }
        }

        public Key Left
        {
            get
            {
                return left;
            }

            private set
            {
                left = value;
            }
        }

        public Key Right
        {
            get
            {
                return right;
            }

            private set
            {
                right = value;
            }
        }

        public Key Buf
        {
            get
            {
                return buf;
            }

            private set
            {
                buf = value;
            }
        }

        internal List<BaseBuff> ActiveBuffs1
        {
            get
            {
                return ActiveBuffs;
            }

            set
            {
                ActiveBuffs = value;
            }
        }

        internal UseableBuff Skill
        {
            get
            {
                return skill;
            }

            set
            {
                skill = value;
            }
        }

        public override void Utkozes(Pawn param1)
        {//mivel ütközik a játékos?
            if (param1 is Enemy)
            { //nincs is ellenfél :(
                base.Damaged(1); //if the player collides with an Enemy it gets damaged by 1
            }
            if (param1 is BaseBuff)
            {
                AddBuff(param1 as BaseBuff); //collects a buff
            }
            if (param1 is Platform) //ha platformmal ütközik
            {
                PlatformCollide(param1 as Platform);//meg kell nézni merről ért hozzá
            }
            if (param1 is BuffUseEffect && (param1 as BuffUseEffect).CanDamage)
            {
                if (!(param1 is UsedMario))
                { //ha nem márió akkor egyet sebződik
                /* a máriónál ott van megoldva a sebzés,
                 * minden más eltűnik ha játékoshoz ér így nem lehet vele sokat vigéckedni :D
                 */
                    Damaged(1);
                }
            }
        }

        private void PlatformCollide(Platform pl)
        {//merről mentem platformnak?
            if (X < pl.X)
            {//bal
                //Jumping = false;
                //MoveL = false;
                //falling = true;              
                //X -= 5;
                //CanMove = false;
            }
            if (X > pl.X + pl.Width)
            {//jobb
                //Jumping = false;
                //MoveR = false;
                //falling = true;
                //X += 5;
                //CanMove = false;
            }
            if (Y > pl.Y)
            {//fent
                Jumping = false;
                falling = true;
            }else
            if (Y < pl.Y + pl.Height)
            {//lent
                falling = false;
                jumping = false;
                standing = true;
            }
        }

        private void AddBuff(BaseBuff param1) //buffolgatás
        {
            if (param1 is UseableBuff)
            {//ha van akkor felül írja a buffot
                skill = param1 as UseableBuff;
            } else
            {//az életet nem adjuk hozzá az instant gyógyít
                if (!ActiveBuffs1.Exists(a => a.Alak == param1.Alak) && !(param1 is LifeBuff))
                { //a passzív buffok nem gyűjtehtők egymásra az idő nem adódik össze
                    ActiveBuffs1.Add(param1);
                    ActiveBuffs1.Last().End = DateTime.Now.AddMinutes(1);
                    param1.Effect(this);
                } else if (param1 is LifeBuff)
                {
                    Damaged(-1);//itt gyúgyít az élet
                }
            }
        }
        

    }
}