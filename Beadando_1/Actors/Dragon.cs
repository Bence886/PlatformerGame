using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando_1
{
    abstract class Dragon :Enemy
    {
        public Dragon(float x, float y, int height, int width, float speed, float jump, bool vis, int maxHealth, string alak)
            : base(x, y, height, width, speed, jump, vis, maxHealth, alak)
        {
            this.Visible = vis;
            nev = new List<string>();
        }

        public static void DragonInit(int height, int length)
        {
            DragonHead head = new DragonHead(1050, height, 50, 50, 0, 0, true);
            DragonBody body = new DragonBody(1200, 1200, 50, 50, 0, 0, true, head, null);
            GameViewModel.actors.Add(body);

            for (int i = 0; i < length; i++)
            {
                Add(ref body);
            }

            GameViewModel.actors.Add(head); 
        }

        private static void Add(ref DragonBody body)
        {
            DragonBody newBody = new DragonBody(1200, 1200, 50, 50, 0,0, true, body, null);
            GameViewModel.actors.Add(newBody);
            body.Next = newBody;
            body = newBody;
        }

        List<string> nev;

        public override void Utkozes(Pawn param1)
        {
            if (param1 is Character && !nev.Exists(a=>a == param1.Alak))
            {
                base.Utkozes(param1);
                nev.Add((param1 as Character).Alak);
            }
        }
    }
}
