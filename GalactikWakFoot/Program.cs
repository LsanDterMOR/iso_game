using GalactikWakFoot.WindowManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalactikWakFoot
{
    class Program
    {
        public static void Main(string[] args)
        {
            using (WindowManager game = new WindowManager(1000, 600, "GalactikWakfoot"))
            {
                game.Run(60.0);
            }
        }
    }
}
