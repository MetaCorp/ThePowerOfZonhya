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
        MoteurSysteme _moteurSysteme;

        MoteurPhysique _moteurPhysique;

        Carte _carte;
        public Carte Carte { get { return _carte; } set { _carte = value; } }

        ElementDecor _elementDecor;
        public ElementDecor ElementDecor { get { return _elementDecor; } set { _elementDecor = value; } }

        Personnage _personnage1;
        public Personnage Personnage1 { get { return _personnage1; } set { _personnage1 = value; } }

        public MoteurJeu()
        {
        }

        public void Initialize(MoteurSysteme _moteurSysteme, MoteurPhysique _moteurPhysique)
        {
            this._moteurSysteme = _moteurSysteme;
            this._moteurPhysique = _moteurPhysique;

            _personnage1 = new Personnage("Meta", 100, 90, 6, 3);
            _carte = new Carte(_moteurSysteme.CarteTableau, 30, 30, 64, 64, 32, 16);
            _elementDecor = new ElementDecor(_moteurSysteme.ElementDecorTableau);
        }

        public void Update(GameTime _gameTime)
        {
            _personnage1.BougerPersonnage(_moteurSysteme.EvenementUtilisateur.MouseState, _gameTime);
        }


    }
}
