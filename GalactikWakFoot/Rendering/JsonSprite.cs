using System;
using System.Collections.Generic;
using System.Text;

namespace GalactikWakFoot.GameSystem.Map
{
    public class SpriteMapping
    {
        public string name { get; set; }
        public int textures { get; set; }
        public int animation_speed { get; set; }
    }

    public class JsonSprite
    {
        public IList<SpriteMapping> sprite { get; set; }

    }
}
