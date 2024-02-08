using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalactikWakFoot.Rendering.Moteur
{
    public class Texture
    {
        public int Id { get; set; }
        public Vector2 Size { get; set; }

        public Texture(int id, Vector2 size)
        {
            Id = id;
            Size = size;
        }
    }
}
