/// ETML
/// Auteur : Mustafa Yildiz
/// Date : 18.01.2024
/// Description : C’est elle qui contient les mécanismes fondamentaux du jeu.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            playerPositionY = Console.WindowHeight - 3;
            playerBullets = new List<Bullet>();
            enemies = new List<Enemy>();

            // Ajouter des ennemis
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    enemies.Add(new Enemy(j * 5, i * 2));
                }
            }
        }

        /// <summary>
        /// Designer pour jouer
        /// </summary>
        static void Draw()
        {
            // Effacer l'écran en dessinant des espaces
            for (int i = 0; i < Console.WindowHeight; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(new string(' ', Console.WindowWidth));
            }

            DrawShip();
            DrawEnemies();
            DrawBarriers();
            DrawPlayerBullet();
            DrawScore();
            // Draw enemies     
            //for (int i = 0; i < 20; i++)
            //{
            //    Console.SetCursorPosition(i * 4, 1);
            //    Console.WriteLine("  _  ");
            //    Console.SetCursorPosition(i * 4, 2);
            //    Console.WriteLine("(¤ ¤)");
            //    Console.SetCursorPosition(i * 4, 3);
            //    Console.WriteLine(" /-\\ ");

            //    Console.SetCursorPosition(i * 4, 5);
            //    Console.WriteLine(" ì__í");
            //    Console.SetCursorPosition(i * 4, 6);
            //    Console.WriteLine("(¤)(¤)");
            //    Console.SetCursorPosition(i * 4, 7);
            //    Console.WriteLine(" /  \\");

            //    Console.SetCursorPosition(i * 4, 9);
            //    Console.WriteLine("  _  ");
            //    Console.SetCursorPosition(i * 4, 10);
            //    Console.WriteLine("(O O)");
            //    Console.SetCursorPosition(i * 4, 11);
            //    Console.WriteLine(" ||| ");
            //    i++;
            //}

            // Dessiner des ennemis
            //foreach (Enemy enemy in enemies)
            //{
            //    Console.SetCursorPosition(enemy.X+1, enemy.Y);
            //    Console.WriteLine("  _  ");
            //    Console.SetCursorPosition(enemy.X, enemy.Y+1);
            //    Console.WriteLine("(O O)");
            //    Console.SetCursorPosition(enemy.X, enemy.Y+2);
            //    Console.WriteLine(" ||| ");

            //}
        }

        static void DrawShip()
        {
            // Designer le jouer
            Console.SetCursorPosition(playerPositionX, playerPositionY);
            Console.Write(".<V>.");

        }

        static void DrawEnemies()
        {
            // Dessiner des ennemis
            foreach (Enemy enemy in enemies)
            {
                Console.SetCursorPosition(enemy.X + 1, enemy.Y);
                Console.WriteLine("  _  ");
                Console.SetCursorPosition(enemy.X, enemy.Y + 1);
                Console.WriteLine("(O O)");
                Console.SetCursorPosition(enemy.X, enemy.Y + 2);
                Console.WriteLine(" ||| ");
            }

        }

        static void DrawBarriers()
        {
            // Dessiner des barrières
            Console.SetCursorPosition(10, 30);
            Console.Write("§§§§§§§§§§§§§§§§§§");

            Console.SetCursorPosition(40, 30);
            Console.Write("§§§§§§§§§§§§§§§§§§");

            Console.SetCursorPosition(70, 30);
            Console.Write("§§§§§§§§§§§§§§§§§§");

        }

        static void DrawScore()
        {
            // tirage au sort
            Console.SetCursorPosition(1, Console.WindowHeight - 1);
            Console.Write("Score: " + score);

        }

        static void DrawPlayerBullet()
        {
            // Designer de jouer bullets
            foreach (Bullet bullet in playerBullets)
            {
                Console.SetCursorPosition(bullet.X + 2, bullet.Y);
                Console.Write("|");
            }
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
                Thread.Sleep(50);
            }
        }

        /// <summary>
        /// ça permet de tirer et créer un bullet
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
            MoveEnemies();
            CheckCollision();
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

            /// Supprimez les balles hors limites
            playerBullets.RemoveAll(bullet => bullet.Y <= 0);
        }

        static void CheckCollision()
        {
            /// Balle du joueur - collision ennemie
            foreach (Bullet bullet in playerBullets)
            {
                foreach (Enemy enemy in enemies)
                {
                    if (bullet.X == enemy.X && bullet.Y == enemy.Y)
                    {
                        score++;
                        enemies.Remove(enemy);
                        playerBullets.Remove(bullet);
                        return;
                    }
                }
            }          
        }


        private void MoveEnemies()
        {
            foreach (Enemy enemy in enemies)
            {
                enemy.Move();
            }
        }


    }
}
