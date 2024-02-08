using System;
using System.Collections.Generic;
using System.Text;
using GalactikWakFoot.Rendering.Moteur;

namespace GalactikWakFoot.GameSystem.Map.MapObject
{
    class Void : IMapObject
    {
        public Void(int row, int col, int layer = 1)
        {
            Position = new MapPosition(row, col, layer);
        }

        public override void PlayerMove(MapManager mapManager, Player player)
        {
        }
        public override void ObjectMove(MapManager mapManager, IMapObject tile)
        {
        }
    }
}
