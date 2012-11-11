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
    class MoteurSysteme
    {
        EvenementUtilisateur _evenementUtilisateur;
        public EvenementUtilisateur EvenementUtilisateur { get { return _evenementUtilisateur; } set { _evenementUtilisateur = value; } }

        System.IO.StreamReader _fileCarte;

        public MoteurSysteme()
        {
            _evenementUtilisateur = new EvenementUtilisateur();
            lireCarte(Environment.CurrentDirectory + @"\carte.txt");
        }

        public void Update(GameTime _gameTime)
        {
            _evenementUtilisateur.Update(_gameTime);
        }

        public Char[,] lireCarte(String asset)
        {
            int x, y;
            Char[,] _carteTableau;

            _fileCarte = new System.IO.StreamReader(asset);

            x = Convert.ToInt32(_fileCarte.ReadLine());
            y = Convert.ToInt32(_fileCarte.ReadLine());

            _carteTableau = new Char[x, y];

            for (int j = 0; j < y; j++)
            {
                for (int i = 0; i < x; i++)
                {
                    _carteTableau[i, j] = (Char)_fileCarte.Read();

                    if (i == (x - 1) && j != (y - 1)) // passe le char de retour à la ligne
                    {
                        _fileCarte.Read();
                        _fileCarte.Read();
                    }
                }
            }
            return _carteTableau;
        }

    }
}
