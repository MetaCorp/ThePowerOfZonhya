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
    class MoteurGraphique
    {
        MoteurJeu _moteurJeu;

        Carte _carte;
        public Carte Carte { get { return _carte; } set { _carte = value; } }

        InterfaceUtilisateur _interfaceUtilisateur;

        SpriteAnime _personnage1;

        public MoteurGraphique()
        {
            _interfaceUtilisateur = new InterfaceUtilisateur();
        }

        public void Initialize(Char[,] _carteTableau, MoteurJeu _moteurJeu)
        {
            _carte = new Carte(_carteTableau, 30, 30, 64, 64, 32, 16);
            this._moteurJeu = _moteurJeu;

            _personnage1 = new SpriteAnime(_moteurJeu.Personnage1.Position, 2, 4, 100);
        }



        public void LoadContent(ContentManager _content)
        {
            _carte.LoadContent(_content, "TileSetIso");
            _personnage1.LoadContent(_content, "brasegali");
        }

        public void Update(GameTime _gameTime)
        {
            _personnage1.Update(_moteurJeu.Personnage1.Position, _moteurJeu.Personnage1.Orientation, _moteurJeu.Personnage1.IsMouving, _gameTime);
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _carte.Draw(_spriteBatch);
            _personnage1.Draw(_spriteBatch);
        }


    }
}
