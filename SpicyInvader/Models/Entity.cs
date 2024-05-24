/// ETML
/// Auteur      : Mustafa Yildiz
/// Date        : 15.02.2024
/// Lieu        : Vennes
/// Description : Grâce à Entity, le dessin et la suppression des personnages extraterrestres des joueurs étaient possibles.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpicyInvader.Models
{
    internal class Entity
    {
        //style de l'entitée
        private string _skin;

        //positionX de l'entitée
        private int _positionX;

        //positionY de l'entitée
        private int _positionY;

        //nombre de vie de l'entitée
        private byte _life;

        //largeur de l'entitée
        private int _width;

        //hauteur de l'entitée
        private int _height;

        public string Skin { get => _skin; set => _skin = value; }
        public int PositionX { get => _positionX; set => _positionX = value; }
        public int PositionY { get => _positionY; set => _positionY = value; }
        public byte Life { get => _life; set => _life = value; }
        public int Width { get => _width; set => _width = value; }
        public int Height { get => _height; set => _height = value; }

        /// <summary>
        /// dessine les entitées grâce à la variable _skin
        /// </summary>
        /// <returns> _skin </returns>
        public string Draw()
        {
            int compteur = 0;
            string[] subs = _skin.Split('¦');
            foreach (string s in subs)
            {
                Console.SetCursorPosition(_positionX, _positionY + compteur);
                Console.Write(s);
                compteur++;
            }
            return _skin;
        }

        /// <summary>
        /// efface l'entitée en deplaçant du noir dessus
        /// </summary>
        public void Erase()
        {
            Console.MoveBufferArea(0, Console.WindowHeight, _width, _height, _positionX, _positionY);
        }
    }
}
