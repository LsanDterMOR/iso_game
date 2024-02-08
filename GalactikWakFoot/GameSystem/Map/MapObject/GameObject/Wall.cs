using System;
using System.Collections.Generic;
using System.Text;
using GalactikWakFoot.Rendering.Moteur;

namespace GalactikWakFoot.GameSystem.Map.MapObject
{
    class Wall : IMapObject
    {
        public Wall(int row, int col, int layer = 1)
        {
            Position = new MapPosition(row, col, layer);
        }

        public override void PlayerMove(MapManager mapManager, Player player)
        {
            Console.WriteLine("BLOCKED WALL");
            Console.WriteLine(Position.row.ToString() + ", " + Position.col.ToString());
            Console.WriteLine("-----");
        }
        public override void ObjectMove(MapManager mapManager, IMapObject tile)
        {
            Console.WriteLine("BLOCKED WALL");
            Console.WriteLine(Position.row.ToString() + ", " + Position.col.ToString());
            Console.WriteLine("-----");
        }
    }
}
