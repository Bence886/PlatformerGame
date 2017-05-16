    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Beadando_1
{
    //public delegate void SecTic(object sender, int sec);
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(15);
        }

        //public event SecTic GetSecondTick;
        /*protected void CallSecondTick(int sec)
        {
            if (GetSecondTick != null) GetSecondTick(this, sec);
        }*/

        GameViewModel gvm;
        MainMenuViewModel mmvm;
        List<Gamer> players;
        SinglePlayerViewModel spvm;
        MultiPlayerViewModel mpvm;
        OptionsViewMenu ovm;
        GameEndViewModel gevm;
        GameMode gm;
        int seed = 0;

        public static DispatcherTimer timer;
        Grid g;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            players = new List<Gamer>();
            g = Content as Grid; //a g legyen a grid hogy lehessen hozzáadogatni
            CreateMainMenu();
            //timer.Tick += Timer_Tick;
        }

        /*private void Timer_Tick(object sender, EventArgs e)
        {
            bool called = false; 
            if (DateTime.Now.Second==0 && !called)
            {
                CallSecondTick(DateTime.Now.Minute);
                called = true;
            }//ha gyorsabb a tick mint 1 mp akkor többször is meg hívódna mint kell
            if (called && DateTime.Now.Second == 10)
            {
                called = false;
            }
        }*/
        
        private void CreateMainMenu()
        {
            Log.Message("Menü létrehozva.");
            gm = null;
            ovm = null;
            gevm = null;
            spvm = null;
            mpvm = null;
            mmvm = null;
            players = null;
            players = new List<Gamer>();
            mmvm = new MainMenuViewModel();
            g.Children.Clear();
            //play gomb
            Button play = new Button();
            play.Margin = new Thickness(0,-250,0,0);
            play.Height = 50;
            play.Width = 200;
            play.FontSize = 20;
            play.Content = "Játék";
            play.Click += Play_Click;
            //exit gomb
            Button exit = new Button();
            exit.Height = 50;
            exit.Margin = new Thickness(0,100,0,0);
            exit.Width = 200;
            exit.FontSize = 20;
            exit.Content = "Kilépés";
            exit.Click += Exit_Click;
            //options
            Button options = new Button();
            options.Height = 50;
            options.Margin = new Thickness(0, -10, 0, 0);
            options.Width = 200;
            options.FontSize = 20;
            options.Content = "Beállítások";
            options.Click += Options_Click;
            //gamemode
            Label gml = new Label();
            gml.Height = 30;
            gml.Width = 100;
            gml.Content = "Játékmód";
            gml.Margin = new Thickness(0, -160, 0, 0);
            gml.FontSize = 15;
            //játékmód
            ComboBox cb = new ComboBox();
            cb.Height = 30;
            cb.Width = 200;
            cb.Margin = new Thickness(0, -100, 0, 0);
            cb.BorderBrush = Brushes.Black;
            cb.FontSize = 15;
            cb.SetBinding(ComboBox.SelectedItemProperty, new Binding("SelectedGamemode"));
            cb.SetBinding(ComboBox.ItemsSourceProperty, new Binding("GameModeList"));

            g.Children.Add(cb);
            g.Children.Add(gml);
            g.Children.Add(options);
            g.Children.Add(play);
            g.Children.Add(exit);
            
            DataContext = mmvm;
        }

        private void Options_Click(object sender, RoutedEventArgs e)
        {
            Log.Message("Options létrehozva.");
            g.Children.Clear();
            ovm = new OptionsViewMenu();
            //seed felirat
            Label seed = new Label();
            seed.Content = "Seed: ";
            seed.Height = 40;
            seed.Width = 100;
            seed.Margin = new Thickness(0, 0, 0, 0);
            seed.FontSize = 20;
            //seed box
            TextBox seedbox = new TextBox();
            seedbox.SetBinding(TextBox.TextProperty, new Binding("Seed"));
            seedbox.Height = 40;
            seedbox.Width = 500;
            seedbox.Margin = new Thickness(0, 70, 0, 0);
            seedbox.FontSize = 20;
            seedbox.PreviewKeyDown += Seedbox_PreviewKeyDown; //csak szám mehet bele
            //vissza gomb
            Button back = new Button();
            back.Height = 50;
            back.Margin = new Thickness(0, 200, 0, 0);
            back.Width = 150;
            back.FontSize = 20;
            back.Content = "Vissza";
            back.Click += Back_Click;
            
            g.Children.Add(back);
            g.Children.Add(seedbox);
            g.Children.Add(seed);
            
            DataContext = ovm;
        }

        private void Seedbox_PreviewKeyDown(object sender, KeyEventArgs e)
        {//csak szám mehet seedbe!
            e.Handled = !((e.Key > Key.D0 && e.Key < Key.D9) || e.Key == Key.Delete);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {//kilépés / leállítás
            this.Close();
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            Log.Message("Játék választó létrehozva.");
            g.Children.Clear();
            
            //egyjátékos btn, többjátékos btn, vissza btn, kilépés btn
            Button single = new Button();
            Button multi = new Button();
            single.Content = "Egyjátékos";
            multi.Content = "Többjátékos";
            single.Height = 50;
            multi.Height = 50;
            single.Width = 150;
            multi.Width = 150;
            single.FontSize = 20;
            multi.FontSize = 20;
            single.Margin = new Thickness(200, -100, 0, 0);
            multi.Margin = new Thickness(-200, -100, 0, 0);
            single.Click += Single_Click;
            multi.Click += Multi_Click;
            Button exit = new Button();
            exit.Height = 50;
            exit.Margin = new Thickness(200, 100, 0, 0);
            exit.Width = 150;
            exit.FontSize = 20;
            exit.Content = "Kilépés";
            exit.Click += Exit_Click;
            Button back = new Button();
            back.Height = 50;
            back.Margin = new Thickness(-200, 100, 0, 0);
            back.Width = 150;
            back.FontSize = 20;
            back.Content = "Vissza";
            back.Click += Back_Click;

            g.Children.Add(back);
            g.Children.Add(exit);
            g.Children.Add(single);
            g.Children.Add(multi);
            //nincs vm.
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {//vissza a fő menübe
            CreateMainMenu();
            if (ovm != null)
            { //ha az opciókból jövünk átadja a seedet is
                seed = ovm.Seed;
            }
        }

        private void Multi_Click(object sender, RoutedEventArgs e)
        {
            Log.Message("Multiplayer Létrehozva.");
            mpvm = new MultiPlayerViewModel();
            g.Children.Clear();
            
            //play btn
            Button play = new Button();
            play.Height = 50;
            play.Margin = new Thickness(220, 270, 0, 0);
            play.Width = 100;
            play.FontSize = 20;
            play.Content = "Játék";
            play.Click += Play_Click2;
            //menü btn
            Button menu = new Button();
            menu.Height = 50;
            menu.Margin = new Thickness(-220, 270, 0, 0);
            menu.Width = 100;
            menu.FontSize = 20;
            menu.Content = "Menü";
            menu.Click += Back_Click;
            //következő játékos felvétele btn
            Button next = new Button();
            next.Height = 50;
            next.Margin = new Thickness(0, 270, 0, 0);
            next.Width = 100;
            next.FontSize = 20;
            next.Content = "Következő";
            next.Click += mpvm.AddNext;
            //név felirat
            Label nam = new Label();
            nam.Foreground = Brushes.White;
            nam.Content = "Név: ";
            nam.Height = 40;
            nam.Width = 50;
            nam.Margin = new Thickness(-100, -500, 0, 0);
            nam.FontSize = 20;
            //név box
            TextBox name = new TextBox();
            name.SetBinding(TextBox.TextProperty, "Name");
            name.Height = 30;
            name.Width = 200;
            name.Margin = new Thickness(100, -450, 0, 0);
            name.FontSize = 20;
            //jobb-bal karakter váltó btn
            Button left = new Button();
            Button right = new Button();
            left.Content = "<";
            right.Content = ">";
            left.Margin = new Thickness(-200, -200, 0, 0);
            right.Margin = new Thickness(200, -200, 0, 0);
            left.Height = 200;
            right.Height = 200;
            left.Width = 20;
            right.Width = 20;
            right.Click += mpvm.Right;
            left.Click += mpvm.Left;
            //karakter kép
            Image im = new Image();
            Binding b = new Binding("Selected.Alak");
            b.Converter = (IValueConverter)FindResource("StringToImageConverter");
            im.SetBinding(Image.SourceProperty, b);
            im.Width = 96;
            im.Height = 160;
            im.Margin = new Thickness(0, -200, 0, 0);
            //bal mozgás box
            TextBox leftk = new TextBox();
            leftk.SetBinding(TextBox.TextProperty, new Binding("Leftk"));
            leftk.Height = 30;
            leftk.Width = 100;
            leftk.Margin = new Thickness(500, -200, 0, 0);
            leftk.FontSize = 20;
            leftk.MaxLength = 1;
            //ugrás box
            TextBox jumpk = new TextBox();
            jumpk.SetBinding(TextBox.TextProperty, new Binding("Jumpk"));
            jumpk.Height = 30;
            jumpk.Width = 100;
            jumpk.Margin = new Thickness(500, -100, 0, 0);
            jumpk.FontSize = 20;
            jumpk.MaxLength = 1;
            //jobb box
            TextBox rightk = new TextBox();
            rightk.SetBinding(TextBox.TextProperty, new Binding("Rightk"));
            rightk.Height = 30;
            rightk.Width = 100;
            rightk.Margin = new Thickness(500, 0, 0, 0);
            rightk.FontSize = 20;
            rightk.MaxLength = 1;
            if(mmvm.SelectedGamemode == gamemode_type.Extrém)
            {//csak ha extrém a játékmód tehát szükséges
                //buff használat box
                TextBox buf = new TextBox();
                buf.SetBinding(TextBox.TextProperty, new Binding("Buf"));
                buf.Height = 30;
                buf.Width = 100;
                buf.Margin = new Thickness(500, 100, 0, 0);
                buf.FontSize = 20;
                buf.MaxLength = 1;
                g.Children.Add(buf); 
            }
            /*statok kiírása*/
            //élet felirat
            Label health = new Label();
            health.ContentStringFormat = "Élet: {0}";
            health.SetBinding(Label.ContentProperty, new Binding("Selected.Health"));
            health.Foreground = Brushes.Black;
            health.Height = 30;
            health.Width = 100;
            health.Margin = new Thickness(-100, 90, 0, 0);
            //sebesség felirat
            Label speed = new Label();
            speed.SetBinding(Label.ContentProperty, new Binding("Selected.Speed"));
            speed.Foreground = Brushes.Black;
            speed.ContentStringFormat = "Sebesség: {0}";
            speed.Height = 30;
            speed.Width = 100;
            speed.Margin = new Thickness(-100, 140, 0, 0);
            //ugrás magasság felirat
            Label jump = new Label();
            jump.SetBinding(Label.ContentProperty, new Binding("Selected.JumpHeight"));
            jump.Foreground = Brushes.Black;
            jump.ContentStringFormat = "Ugrás magasság: {0}";
            jump.Height = 30;
            jump.Width = 150;
            jump.Margin = new Thickness(-55, 190, 0, 0);

            g.Children.Add(rightk);
            g.Children.Add(leftk);
            g.Children.Add(jumpk);
            g.Children.Add(next);
            g.Children.Add(menu);
            g.Children.Add(play);
            g.Children.Add(jump);
            g.Children.Add(speed);
            g.Children.Add(health);
            g.Children.Add(im);
            g.Children.Add(left);
            g.Children.Add(right);
            g.Children.Add(name);
            g.Children.Add(nam);
            
            DataContext = mpvm;
        }

        private void Play_Click2(object sender, RoutedEventArgs e)
        {//--több játékos--  a players be rakja a létrehozott játékosokat
            players.AddRange(mpvm.players);

            switch (mmvm.SelectedGamemode)
            {//kiválasztja a játékmódot
                case gamemode_type.Normál:
                    gm = new DefaultGameMode(players);
                break;
                case gamemode_type.Extrém:
                    gm = new ExtremeGameMode(players);
                break;
                case gamemode_type.Időkorlát:
                    gm = new TimerGameMode(players);
                break;
                case gamemode_type.Gyakorlás:
                    gm = new PracticeGameMode(players);
                break;
            }
            mmvm = null;//ez nem tudom minek...
            GameStart();
        }

        private void Single_Click(object sender, RoutedEventArgs e)
        {
            Log.Message("Egyjátékos létrehozva");
            spvm = new SinglePlayerViewModel();
            g.Children.Clear();
            
            //play btn
            Button play = new Button();
            play.Height = 50;
            play.Margin = new Thickness(200, 270, 0, 0);
            play.Width = 150;
            play.FontSize = 20;
            play.Content = "Játék";
            play.Click += Play_Click1;
            //menü btn
            Button menu = new Button();
            menu.Height = 50;
            menu.Margin = new Thickness(-200, 270, 0, 0);
            menu.Width = 150;
            menu.FontSize = 20;
            menu.Content = "Fő menü";
            menu.Click += Back_Click;
            //név txt
            Label nam = new Label();
            nam.Foreground = Brushes.White;
            nam.Content = "Név: ";
            nam.Height = 40;
            nam.Width = 50;
            nam.Margin = new Thickness(-100, -500, 0, 0);
            nam.FontSize = 20;
            //név box
            TextBox name = new TextBox();
            name.SetBinding(TextBox.TextProperty, "Name");
            name.Height = 30;
            name.Width = 200;
            name.Margin = new Thickness(100, -450, 0, 0);
            name.FontSize = 20;
            //jobb-bal karakter váltás
            Button left = new Button();
            Button right = new Button();
            left.Content = "<";
            right.Content = ">";
            left.Margin = new Thickness(-200, -200, 0, 0);
            right.Margin = new Thickness(200, -200, 0, 0);
            left.Height = 200;
            right.Height = 200;
            left.Width = 20;
            right.Width = 20;
            right.Click += spvm.Right;
            left.Click += spvm.Left;
            //karakter képe
            Image im = new Image();
            Binding b = new Binding("Selected.Alak");
            b.Converter = (IValueConverter)FindResource("StringToImageConverter");
            im.SetBinding(Image.SourceProperty, b);
            im.Width = 96;
            im.Height = 160;
            im.Margin = new Thickness(0,-200,0,0);
            /*statok kiírása*/
            //élet txt
            Label health = new Label();
            health.ContentStringFormat = "Élet: {0}";
            health.SetBinding(Label.ContentProperty, new Binding("Selected.Health"));
            health.Foreground = Brushes.White;
            health.Height = 30;
            health.Width = 100;
            health.Margin = new Thickness(-100, 90, 0, 0);
            //sebesség txt
            Label speed = new Label();
            speed.SetBinding(Label.ContentProperty, new Binding("Selected.Speed"));
            speed.Foreground = Brushes.White;
            speed.ContentStringFormat = "Sebesség: {0}";
            speed.Height = 30;
            speed.Width = 100;
            speed.Margin = new Thickness(-100, 140, 0, 0);
            //ugrás magasság txt
            Label jump = new Label();
            jump.SetBinding(Label.ContentProperty, new Binding("Selected.JumpHeight"));
            jump.Foreground = Brushes.White;
            jump.ContentStringFormat = "Ugrás magasság: {0}";
            jump.Height = 30;
            jump.Width = 150;
            jump.Margin = new Thickness(-55, 190, 0, 0);

            g.Children.Add(menu);
            g.Children.Add(play);
            g.Children.Add(jump);
            g.Children.Add(speed);
            g.Children.Add(health);
            g.Children.Add(im);
            g.Children.Add(left);
            g.Children.Add(right);
            g.Children.Add(name);
            g.Children.Add(nam);
            DataContext = spvm;
        }

        private void Play_Click1(object sender, RoutedEventArgs e)
        {//--egy játékos--
            players.Add(new Gamer(spvm.Name, spvm.Selected, Key.Up, Key.Left, Key.Right, Key.Space, 1)); //fix gombokkal :(
            switch (mmvm.SelectedGamemode)
            {//játékmód kiválasztása
                case gamemode_type.Normál:
                gm = new DefaultGameMode(players);
                break;
                case gamemode_type.Extrém:
                gm = new ExtremeGameMode(players);
                break;
                case gamemode_type.Időkorlát:
                gm = new TimerGameMode(players);
                break;
                case gamemode_type.Gyakorlás:
                gm = new PracticeGameMode(players);
                break;
            }
            mmvm = null;
            GameStart();
        }
       
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {//pause az esc-re
            if (e.Key == Key.Escape)
            {
                timer.IsEnabled = !timer.IsEnabled;
            }
        }

        public void GameInit()
        {//játéktér létrehozása
        //már nem tudom mi történik =(
            Log.Message("Játéktér létrehozva.");
            g.Children.Clear();
            //statok kiírása
            Label lb = new Label();
            lb.SetBinding(Label.ContentProperty, new Binding("Stats"));
            lb.Foreground = Brushes.White;
            //játéktér
            ItemsControl ic = new ItemsControl();
            ic.VerticalAlignment = VerticalAlignment.Top;
            ic.HorizontalAlignment = HorizontalAlignment.Left;
            ic.SetBinding(ItemsControl.ItemsSourceProperty, new Binding("actors"));
            ItemsPanelTemplate ipt = new ItemsPanelTemplate();
            var factoryCanvs = new FrameworkElementFactory(typeof(Canvas));
            ipt.VisualTree = factoryCanvs;
            ic.ItemsPanel = ipt;
            Style st = new Style();
            Setter stt_1 = new Setter(Canvas.LeftProperty, new Binding("X"));
            Setter stt_2 = new Setter(Canvas.TopProperty, new Binding("Y"));
            st.Setters.Add(stt_1);
            st.Setters.Add(stt_2);
            ic.ItemContainerStyle = st;
            DataTemplate dt = new DataTemplate();
            var i = new FrameworkElementFactory(typeof(Image));
            Binding b = new Binding("Alak");
            b.Converter = (IValueConverter)FindResource("StringToImageConverter");
            i.SetBinding(Image.WidthProperty, new Binding("Width"));
            i.SetBinding(Image.HeightProperty, new Binding("Height"));
            i.SetBinding(Image.SourceProperty, b);
            dt.VisualTree = i;
            ic.ItemTemplate = dt;
            
            g.Children.Add(lb);
            g.Children.Add(ic);
        }

        private void GameStart()
        {
            Log.Message("Játék elindítva.");
            GameInit();
            gvm = new GameViewModel(gm, seed);
            gvm.GameEnds += GameEnd;//játék végére feliratokzás
            foreach (PlayerController akt in gvm.pc)
            {//játékos irányítása felírása gombokra
                KeyDown += akt.KeyDown;
                KeyUp += akt.KeyUp;
            }
            foreach (Pawn akt in GameViewModel.actors)
            {//játékosok feliratása timer-re
                if (akt is Player)
                {
                    timer.Tick += (akt as Player).Timer;
                }
            }
            timer.Tick += gvm.GameLogic;//game logic felirtaása
            timer.Start(); //timer indítása
            
            DataContext = gvm;
        }

        private void GameEndMenu(string score)
        {//játék vége menü
            Log.Message("Játék vége létrehozva.");
            gvm = null;
            g.Children.Clear();
            gevm = new GameEndViewModel(score); //a pontok átadása
            
            //socres txt
            Label scores = new Label();
            scores.Height = 500;
            scores.Width = 1050;
            scores.HorizontalAlignment = HorizontalAlignment.Left;
            scores.VerticalAlignment = VerticalAlignment.Top;
            scores.SetBinding(Label.ContentProperty, new Binding("Score"));
            scores.Foreground = Brushes.White;
            scores.Margin = new Thickness(0, 0, 0, 0);
            scores.FontSize = 15;
            //kiképés btn
            Button exit = new Button();
            exit.Height = 50;
            exit.Margin = new Thickness(0, 400, 0, 0);
            exit.Width = 100;
            exit.FontSize = 20;
            exit.Content = "Kilépés";
            exit.Click += Exit_Click;

            g.Children.Add(exit);
            g.Children.Add(scores);
            
            DataContext = gevm;
        }

        private void Again_Click(object sender, RoutedEventArgs e)
        {
            GameStart();
        }

        public void GameEnd(object sender, string winner)
        {
            Log.Message("Játék vége!------------------------------------------------");
            timer.Stop();//játék vége
            gvm.GameEnds -= GameEnd;

            GameEndMenu(winner);
        }
    }
}
