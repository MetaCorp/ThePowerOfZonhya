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
        MoteurPhysique _moteurPhysique;

        SpriteCarte _spriteCarte;
        public SpriteCarte SpriteCarte { get { return _spriteCarte; } set { _spriteCarte = value; } }

        InterfaceUtilisateur _interfaceUtilisateur;

        SpriteAnime _personnage1;

        public MoteurGraphique()
        {
            _interfaceUtilisateur = new InterfaceUtilisateur();
        }

        public void Initialize(MoteurJeu _moteurJeu)
        {
            _spriteCarte = new SpriteCarte(_moteurJeu.Carte);
            this._moteurJeu = _moteurJeu;

            _personnage1 = new SpriteAnime(_moteurJeu.Personnage1.Position, 2, 4, 100);
        }



        public void LoadContent(ContentManager _content)
        {
            _spriteCarte.LoadContent(_content, "TileSetIso","hilight");
            _personnage1.LoadContent(_content, "brasegali");
        }

        public void Update(GameTime _gameTime)
        {
            _personnage1.Update(_moteurJeu.Personnage1.Position, _moteurJeu.Personnage1.Orientation, _moteurJeu.Personnage1.IsMouving, _gameTime);
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteCarte.Draw(_spriteBatch);
            _personnage1.Draw(_spriteBatch);
        }


    }
}
