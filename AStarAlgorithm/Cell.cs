using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStarAlgorithm
{
    public class Cell
    {
        private int x;
        private int y;

        public double hValue { get; set; }
        public double fValue
        {
            get
            {
                return this.gValue + this.hValue;
            }
        }
        public double gValue { get; set; }
        public Cell CameFrom { get; set; }
        public Cell NorthNeighbour { get; set; }
        public Cell SouthNeighbour { get; set; }
        public Cell WestNeighbour { get; set; }
        public Cell EastNeighbour { get; set; }

        public Cell LeftLowerNeighbour { get; set; }
        public Cell LeftUpperNeighbour { get; set; }
        public Cell RightLowerNeighbour { get; set; }
        public Cell RightUpperNeighbour { get; set; }

        public int X
        {
            get { return x; }
            set { x = value; }

        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }


        public Cell FindCell(int x, int y, List<Cell> map)
        {
            for (int i = 0; i < map.Count; i++)
            {

                if (map[i].X == x && map[i].Y == y)
                    return map[i];
            }
            return null;
        }

    }
}
