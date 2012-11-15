using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        Char[,] _carteTableau;
        public Char[,] CarteTableau { get { return _carteTableau; } set { _carteTableau = value; } }

        int[,] _elementDecorTableau;
        public int[,] ElementDecorTableau { get { return _elementDecorTableau; } set { _elementDecorTableau = value; } }

        System.IO.StreamReader _fileCarte;
        System.IO.StreamReader _fileDecor;

        public MoteurSysteme()
        {
            _evenementUtilisateur = new EvenementUtilisateur();

            _carteTableau = lireCarte(Environment.CurrentDirectory + @"\carte.txt");
            _elementDecorTableau = lireDecor(Environment.CurrentDirectory + @"\decor.txt");
        }

        public void Update(GameTime _gameTime)
        {
            _evenementUtilisateur.Update(_gameTime);
        }

        public Char[,] lireCarte(String asset)
        {
            int x, y;

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

        public int[,] lireDecor(String asset) // 5(2,4)
        {
            _fileDecor = new System.IO.StreamReader(asset);

            int _nbDecor = Convert.ToInt32(_fileDecor.ReadLine());

            Console.WriteLine(_nbDecor);

            int[,] _decorTableau = new int[3, _nbDecor];

            String _ligne;

            for (int i = 0; i < _nbDecor; i++)
            {
                _ligne = _fileDecor.ReadLine();

                int a = 0, b = 0, c = 0;

                int _currentVariable = 1;

                for (int j = 0; j < _ligne.Length; j++)
                {
                    if (_ligne[j] == '(' || _ligne[j] == ',' || _ligne[j] == ')')
                    {
                        _currentVariable++;
                    }
                    else 
                    {
                        if (_currentVariable == 1)
                                a = a * 10 + Convert.ToInt32(_ligne[j].ToString());

                        if (_currentVariable == 2)
                                b = b * 10 + Convert.ToInt32(_ligne[j].ToString());

                        if (_currentVariable == 3)
                                c = c * 10 + Convert.ToInt32(_ligne[j].ToString());

                        
                    }
                }

                Console.WriteLine("a = " + a + " b = " + b + " c = " + c);

                _decorTableau[0, i] = a;
                _decorTableau[1, i] = b;
                _decorTableau[2, i] = c;
            }

            return _decorTableau;

        }

    }
}
