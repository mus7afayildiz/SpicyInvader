using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace SpicyInvader
{
    internal class Enemy
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        private bool moveRight = true;
        public List<Bullet> Bullets { get; private set; }
        public List<Enemy> Enemys { get; private set; }

        public Enemy(int x, int y)
        {
            X = x;
            Y = y;
            Enemys = new List<Enemy>();
        }


        public void Move()
        {
            if (moveRight)
            {
                X++;
                if (X >= Console.WindowWidth - 8) // Eğer sağ sınıra ulaşırsa, aşağıya bir seviye atlayıp sola hareket etmeye başlar
                {
                    Y += 2;
                    moveRight = false;
                }
            }
            else
            {
                X--;
                if (X <= 0) // Eğer sol sınıra ulaşırsa, aşağıya bir seviye atlayıp sağa hareket etmeye başlar
                {
                    Y += 2;
                    moveRight = true;
                }
            }
        }

      
    }
}
