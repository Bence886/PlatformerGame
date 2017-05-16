using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando_1
{
    class ScoreReadWrite
    {//fájlba írja az eredményt (nincs használva)
        public void ScoreSave(string name, int score)
        {
            StreamWriter sw = new StreamWriter("Scores.txt");

            sw.WriteLine(string.Format("{0} : {1}", name, score));
            sw.Close();
        }

        public string ScoreRead()
        {
            string a="";
            StreamReader sr = new StreamReader("Scores.txt");

            a += sr.ReadLine() + "\n\n";

            return a;
        }
    }
}
