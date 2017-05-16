using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando_1
{
    class GameMode
    {
        public static List<Gamer> player { get; private set; }
        public GameMode(List<Gamer> players)
        {
            player = new List<Gamer>();
            player = players;//megkapja a létrehozandó játékosokat
        }
        public List<Pawn> CreatePlayer()
        { //név, x, y, magasság, szélesség, gyorsaság, ugrás magasság, láthatóság (collision), maxÉlet   esetleges több karakternél lehetnének paraméterből beszedve
            List<Pawn> a = new List<Pawn>();
            foreach (Gamer akt in player)
            {//létrehozza a játékosokat amik majd megjelennek
                akt.Health = akt.Character.Health;
                a.Add(new Player(akt.Name, -10, -10, akt.Character.Height, akt.Character.Width, akt.Character.Speed, akt.Character.JumpHeight, true, akt.Character.Health, akt.Character.Alak, akt.Jumpk, akt.Left, akt.Right, akt.Buf, akt.PlayerId));
            }
            return a;
        }

        public static void ChangeHealth(int id, int health)
        {//a kiírás frissítéséhez szükséges
            if (player.Exists(a => a.PlayerId == id))
            {
                player.FindLast(a => a.PlayerId == id).Health = health;
            }
        }

        public BindingList<Pawn> CreatePlatforms()
        { //playtformok létrehozása
            BindingList<Pawn> pl = new BindingList<Pawn>();

            for (int i = 0; i < 10; i++)
            {
                pl.Add(new Platform(-10, -10, 20, 100, true, "Platform"));
            }
            return pl;
        }

        public static void Score(object sender, string name, int val)
        {//játékos pontot szerez
            player.Find(a => a.Name == name).Points += val;
        }

        public string Scores()
        {//eredmények visszaadása player/sor
            string a="";
            foreach (Gamer akt in player)
            { //az élet mért em frissül? ha OnPropChanged hívva van és a pontmért frissül ha nincs?!
                a += string.Format("Név: {0} Pont: {1} Élet:{2} {3}", akt.Name, akt.Points, akt.Health, Environment.NewLine);
            }
            return a;
        }

        public virtual bool GameEnd(List<Pawn> a)
        {//játék vége feltétel vizsgálata
            if (!a.Exists(b => b is Player))
            {
                return true;
            }
            return false;
        }
    }
}
