using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Beadando_1
{
    class PlayerController
    {
        Player player;
        public PlayerController(Player player)
        {
            this.player = player; //megkapja a játékosát
            MainWindow.timer.Tick += Timer; //felírja magát a timerre
        }

        public void Timer(object sender, EventArgs e)
        {
            //Log.Message(String.Format("PlayerY: {0}", player.Y));      //debug
            if (player.Falling)
            { //ha zuhan akkor zuhan 1értelmű
                player.Y = player.Y + 4;
            }
            if (player.Jumping && max <= player.Y)
            { //ha meg kezdte az ugrást és nem érte el a max magasságot akkor ugrik
                player.Y = (int)(player.Y - player.Speed * player.FallSpeed);
                if (player.Y < max)
                {
                    player.Jumping = false;
                    player.Falling = true;
                }
            }
            if (player.MoveR)
            {
                player.X = player.X + player.Speed;
            }
            if (player.MoveL)
            {
                player.X = player.X - player.Speed;
            }

            if (player.X < 0 || player.Y > 650)
            {//a játékos kiesett a pályáról
                player.Damaged(1);
                player.ActiveBuffs1.Clear();//no buff
                player.Skill = null; //noskill
                player.X = 10;
                player.Y = 10;
                player.Invincible = true; //nem sebződhet amíg le nem ér
            }
        }

        float max;//eddig fog ugrani magasságilag

        public void KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == player.Left && player.CanMove)
            {//balra nyargal
                player.MoveL = true;
            }

            if (e.Key == player.Right && player.CanMove)
            {//jobbra lohol
                player.MoveR = true;
            }

            if (e.Key == player.Jumpk && player.Standing)
            { //ha space van nyomva és platformon áll a talpával lefelé a tetején
                player.Jumping = true;
                player.Falling = false;
                max = player.Y - (float)player.JumpHeight;//eddig fog ugrani ha csak baj nem történik
            }
            if (e.Key == player.Buf)
            {//buf használat
                Usebuf();
            }
        }

        private void Usebuf()
        {
            if (player.Skill !=null)
            {
                player.Skill.Use(player);//elhasználás
                player.Skill = null;//noskill
            }
        }

        public void KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == player.Left)
            { //balra szalad
                //player.X = player.X - player.Speed;
                player.MoveL= false;
            }
            if (e.Key == player.Right)
            { //jobbra lohol
                //player.X = player.X + player.Speed;
                player.MoveR = false;
            }
        }
    }
}
