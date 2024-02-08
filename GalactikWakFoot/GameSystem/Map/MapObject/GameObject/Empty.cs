using System;
using System.Collections.Generic;
using System.Text;
using GalactikWakFoot.Rendering.Moteur;

namespace GalactikWakFoot.GameSystem.Map.MapObject
{
    class Empty : IMapObject
    {
        public Empty(int row, int col, int layer = 1)
        {
            Position = new MapPosition(row, col, layer);
        }

        public override void PlayerMove(MapManager mapManager, Player player)
        {
            mapManager.GetMapTile(this.Position.row, this.Position.col, this.Position.layer - 1)
                .PlayerMove(mapManager, player);
        }
        public override void ObjectMove(MapManager mapManager, IMapObject tile)
        {
            mapManager.GetMapTile(this.Position.row, this.Position.col, this.Position.layer - 1)
                      .ObjectMove(mapManager, tile);
        }
    }
}
