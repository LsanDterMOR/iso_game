using GalactikWakFoot.GameSystem.Map;
using System;
using System.Collections.Generic;
using System.Text;

namespace GalactikWakFoot.GameSystem
{
    public class Player
    {
        public enum Direction
        {
            Up,
            Down,
            Right,
            Left
        }

        public MapPosition Position;
        public Direction direction;
        public bool isMoving;
        public Player(int row, int col, int layer)
        {
            Position = new MapPosition(row, col, layer);
            direction = Direction.Right;
            isMoving = false;
        }

        public Player(MapPosition position)
        {
            Position = position;
            direction = Direction.Right;
            isMoving = false;
        }

        public void SetPostion(int row, int col, int layer)
        {
            Position = new MapPosition(row, col, layer);
            isMoving = true;
        }
    }
}