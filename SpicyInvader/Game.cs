/// ETML
/// Auteur : Mustafa Yildiz
/// Date : 18.01.2024
/// Description : C’est elle qui contient les mécanismes fondamentaux du jeu.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpicyInvader
{
    internal class Game
    {
        static int playerPositionX;
        static int playerPositionY;
        static List<Enemy> enemies;
        static List<Bullet> playerBullets;
        public bool isGameOver = false;
        static int score = 0;

        /// <summary>
        /// Le jeu est initialisé
        /// </summary>
        public void InitializeGame()
        {
            playerPositionX = Console.WindowWidth / 2;
            playerPositionY = Console.WindowHeight - 1;
            playerBullets = new List<Bullet>();
        }

        /// <summary>
        /// Designer pour jouer
        /// </summary>
        static void Draw()
        {
            Console.Clear();

            // Designer le jouer
            Console.SetCursorPosition(playerPositionX, playerPositionY);
            Console.Write(".<V>.");

            // Designer de jouer bullets
            foreach (Bullet bullet in playerBullets)
            {
                Console.SetCursorPosition(bullet.X+2, bullet.Y);
                Console.Write("|");
            }



            // Draw enemies     
            for (int i = 0; i < 20; i++)
            {
                Console.SetCursorPosition(i * 4, 1);
                Console.WriteLine("  _  ");
                Console.SetCursorPosition(i * 4, 2);
                Console.WriteLine("(¤ ¤)");
                Console.SetCursorPosition(i * 4, 3);
                Console.WriteLine(" /-\\ ");

                Console.SetCursorPosition(i * 4, 5);
                Console.WriteLine(" ì__í");
                Console.SetCursorPosition(i * 4, 6);
                Console.WriteLine("(¤)(¤)");
                Console.SetCursorPosition(i * 4, 7);
                Console.WriteLine(" /  \\");

                Console.SetCursorPosition(i * 4, 9);
                Console.WriteLine("  _  ");
                Console.SetCursorPosition(i * 4, 10);
                Console.WriteLine("(O O)");
                Console.SetCursorPosition(i * 4, 11);
                Console.WriteLine(" |||");
                i++;
            }

            // Draw 

            // Draw score
            Console.SetCursorPosition(0, 0);
            Console.Write("Score: " + score);
        }

        /// <summary>
        /// ça permet de bouger à droit et à gauche
        /// </summary>
        public void MovePlayer()
        {
            while (!isGameOver)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.LeftArrow && playerPositionX > 0)
                        playerPositionX--;
                    else if (key.Key == ConsoleKey.RightArrow && playerPositionX < Console.WindowWidth - 1)
                        playerPositionX++;
                    else if (key.Key == ConsoleKey.Spacebar)
                        Fire();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        static void Fire()
        {
            playerBullets.Add(new Bullet(playerPositionX, playerPositionY - 1));
        }

        /// <summary>
        /// Cela fonctionne tout au long du jeu.
        /// </summary>
        public void Update()
        {
            MovePlayerBullets();
            Draw();
        }

        /// <summary>
        /// ça permet de bouger le bullet de jouer
        /// </summary>
        static void MovePlayerBullets()
        {
            foreach (Bullet bullet in playerBullets)
            {
                bullet.MoveUp();
            }
            // Remove bullets that are out of bounds
            playerBullets.RemoveAll(bullet => bullet.Y <= 0);
        }

        class Enemy
        {
            public int X { get; private set; }
            public int Y { get; private set; }
            public List<Bullet> Bullets { get; private set; }

            public Enemy(int x, int y)
            {
                X = x;
                Y = y;
                Bullets = new List<Bullet>();
            }


        }

        class Bullet
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
}
