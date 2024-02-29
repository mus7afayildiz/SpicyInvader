/// ETML
/// Auteur : Mustafa Yildiz
/// Date : 18.01.2024
/// Description : Le but de ce projet est de reproduire un des grands classiques du jeu vidéo : Space Invaders ! 
/// Space Invaders est un shoot’em up où le principe est de détruire des vagues d’aliens au moyen d’un canon en se déplaçant horizontalement sur l’écran.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SpicyInvader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            Console.SetWindowSize(80, 25);
            Console.SetBufferSize(80, 25);
            Console.CursorVisible = false;

            game.InitializeGame();

            Thread inputThread = new Thread(game.MovePlayer);
            inputThread.Start();           

            TimeSpan interval = new TimeSpan(0, 0, 1);
            ShowEnemy1();

            void ShowEnemy1()
            {
                Console.SetCursorPosition(10, 5);
                Console.WriteLine(" ì__í");
                Console.WriteLine("(¤)(¤)");
                Console.WriteLine(" / /");

                for (int i = 0; i < 100; i++)
                {
                    
                 //   Thread.Sleep(interval);
                 //  Console.Clear();
                    /*
                    Console.WriteLine(" ì__í");
                    Console.WriteLine("[o][o]");
                    Console.WriteLine(" |  |");                  
                    Thread.Sleep(interval);
                    Console.Clear(); */
                }             
            }

            while (!game.isGameOver)
            {           
                game.Update();
                Thread.Sleep(100);
            }

            void ShowEnemy2()
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine("  _  ");
                    Console.WriteLine("(¤ ¤)");
                    Console.WriteLine("  M  ");
                    Thread.Sleep(interval);
                    Console.Clear();

                    Console.WriteLine("  _  ");
                    Console.WriteLine("(O O)");
                    Console.WriteLine(" |||");
                    Thread.Sleep(interval);
                    Console.Clear();
                }
            }

            void ShowEnemy3()
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine(" ◄ ► ");
                    Console.WriteLine("(. .)");
                    Console.WriteLine(" \\\\");
                    Thread.Sleep(interval);
                    Console.Clear();

                    Console.WriteLine(" ◄_►  ");
                    Console.WriteLine("(O O)┘");
                    Console.WriteLine(" ╔ ╗");
                    Thread.Sleep(interval);
                    Console.Clear();
                }
            }      

        }
    }
}
