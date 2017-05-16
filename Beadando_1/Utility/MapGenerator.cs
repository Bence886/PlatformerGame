using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando_1
{
    class MapGenerator
    {
        public MapGenerator(int seed)
        {//seed-es random hogy replikálható legyen minden pálya
            rnd = new Random(seed);
        }

        static Random rnd;
        public int NewY()
        {//az Y koordináta ahova elem lesz elhelyezve
            int a = rnd.Next(20 , 650);
            return a;
        }

        public static int RandomInt(int a, int b)
        {//a-b között ad egy számot (azért kell hogy ne kelljen mindenhol seed-es randomot példányosítani)
            return rnd.Next(a,b);
        }

        public bool RandomPercent(int per)
        { //1% eséllyel igazat ad vissz usefulness lvl 100k
            return rnd.Next(0, 100) < per;
        }
     }
}