using System;
using System.Collections.Generic;
using System.IO;
using OpenTK.Graphics.OpenGL;
using OpenTK;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace GalactikWakFoot.Rendering.Moteur
{
    public static class Loader
    {
        public static Dictionary<string, Texture> LoadGameTexture()
        {
            Dictionary<string, Texture> textures = new Dictionary<string,Texture>();
            textures.Add("Floor", LoadTexture("Ressources/Texture/TILE.png")); //Add Floor texture
            textures.Add("ArrowDown", LoadTexture("Ressources/Texture/TILE_DIRECTION_01.png"));
            textures.Add("ArrowLeft", LoadTexture("Ressources/Texture/TILE_DIRECTION_02.png"));
            textures.Add("ArrowRight", LoadTexture("Ressources/Texture/TILE_DIRECTION_03.png"));
            textures.Add("ArrowUp", LoadTexture("Ressources/Texture/TILE_DIRECTION_04.png"));
            textures.Add("Goal", LoadTexture("Ressources/Texture/TILE_HOLE.png"));

            textures.Add("Slab", LoadTexture("Ressources/Texture/BRICK.png"));
            textures.Add("Ball1", LoadTexture("Ressources/Texture/BALL01.png"));
            textures.Add("Ball2", LoadTexture("Ressources/Texture/BALL02.png"));
            textures.Add("Ball3", LoadTexture("Ressources/Texture/BALL03.png"));
            textures.Add("Ball4", LoadTexture("Ressources/Texture/BALL04.png"));
            textures.Add("Ball5", LoadTexture("Ressources/Texture/BALL05.png"));

            textures.Add("PlayerLeft", LoadTexture("Ressources/Texture/PLAYER01.png"));
            textures.Add("PlayerRight", LoadTexture("Ressources/Texture/PLAYER02.png"));
            textures.Add("PlayerUp", LoadTexture("Ressources/Texture/PLAYER03.png"));
            textures.Add("PlayerDown", LoadTexture("Ressources/Texture/PLAYER04.png"));
            return textures;
        }

        public static Dictionary<string, Texture> LoadMenuTexture()
        {
            Dictionary<string, Texture> textures = new Dictionary<string, Texture>();
            textures.Add("test", LoadTexture("Ressources/Texture/TILE.png")); //Add Floor texture
            return textures;
        }
        public static Texture LoadTexture(string fileName)
        {
            if (!File.Exists(fileName))
                throw new FileNotFoundException(fileName);

            int id = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, id);


            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMinFilter.Linear);

            Bitmap btmap = new Bitmap(fileName);
            BitmapData btmdata = btmap.LockBits(new Rectangle(0, 0, btmap.Width, btmap.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, btmap.Width, btmap.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, btmdata.Scan0);
            btmap.UnlockBits(btmdata);
            return new Texture(id, new Vector2(btmap.Width, btmap.Height));
        }
    }
}
