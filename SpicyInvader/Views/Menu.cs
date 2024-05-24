/// ETML
/// Auteur      : Mustafa Yildiz
/// Date        : 28.03.2024
/// Lieu        : Vennes
/// Description : 
            

using SpicyInvader.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpicyInvader.Views
{
    internal class Menu
    {
        private string subs = "<--";

        //contient la difficulté choisi
        private bool _difficulty = true;

        //contient l'information si on dois jouer la musique
        private bool _playSong = true;

        //permet de savoir si il faut continuer à afficher le menu
        private bool _playing;

        public bool Playing { get => _playing; set => _playing = value; }

        public void ShowMenu()
        {
            Console.CursorVisible = false;

            //crée une variable pour connaître la position du curseur
            int cursorY = 1;

            _playing = true;

            do
            {
                //efface la console
                Console.Clear();

                //titre
                Console.WriteLine("    Spicy Invader ");

                //écrit l'onglet "jouer"
                Console.WriteLine(" Jouer");

                //écrit l'onglet "options"
                Console.WriteLine(" Options");

                //écrit l'onglet "meilleurs scores"
                Console.WriteLine(" Highscores");

                //écrit l'onglet "à propos"
                Console.WriteLine(" A propos");

                //écrit l'onglet "quitter"
                Console.WriteLine(" Quitter");

                Console.SetCursorPosition(20, cursorY);
                Console.Write(subs);

                switch (Console.ReadKey(true).Key)
                {
                    //flèche du bas
                    case ConsoleKey.DownArrow:

                        //si le curseur n'est pas sur le dernier choix
                        if (cursorY < 5)
                        {
                            Console.MoveBufferArea(20, cursorY, 3, 1, 20, cursorY + 1);

                            cursorY += 1;
                        }
                        else
                        {
                            Console.MoveBufferArea(20, cursorY, 3, 1, 20, cursorY);
                        }
                        //quitte l'action
                        break;

                    //flèche du haut
                    case ConsoleKey.UpArrow:

                        //si le curseur n'est pas sur le premier choix
                        if (cursorY > 1)
                        {
                            Console.MoveBufferArea(20, cursorY, 3, 1, 20, cursorY - 1);
                            cursorY -= 1;
                        }
                        else
                        {
                            Console.MoveBufferArea(20, cursorY, 3, 1, 20, cursorY);
                        }

                        //quitte l'action
                        break;

                    //si enter
                    case ConsoleKey.Enter:

                        //que le curseur est sur "jouer"
                        if (cursorY == 1)
                        {
                            Game game = new Game();
                            game.StartGame(_difficulty);
                        }

                        //si sur l'option "options"
                        else if (cursorY == 2)
                        {
                            ShowSettings();
                        }

                        //si sur l'option "meilleurs scores"
                        else if (cursorY == 3)
                        {
                            ShowHighScore();
                        }

                        //si sur l'option "a propos"
                        else if (cursorY == 4)
                        {
                            ShowAbout(); ;
                        }

                        //si sur l'option "quitter"
                        else if (cursorY == 5)
                        {
                            Environment.Exit(0);
                        }

                        //quitte l'action
                        break;

                    //par défault donc si aucun cas n'est valide
                    default:

                        //quitte l'action
                        break;

                }

            } while (_playing);

        }

        /// <summary>
        /// montre les informations sur le projet dans une section à part
        /// </summary>
        public void ShowAbout()
        {
            //efface le menu de la console
            Console.Clear();

            //écrit le titre de la page
            Console.WriteLine(@"A Propos");

            //écrit les informations
            Console.WriteLine("Auteur: Mustafa Yildiz \nSpicy-Invader est un jeu qui me sers de projet programmation orienté objet. Le projet se déroule 2024.");
            Console.Write("Appuyez sur n'importe quelle touche pour quitter");

            //permet de quitter la page
            switch (Console.ReadKey().Key)
            {
                default:
                    break;
            }

        }

        /// <summary>
        /// montre les meilleurs résultat fait sur cette ordinateur
        /// </summary>
        public void ShowHighScore()
        {
            //crée un tableau avec tout le contenu du fichier qui contient les résultat
            string[] lines = System.IO.File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "D:/Leçons/Module4/Vendredi Après Midi Pra Prof PDev 226A-226B/projet/Spicy Invader/SpicyInvader/SpicyInvader/ressources/result.txt");

            int compteur = 0;

            //efface la console
            Console.Clear();

            //écrit l'onglet "meilleurs scores"
            Console.WriteLine(@"Meilleurs scores");

            //écrit tout les éléments du tableau
            foreach (string line in lines)
            {
                if (compteur < 30)
                {
                    Console.WriteLine(line);
                }
                compteur++;
            }

            //lis les touches cliquées
            switch (Console.ReadKey(true).Key)
            {
                default:
                    break;
                case ConsoleKey.Escape:
                    break;
            }
        }


        /// <summary>
        /// affiche les options du jeu
        /// </summary>
        public void ShowSettings()
        {
            //crée une variable pour avoir l'information sur sa position
            int cursorY = 0;

            //crée une variable qui nous peremt de rester dans le menu
            bool showSettings = true;

            do
            {
                //efface la console
                Console.Clear();

                //écrit le titre de l'option
                Console.Write(@" Son ");
                //écrit en vert l'option séléctionnée
                if (_playSong)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(@" ON ");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(@" OFF ");
                    Console.ResetColor();
                }

                //écrit le titre de l'option
                Console.Write(@" DIFFICULTE ");
                //écrit en vert l'option séléctionnée
                if (_difficulty)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(@" DIFFICILE ");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(@" FACILE ");
                    Console.ResetColor();
                }

                //crée un compteur pour compter les cases
                int compteur = 1;

                //écrit la flèche
                Console.SetCursorPosition(30, cursorY);
                Console.Write(subs);

                switch (Console.ReadKey(true).Key)
                {
                    default:
                        break;
                    //flèche du bas
                    case ConsoleKey.DownArrow:

                        //si le curseur n'est pas sur le dernier choix
                        if (cursorY < 1)
                        {
                            Console.MoveBufferArea(20, cursorY, 3, 1, 20, cursorY);

                            //va sur l'autre choix plus bas
                            cursorY += 1;
                        }
                        else
                        {
                            Console.MoveBufferArea(20, cursorY, 3, 1, 20, cursorY);
                        }

                        //quitte l'action
                        break;

                    //flèche du haut
                    case ConsoleKey.UpArrow:

                        //si le curseur n'est pas sur le premier choix
                        if (cursorY > 0)
                        {
                            Console.MoveBufferArea(20, cursorY, 3, 1, 20, cursorY - 1);

                            //va sur le choix au dessus
                            cursorY -= 1;
                        }
                        else
                        {
                            Console.MoveBufferArea(20, cursorY, 3, 1, 20, cursorY);
                        }

                        //quitte l'action
                        break;

                    //sélectionne l'option
                    case ConsoleKey.Enter:
                        if (cursorY == 1 && _difficulty)
                        {
                            _difficulty = false;
                        }
                        else if (cursorY == 1 && !_difficulty)
                        {
                            _difficulty = true;
                        }
                        else if (cursorY == 0 && _playSong)
                        {
                            _playSong = false;
                        }
                        else if (cursorY == 0 && !_playSong)
                        {
                            _playSong = true;
                        }
                        break;
                    case ConsoleKey.Escape:
                        showSettings = false;
                        break;
                }

            } while (showSettings);

        }
    }
}
