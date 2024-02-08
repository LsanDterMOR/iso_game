using System;
using System.Collections.Generic;
using System.Text;
using GalactikWakFoot.Rendering.Moteur;

namespace GalactikWakFoot.GameSystem.Map.MapObject
{
    class Goal : IMapObject
    {
        public Goal(int row, int col, int layer)
        {
            Position = new MapPosition(row, col, 0);
        }

        public override void PlayerMove(MapManager mapManager, Player player) { }
        public override void ObjectMove(MapManager mapManager, IMapObject tile)
        {
            if (tile.GetType() == typeof(GalactikWakFoot.GameSystem.Map.MapObject.Ball))
            {
                mapManager.SetMapTile("Empty", tile.Position);
                Console.WriteLine("Châpeau, Châpeau");
            }
        }
    }
}
