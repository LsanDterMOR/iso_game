using GalactikWakFoot.GameSystem.Map;
using GalactikWakFoot.WindowManagers;
using OpenTK;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace GalactikWakFoot.GameSystem
{
    public class EventManager
    {
        private MapManager mapManager;

        public EventManager(MapManager Map, GameWindow window)
        {
            mapManager = Map;

            window.KeyPress += (sender, e) =>
            {
                switch (e.KeyChar.ToString().ToUpper())
                {
                    case "Z":
                        MovePlayerUp();
                        break;
                    case "S":
                        MovePlayerDown();
                        break;
                    case "Q":
                        MovePlayerLeft();
                        break;
                    case "D":
                        MovePlayerRight();
                        break;
                    case " ":
                        ResetGame();
                        break;
                }
            };
        }

        public void ResetGame()
        {
            mapManager.ReloadMap();
        }

        public void MovePlayerUp()
        {
            Thread t = new Thread(() => mapManager.GetMapTile(
                    mapManager.GetPlayerPosition().row - 1,
                    mapManager.GetPlayerPosition().col,
                    mapManager.GetPlayerPosition().layer)
                .PlayerMove(mapManager, mapManager.player));
            t.Start();
            mapManager.player.direction = Player.Direction.Up;
        }

        public void MovePlayerDown()
        {
            Thread t = new Thread(() => mapManager.GetMapTile(
                    mapManager.GetPlayerPosition().row + 1,
                    mapManager.GetPlayerPosition().col,
                    mapManager.GetPlayerPosition().layer)
                .PlayerMove(mapManager, mapManager.player));
            t.Start();
            mapManager.player.direction = Player.Direction.Down;
        }

        public void MovePlayerRight()
        {
            Thread t = new Thread(() => mapManager.GetMapTile(
                    mapManager.GetPlayerPosition().row,
                    mapManager.GetPlayerPosition().col + 1,
                    mapManager.GetPlayerPosition().layer)
                .PlayerMove(mapManager, mapManager.player));
            t.Start();
            mapManager.player.direction = Player.Direction.Right;
        }

        public void MovePlayerLeft()
        {
            Thread t = new Thread(() => mapManager.GetMapTile(
                    mapManager.GetPlayerPosition().row,
                    mapManager.GetPlayerPosition().col - 1,
                    mapManager.GetPlayerPosition().layer)
                .PlayerMove(mapManager, mapManager.player));
            t.Start();
            mapManager.player.direction = Player.Direction.Left;
        }
    }
}
