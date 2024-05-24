/// ETML
/// Auteur      : Mustafa Yildiz
/// Date        : 15.02.2024
/// Lieu        : Vennes
/// Description : Grâce à Entity, les lasers du joueur et des personnages extraterrestres ont pu se déplacer.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpicyInvader.Models
{
    internal class Laser : Entity
    {
        /// <summary>
        /// constructeur de la classe
        /// </summary>
        /// <param name="positionX"></param>
        /// <param name="positionY"></param>
        public Laser(int positionX, int positionY)
        {
            //largeur de l'entitée
            Width = 1;

            //hauteur de l'entitée
            Height = 1;

            //style de l'entitée
            Skin = "|";

            //positionX de l'entitée
            PositionX = positionX+1;

            //positionY de l'entitée
            PositionY = positionY;

            //dessine le laser
            Draw();
        }

        /// <summary>
        /// bouge les lasers du joueurs
        /// </summary>
        public void MovePlayer()
        {
            if (PositionY > 1)
            {
                Console.MoveBufferArea(PositionX, PositionY, Width, Height, PositionX, --PositionY);
            }
            else if (PositionY == 1)
            {
                Erase();
            }

        }

        /// <summary>
        /// bouge les lasers des aliens
        /// </summary>
        public void MoveAlien()
        {
            if (PositionY < Console.WindowHeight)
            {
                Console.MoveBufferArea(PositionX, PositionY, Width, Height, PositionX, ++PositionY);
            }
            else
            {
                Erase();
            }
        }
    }
}
