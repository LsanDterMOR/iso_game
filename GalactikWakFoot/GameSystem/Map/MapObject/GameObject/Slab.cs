using System;
using System.Collections.Generic;
using System.Text;
using GalactikWakFoot.Rendering.Moteur;

namespace GalactikWakFoot.GameSystem.Map.MapObject
{
    class Slab : IMapObject
    {
        public Slab(int row, int col, int layer = 1)
        {
            Position = new MapPosition(row, col, layer);
        }
        public override void PlayerMove(MapManager mapManager, Player player)
        {
            Console.WriteLine("=====");
            Console.WriteLine("Start Slab move");
            Console.WriteLine("=====");

            if (this.Position.row - 1 == player.Position.row)
                mapManager.GetMapTile(this.Position.row + 1, this.Position.col, Position.layer)
                    .ObjectMove(mapManager, this);
            if (this.Position.row + 1 == player.Position.row)
                mapManager.GetMapTile(this.Position.row - 1, this.Position.col, Position.layer)
                    .ObjectMove(mapManager, this);
            if (this.Position.col - 1 == player.Position.col)
                mapManager.GetMapTile(this.Position.row, this.Position.col + 1, Position.layer)
                    .ObjectMove(mapManager, this);
            if (this.Position.col + 1 == player.Position.col)
                mapManager.GetMapTile(this.Position.row, this.Position.col - 1, Position.layer)
                    .ObjectMove(mapManager, this);
        }
        public override void ObjectMove(MapManager mapManager, IMapObject tile) { }
    }
}
