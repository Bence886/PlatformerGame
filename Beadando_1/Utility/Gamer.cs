using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Beadando_1
{
    class Gamer
    {//a menühöz és a GameMode-hoz szükséges
    //a fizikai (ember) játékost reprezentálja
        public Gamer(string a, Characters b, Key jumpk, Key left, Key right, Key buf, int id)
        {
            Name = a;
            Character = b;
            this.jumpk = jumpk;
            this.left = left;
            this.right = right;
            this.buf = buf;
            health = b.Health;
            this.PlayerId = id;
        }

        int playerId;
        Key jumpk;
        Key left;
        Key right;
        Key buf;
        string name;
        int health;
        Characters character;
        int points;

        public int Points
        {
            get
            {
                return points;
            }

            set
            {
                points = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        internal Characters Character
        {
            get
            {
                return character;
            }

            set
            {
                character = value;
            }
        }

        public Key Jumpk
        {
            get
            {
                return jumpk;
            }
        }

        public Key Left
        {
            get
            {
                return left;
            }
        }

        public Key Right
        {
            get
            {
                return right;
            }
        }

        public Key Buf
        {
            get
            {
                return buf;
            }
        }

        public int Health
        {
            get
            {
                return health;
            }

            set
            {
                health = value;
            }
        }

        public int PlayerId
        {
            get
            {
                return playerId;
            }

            set
            {
                playerId = value;
            }
        }
    }
}
