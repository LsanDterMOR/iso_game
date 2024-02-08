using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using GalactikWakFoot.Rendering.Moteur;

namespace GalactikWakFoot.GameSystem.Map.MapObject
{
    class Floor : IMapObject
    {
        public Floor(int row, int col, int layer)
        {
            Position = new MapPosition(row, col, 0);
        }

        public override void PlayerMove(MapManager mapManager, Player player)
        {
            player.SetPostion(Position.row, Position.col, Position.layer + 1);
        }
        public override void ObjectMove(MapManager mapManager, IMapObject tile)
        {
            var previousPos = tile.Position;

            Console.WriteLine("Object moved on " + tile.Position.row + "," + tile.Position.col);

            mapManager.SwapDictionaryPosition(new MapPosition(tile.Position.row, tile.Position.col, tile.Position.layer),
                                              new MapPosition(Position.row, Position.col, Position.layer + 1));

            Thread.Sleep(100);

            if (previousPos.row == this.Position.row - 1)
                mapManager.GetMapTile(tile.Position.row + 1, tile.Position.col, 1)
                    .ObjectMove(mapManager, tile);
            if (previousPos.row == this.Position.row + 1)
                mapManager.GetMapTile(tile.Position.row - 1, tile.Position.col, 1)
                    .ObjectMove(mapManager, tile);
            if (previousPos.col == this.Position.col - 1)
                mapManager.GetMapTile(tile.Position.row, tile.Position.col + 1, 1)
                    .ObjectMove(mapManager, tile);
            if (previousPos.col == this.Position.col + 1)
                mapManager.GetMapTile(tile.Position.row, tile.Position.col - 1, 1)
                    .ObjectMove(mapManager, tile);
            Thread.CurrentThread.Abort();
        }
    }
}
