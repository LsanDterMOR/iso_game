using GalactikWakFoot.GameSystem.Map;
using GalactikWakFoot.GameSystem.Map.MapObject;
using GalactikWakFoot.WindowManagers;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Text;

namespace GalactikWakFoot.GameSystem
{
    public class GameLoop
    {
        public MapManager mapManager;

        public GameLoop(MapManager map)
        {
            mapManager = map;
        }

        public void WinCondition()
        {
            int i = 0;
            foreach (IMapObject entry in mapManager.GetAllTiles())
            {
                if (entry.GetType() == typeof(GalactikWakFoot.GameSystem.Map.MapObject.Ball))
                    i++;
            }
            if (i == 0)
            {
                Console.WriteLine("BRAVO !!!!!!!!!!!!!!!!!");
                mapManager.NextMap();
            }
        }
    }
}
