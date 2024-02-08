using System;
using System.Collections.Generic;
using System.Text;
using GalactikWakFoot.Rendering.Moteur;

namespace GalactikWakFoot.GameSystem.Map.MapObject
{
    class Arrow : IMapObject
    {
        public Arrow(int row, int col, int layer)
        {
            Position = new MapPosition(row, col, 0);
        }

        public override void PlayerMove(MapManager mapManager, Player player) { }
        public override void ObjectMove(MapManager mapManager, IMapObject tile) { }
    }
}
