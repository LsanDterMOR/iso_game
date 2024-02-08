using System;
using System.Collections.Generic;
using System.Text;

namespace GalactikWakFoot.GameSystem.Map
{
    public class MapMapping
    {
        public int id { get; set; }
        public int[] player { get; set; }
        public string name { get; set; }
        public string file { get; set; }
    }

    public class JsonMapping
    {
        public IList<MapMapping> maps { get; set; }
    }
}
