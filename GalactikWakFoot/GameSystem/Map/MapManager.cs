using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GalactikWakFoot.GameSystem.Map.MapObject;
using Newtonsoft.Json;

namespace GalactikWakFoot.GameSystem.Map
{
    public class MapManager
    {
        private IDictionary<MapPosition, IMapObject> map;
        public Player player { get; set; }

        private JsonMapping jsonMap;
        private int currentMapId;

        public MapManager(string mapPath)
        {
            map = new Dictionary<MapPosition, IMapObject>();
            jsonMap = JsonConvert.DeserializeObject<JsonMapping>(File.ReadAllText(mapPath));
            LoadMap(0);
        }

        public void SetPlayerPosition(MapPosition pos)
        {
            player.Position = pos;
        }

        public MapPosition GetPlayerPosition()
        {
            return player.Position;
        }

        public void NextMap()
        {
            LoadMap(currentMapId + 1);
        }
        public void ReloadMap()
        {
            LoadMap(currentMapId);
        }

        public void LoadMap(int mapId)
        {
            map.Clear();
            currentMapId = mapId;
            player = new Player(
                jsonMap.maps[mapId].player[0],
                jsonMap.maps[mapId].player[1],
                jsonMap.maps[mapId].player[2]);

            var file = File.ReadLines("Ressources/Maps/" + jsonMap.maps[mapId].file);
            foreach (string line in file)
            {
                var mapObject = line.Split(':');
                var pos = mapObject[0].Split(',');
                map.Add(new MapPosition(int.Parse(pos[0]), int.Parse(pos[1]), int.Parse(pos[2])),
                    GetInstance(mapObject[1], int.Parse(pos[0]), int.Parse(pos[1]), int.Parse(pos[2])));
            }
        }
        public ICollection<IMapObject> GetAllTiles()
        {
            return map.Values;
        }
        public void SwapDictionaryPosition(MapPosition firstPos, MapPosition secondPos)
        {
            var firstMapObject = GetMapTile(firstPos);
            var secondMapObject = GetMapTile(secondPos);

            var TempPosition = firstMapObject.Position;
            firstMapObject.Position = secondMapObject.Position;
            secondMapObject.Position = TempPosition;

            map[firstPos] = secondMapObject;
            map[secondPos] = firstMapObject;
        }

        public IMapObject GetMapTile(int row, int col, int layer)
        {
            if (!map.ContainsKey(new MapPosition(row, col, layer)))
            {
                if (map.ContainsKey(new MapPosition(row, col, layer - 1)))
                    map[new MapPosition(row, col, layer)] = GetInstance("Empty", row, col, layer);
                else
                    map[new MapPosition(row, col, layer)] = GetInstance("Void", row, col, layer);
            }

            return map[new MapPosition(row, col, layer)];
        }
        public IMapObject GetMapTile(MapPosition pos)
        {
            if (!map.ContainsKey(pos))
            {
                if (map.ContainsKey(new MapPosition(pos.row, pos.col, pos.layer - 1)))
                    map[pos] = GetInstance("Empty", pos.row, pos.col, pos.layer);
                else
                    map[pos] = GetInstance("Void", pos.row, pos.col, pos.layer);
            }

            return map[pos];
        }

        public void SetMapTile(string Type, int row, int col, int layer)
        {
            map[new MapPosition(row, col, layer)] = GetInstance(Type, row, col, layer);
        }
        public void SetMapTile(string Type, MapPosition pos)
        {
            map[pos] = GetInstance(Type, pos.row, pos.col, pos.layer);
        }

        private IMapObject GetInstance(string strFullyQualifiedName, int row, int col, int layer)
        {
            object[] args = new object[] { row, col, 1 };
            Type t = Type.GetType("GalactikWakFoot.GameSystem.Map.MapObject." + strFullyQualifiedName);
            return Activator.CreateInstance(t, args) as IMapObject;
        }
    }
}
