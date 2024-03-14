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

            Console.SetWindowSize(100, 40);
            Console.SetBufferSize(100, 40);
            Console.CursorVisible = false;

            game.InitializeGame();

            Thread inputThread = new Thread(game.MovePlayer);
            inputThread.Start();           

            TimeSpan interval = new TimeSpan(0, 0, 100);


            while (!game.isGameOver)
            {           
                game.Update();
                Thread.Sleep(1);
            }



        }
    }
}
