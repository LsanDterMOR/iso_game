using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace GalactikWakFoot.Rendering.Moteur
{
    public static class Draw
    {
        public static void DrawObject(Texture texture, Color color, Vector2 position, Vector2 scale, float Rotation, Vector2 origin)
        {
            List<Vector2> BaseCoord = new List<Vector2>();
            BaseCoord.Add(new Vector2(0, 0)); //base coord for texture and object
            BaseCoord.Add(new Vector2(1, 0));
            BaseCoord.Add(new Vector2(1, 1));
            BaseCoord.Add(new Vector2(0, 1));


            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

            GL.Enable(EnableCap.Texture2D); //enable texture 2D
            GL.BindTexture(TextureTarget.Texture2D, texture.Id); //use the texture we define

            GL.Begin(PrimitiveType.Quads); //begin info draw
            GL.Color3(color); //set color to texture
            foreach(var vector in BaseCoord)
            {
                Vector2 NewCoord = vector;
                GL.TexCoord2(NewCoord);
                NewCoord.X *= texture.Size.X; //apply parameter to base coordonates
                NewCoord.Y *= texture.Size.Y;
                NewCoord += origin;
                NewCoord *= scale;
                NewCoord += position;
                GL.Vertex2(NewCoord);
            }
            GL.End();

            GL.Disable(EnableCap.Texture2D); //disable the texture to change it if we want

        }
    }
}
