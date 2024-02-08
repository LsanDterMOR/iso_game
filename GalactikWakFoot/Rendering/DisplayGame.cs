using GalactikWakFoot.GameSystem;
using GalactikWakFoot.GameSystem.Map;
using GalactikWakFoot.GameSystem.Map.MapObject;
using GalactikWakFoot.Rendering.Moteur;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Timers;
using Newtonsoft.Json;
using System.IO;

namespace GalactikWakFoot.Rendering
{
    public class DisplayGame
    {
        private Dictionary<string, Texture> textures;

        int width;
        int height;

        int texture_spacing_x;
        int texture_spacing_y;

        Vector2 origin_coord;

        private MapManager mapManager;
        int ball_texture;
        int ball_texture_number;
        bool texture_up;
        float moving;

        private JsonSprite jsonSpriteData;

        public DisplayGame(int Width, int Height, MapManager MapManager)
        {
            this.mapManager = MapManager;
            this.width = Width;
            this.height = Height;
            texture_spacing_x = 50; //spacing between tile horizontaly
            texture_spacing_y = 18; //spacing between tile verticaly
            origin_coord = new Vector2((width / 2) - 50, (height / 4) - 64);
            ball_texture = 2;
            texture_up = true;
            jsonSpriteData = JsonConvert.DeserializeObject<JsonSprite>(File.ReadAllText("Ressources/config/sprite.json"));
            ball_texture_number = jsonSpriteData.sprite[0].textures;
            moving = 0;
            float ball_animation_speed = 400 / jsonSpriteData.sprite[0].animation_speed;

            Timer new_timer = new Timer(ball_animation_speed);
            new_timer.Elapsed += changeTexture;
            new_timer.AutoReset = true;
            new_timer.Enabled = true; ;
        }

        public void changeTexture(object msg, ElapsedEventArgs e)
        {
            if (ball_texture == ball_texture_number || ball_texture == 1)
                texture_up = !texture_up;
            ball_texture = texture_up ? ball_texture + 1 : ball_texture - 1;
        }
        public void Load()
        {
            textures = Loader.LoadGameTexture();
            GL.ClearColor(0.1f, 0.1f, 0.1f, 0);
            setAxes();
        }

        public void Render()
        {
            clearScreen();

            Vector3 map_border = getMapBorder();
            int map_row = (int)map_border.X, map_col = (int)map_border.Y, map_layer = (int)map_border.Z;
            var player = mapManager.player;
            string type;

            for (int layer = 0; layer <= map_layer; layer++)
                for (int col = 0; col <= map_col; col++)
                    for (int row = 0; row <= map_row; row++)
                    {
                        if (player.Position.Equals(new MapPosition(row, col, layer)))
                        {
                            drawPlayer(player, player.direction);
                        }
                        else
                        {
                            IMapObject item = mapManager.GetMapTile(row, col, layer);
                            type = item.GetType().ToString().Split('.').Last();
                            if (type != "Empty" && type != "Void")
                            {
                                drawObject(item, type);
                            }
                        }
                    }
        }

        public void drawPlayer(Player player, Player.Direction direction)
        {
            (float, float) coord = getPlayerMovement(player, direction);
            drawInformation(textures["Player" + direction.ToString()], coord.Item1, coord.Item2);
        }

        public (float, float) getPlayerMovement(Player player, Player.Direction direction)
        {
            float col = player.Position.col;
            float row = player.Position.row;

            //Console.WriteLine(player.isMoving);
            //Console.WriteLine(moving);
            if (player.isMoving)
            {
                switch(direction)
                {
                    case Player.Direction.Right:
                        col = col - 1 + moving;
                        break;
                    case Player.Direction.Left:
                        col = col + 1 - moving;
                        break;
                    case Player.Direction.Up:
                        row = row + 1 - moving;
                        break;
                    case Player.Direction.Down:
                        row = row - 1 + moving;
                        break;
                }
                //Console.WriteLine("col " + col);
                //Console.WriteLine("row " + row);
                if (moving < 1)
                    moving += 0.1f;
                else
                {
                    player.isMoving = false;
                    moving = 0;
                }
            }
            (float, float) coord = movementFormula(texture_spacing_x, texture_spacing_y, col, row);
            coord.Item2 -= 110; //up texture

            return coord;
        }

        public void drawObject(IMapObject item, string type)
        {
            (float, float) coord = getObjectMovement(item);
            if (type == "Ball")
            {
                drawInformation(textures[type + ball_texture.ToString()], coord.Item1, coord.Item2);
            }
            else
            {
                drawInformation(textures[type], coord.Item1, coord.Item2);
            }
        }

        public (float, float) getObjectMovement(IMapObject item)
        {
            float col = item.Position.col;
            float row = item.Position.row;
            (float, float) coord = movementFormula(texture_spacing_x, texture_spacing_y, col, row);

            return (coord.Item1, coord.Item2);
        }

        public (float, float) movementFormula(int spacing_x, int spacing_y, float col, float row)
        {
            float coord_X, coord_Y;

            coord_X = spacing_x * (col - row);
            coord_Y = spacing_y * (col + row);
            return (coord_X, coord_Y);
        }

        public void drawInformation(Texture texture, float coord_X, float coord_Y)
        {
            Draw.DrawObject(texture, Color.White, new Vector2(coord_X, coord_Y), new Vector2(1f, 1f), 0f, origin_coord);
        }

        private Vector3 getMapBorder()
        {
            int row = 0, col = 0, layer = 0;

            foreach (IMapObject item in mapManager.GetAllTiles())
            {
                if (row < item.Position.row)
                    row = item.Position.row;
                if (col < item.Position.col)
                    col = item.Position.col;
                if (layer < item.Position.layer)
                    layer = item.Position.layer;
            }
            return new Vector3(row, col, layer);
        }

        private void clearScreen()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        }

        public void setAxes()
        {
            Matrix4 axes = Matrix4.CreateOrthographicOffCenter(0, width, height, 0, 0, 1);
            GL.LoadMatrix(ref axes);
        }
    }
}
