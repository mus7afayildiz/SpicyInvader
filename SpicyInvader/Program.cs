/// ETML
/// Auteur          : Mustafa Yildiz
/// Date            : 18.01.2024
/// Lieu            : Vennes
/// Description     : Le but de ce projet est de reproduire un des grands classiques du jeu vidéo : Space Invaders ! 
/// Space Invaders est un shoot’em up où le principe est de détruire des vagues d’aliens au moyen d’un canon en se déplaçant horizontalement sur l’écran.

using SpicyInvader.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpicyInvader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.ShowMenu();
        }
    }
}
