using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Beadando_1
{
    public delegate void GameEndEventHandler(object sender, string winner);
    class GameViewModel :INotifyPropertyChanged
    {
        public event GameEndEventHandler GameEnds;
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(name));
        }

        protected void OnGameEnd(string winner)
        { //játék vége esemény
            if (GameEnds != null)
                GameEnds(this, winner);
        }

        public static  BindingList<Pawn> actors { get;  set; }
        public List<PlayerController> pc { get; private set; }
        public List<StaticActorController> stac { get; private set; }

        public string Stats
        { //felirat "trükkös" frissítése
            get { stats = gm.Scores(); return stats; }
            set{ stats = gm.Scores(); OnPropertyChanged(); }
        }

        MapGenerator mg;
        GameMode gm;
        
        public GameViewModel(GameMode gm, int seed)
        {//ez is null az is null minden NULL!!
            actors = null;
            actors = new BindingList<Pawn>();
            pc = null;
            pc = new List<PlayerController>();
            stac = null;
            stac = new List<StaticActorController>();
            mg = null;
            mg = new MapGenerator(seed);
            this.gm = gm; //játékmód
            Setup();
            StartPosition();
        }

        string stats;

        private void StartPosition()
        {//kezdő pozíciók beállítása
            int i = 0;
            int j = 0;
            foreach (Pawn akt in actors)
            { //pőlaytformok egymás után rendezése
            //(át kellene tenni a létrehozáshoz)
                if (akt is Platform)
                {
                    akt.X = 0 + 101 * i;
                    akt.Y = 650;
                    i++;
                } else
                {//játékosok elhelyezése
                //(ezt is)
                    akt.X = 10 + 20 * j;
                    akt.Y = 10 + 5 * j;
                    j++;
                }
            }

            foreach (Pawn akt in actors)
            { //CSAK A JÁTÉK ELEJÉN!!!
                if (akt is Player)
                {//irányítás hozzárendelése a játékosokhoz
                    pc.Add(new PlayerController((Player)(akt)));
                }
                if (!(akt is Character))
                {//irányítás a nem játékosokhoz
                    stac.Add(new StaticActorController(akt));
                }
            }
        }
        
        private void ExtremeGenerate()
        {
            int posy = mg.NewY();
                switch (MapGenerator.RandomInt(1,15))
                {
                    case 1 : actors.Add(new SpeedBuff(1050, posy, 20,20, true));
                        stac.Add(new StaticActorController(actors.Last()));
                        break;
                    case 2 : actors.Add(new SlowBuff(1050, posy, 20, 20, true));
                        stac.Add(new StaticActorController(actors.Last()));
                        break;
                    case 3 : actors.Add(new LifeBuff(1050, posy, 20, 20, true));
                        stac.Add(new StaticActorController(actors.Last()));
                        break;
                    case 4:actors.Add(new JumpBuff(1050, posy, 20, 20, true));
                        stac.Add(new StaticActorController(actors.Last()));
                        break;
                    case 5: actors.Add(new RiotFistBuff(1050, posy, 40, 40, true));
                        stac.Add(new StaticActorController(actors.Last()));
                        break;
                    case 6: actors.Add(new BeamBuff(1050, posy, 25, 25, true));
                        stac.Add(new StaticActorController(actors.Last()));
                        break;
                    case 7: actors.Add(new Mario(1050, posy, 40, 40, true));
                        stac.Add(new StaticActorController(actors.Last()));
                        break;
                    case 8: actors.Add(new TrickyPlatform(1050, posy, 20, 100, true));
                        stac.Add(new TrickyPlatformController(actors.Last(), (actors.Last() as TrickyPlatform)));
                        break;
                }
        }
        
        private void Rendrakás()
        {
            foreach (Pawn akt in actors)
            {//minden elemre
                if (akt is Player && (akt as Player).Falling == false)
                { //alap hejzetbe álltja a player szükséges értékeit nehogy lebegve maradjon
                    Player play = akt as Player;
                    play.Falling = true;
                    play.Standing = false;
                    play.Invincible = false;
                    if (gm is PracticeGameMode && play.Health != play.MaxHealth)
                    {//maximumra állítja a játékos életét ha a játékmód gyakorló
                        play.Damaged(-1);
                    }
                } else if(akt is Platform && akt.X < -100)
                { //ha egy platform kimegy a képből visszarakja az elejére
                    akt.X = 1050;
                    akt.Y = mg.NewY(); //random magasság
                    (akt as Platform).Speed = MapGenerator.RandomInt(1,3); //random sebesség
                } else if (akt.X < -101)
                {//ha nem platform és kiér akkor meghal
                    akt.Visible = false;
                }
                if (akt is Player && (!(akt as Player).MoveL || !(akt as Player).MoveR))
                {
                    (akt as Player).CanMove = true;
                }
                foreach (Pawn inakt in actors)
                {//ütközés vizsgálat mindent mindennel :)
                    if (CollisionAB.Collide(akt, inakt))
                    {
                        akt.Utkozes(inakt);
                    }
                }
            }
        }

        public void GameLogic(object sender, EventArgs e)
        {
            if (gm is ExtremeGameMode && mg.RandomPercent(1))
            {//Extrém generálás
                ExtremeGenerate();
            }
            
            OnPropertyChanged("Stats"); //kiírás frissítése
            
            List<Pawn> actors2 = actors.ToList();
            foreach (Pawn akt in actors2)
            { //a halottak összetakarítása
                if (akt.Visible == false)
                {
                    actors.Remove(akt);
                    stac.Remove(stac.Find(a=>a.Equals(akt)));
                    pc.Remove(pc.Find(a => a.Equals(akt)));
                }
            }
            actors2.Clear();
            Rendrakás();
            
            if (gm.GameEnd(actors.ToList()))
            {//esemény játék vége hívás
                OnGameEnd(gm.Scores());
            }

            if (mg.RandomPercent(1))
            {//esély van új pontra
                actors.Add(new Point(1050,  mg.NewY(), 10, 10, true, 1));
                stac.Add(new StaticActorController(actors.Last()));//a pont mozogjon is 
            }
        }

        private void Setup()
        {
            List<Pawn> a = new List<Pawn>(gm.CreatePlayer());
            foreach (Pawn akt in a)
            {//játékosok létrehozása
                actors.Add(akt);
            }
            BindingList<Pawn> pl = new BindingList<Pawn>(gm.CreatePlatforms());
            foreach (Pawn akt in pl)
            {//playtformok létrehozása
                actors.Add(akt);
            }
        }
    }
}