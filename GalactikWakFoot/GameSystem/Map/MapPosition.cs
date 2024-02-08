using System;
using System.Collections.Generic;
using System.Text;

namespace GalactikWakFoot.GameSystem.Map
{
    public class MapPosition
    {
        public int row;
        public int col;
        public int layer;
        
        public MapPosition(int row, int col, int layer)
        {
            this.row = row;
            this.col = col;
            this.layer = layer;
        }
        public MapPosition(int[] pos)
        {
            this.row = pos[0];
            this.col = pos[1];
            this.layer = pos[2];
        }

        public override int GetHashCode()
        {
            return (row * 100000 + col * 1000 + layer * 10);
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as MapPosition);
        }

        public bool Equals(MapPosition obj)
        {
            return obj != null && obj.row == this.row && obj.col == this.col && obj.layer == this.layer;
        }
    }
}
