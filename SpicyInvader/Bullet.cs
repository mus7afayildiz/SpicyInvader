using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpicyInvader
{
    internal class Bullet
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Bullet(int x, int y)
        {
            X = x;
            Y = y;
        }
        public void MoveUp()
        {
            Y--;
        }
    }
}
