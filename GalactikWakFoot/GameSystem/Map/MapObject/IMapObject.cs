using System;
using System.Collections.Generic;
using System.Text;
using GalactikWakFoot.Rendering.Moteur;

namespace GalactikWakFoot.GameSystem.Map.MapObject
{
    public abstract class IMapObject
    {
        public MapPosition Position;

        public abstract void PlayerMove(MapManager mapManager, Player player);
        public abstract void ObjectMove(MapManager mapManager, IMapObject tile);
    }
}
