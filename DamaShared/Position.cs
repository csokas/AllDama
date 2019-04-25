using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DamaShared
{
    public class Position
    {
        public int x { get; set; }
        public int y { get; set; }

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override bool Equals(object obj)
        {
           return ((Position)obj).x == x && ((Position)obj).y == y;
        }

        public override string ToString()
        {
            return String.Format("{0} {1}", x, y);
        }
    }
}
