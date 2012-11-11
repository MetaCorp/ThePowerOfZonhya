using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Projet2
{
    class MoteurJeu
    {
        EvenementUtilisateur _evenementUtilisateur;

        Personnage _personnage1;
        public Personnage Personnage1 { get { return _personnage1; } set { _personnage1 = value; } }

        public MoteurJeu()
        {
            _personnage1 = new Personnage("Meta", 100, 90, 6, 3);
        }

        public void Initialize(EvenementUtilisateur _evenementUtilisateur)
        {
            Console.WriteLine("personnage initialisé : " + _personnage1.Position);
            this._evenementUtilisateur = _evenementUtilisateur;
        }

        public void Update(GameTime _gameTime)
        {
            _personnage1.BougerPersonnage(_evenementUtilisateur.MouseState);
        }
    }
}
