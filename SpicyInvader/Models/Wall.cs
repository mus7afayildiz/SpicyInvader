/// ETML
/// Auteur      : Mustafa Yildiz
/// Date        : 07.03.2024
/// Lieu        : Vennes
/// Description : Grâce à Entity, le dessin des murs et les dommages causés aux murs par les lasers ont été vérifiés.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpicyInvader.Models
{
    internal class Wall : Entity
    {
        /// <summary>
        /// constructeur de la classe
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Wall(int x, int y)
        {
            //positionX de l'entitée
            PositionX = x;

            //positionY de l'entitée
            PositionY = y;

            //nombre de vie du mur
            Life = 3;

            //style de l'entitée
            Skin = @"§§§§§§§§§§§§§§§§§§¦§§§§§§§§§§§§§§§§§§";

            //largeur de l'entitée
            Width = Skin.Split('¦')[0].Length;

            //hauteur de l'entitée
            Height = Skin.Split('¦').Length;

        }

        /// <summary>
        /// enlève un point de vie au mur et l'efface si il n'a plus de vie
        /// </summary>
        /// <param name="list"></param>
        public void TakeDamage(List<Wall> list)
        {
            Life--;
            if (Life == 0)
            {
                list.Remove(this);
                Erase();
            }
        }
    }
}
