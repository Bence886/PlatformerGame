using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando_1
{
    abstract class Character :Pawn
    {
        public Character(float x, float y, int height, int width, float speed, float jump, bool vis, int maxHealth, string alak, int id) 
            : base(x, y, height, width, vis, alak)
        {
            this.speed = speed;
            this.jumpHeight = jump;
            this.maxHealth = maxHealth;
            Health = maxHealth;
            this.playerId = id;
        }

        int maxHealth; //maximum élet a konstruktorból beállítva NEM módosítható
        int playerId;
        int health; //aktuálsi élet nem leht több a maximum életnél módosítható
        float speed;
        float jumpHeight;
        bool invincible = true;
        bool moveL = false;
        bool moveR = false;
        bool canMove = true;

        public float JumpHeight
        {
            get { return jumpHeight; }
            set { jumpHeight = value; }
        }

        public float Speed
        {
            get { return speed; }
            set { speed = value; OnPropertyChanged(); }
        }

        public int MaxHealth
        {
            get{ return maxHealth; }
        }

        public int Health
        {
            get{ return health; }
            private set { health = value; OnPropertyChanged(); }
        }

        public bool Invincible
        {
            get{ return invincible; }
            set{ invincible = value; }
        }

        public bool MoveL
        {
            get{ return moveL; }
            set{ moveL = value; }
        }

        public bool MoveR
        {
            get{ return moveR; }
            set{ moveR = value; }
        }

        public bool CanMove
        {
            get{ return canMove; }
            set{ canMove = value; }
        }

        public void Damaged(int a)
        { //+sebződés -gyógyulás
            if (!invincible)
            {
                Health -= a;
                if (Health > maxHealth)
                { //ha többre gyógyulna mint a max akkor max-ra állítja
                    Health = maxHealth;
                }
                if (Health == 0)
                { //ha 0 az élete meg halt
                    Died();
                }
            }
            GameMode.ChangeHealth(playerId, health);
            OnPropertyChanged("Health");
        }

        protected virtual void Died()
        {
            base.Visible = false;
        }
    }
}
