using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando_1
{
    static class Log
    {
        public static void Message(string msg)
        {
            StreamWriter sw = new StreamWriter("log.txt", true);
            sw.WriteLine(string.Format("{0} Message: {1}",DateTime.Now, msg));
            sw.Close();
        }
        public static void Error(string msg)
        {
            StreamWriter sw = new StreamWriter("log.txt", true);
            sw.WriteLine(string.Format("{0} Error: {1}", DateTime.Now, msg));
            sw.Close();
        }
    }
}
