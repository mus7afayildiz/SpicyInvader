using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpicyInvader
{
    internal class Enemy
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public List<Bullet> Bullets { get; private set; }
        public List<Enemy> Enemys { get; private set; }

        public Enemy(int x, int y)
        {
            X = x;
            Y = y;
            Enemys = new List<Enemy>();
        }
    }
}
