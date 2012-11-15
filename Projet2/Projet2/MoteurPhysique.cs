using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projet2
{
    class MoteurPhysique
    {

        Char[,] _carteTableau;

        public MoteurPhysique()
        {

        }

        public void Initialise(Char[,] _carteTableau)
        {
            this._carteTableau = _carteTableau;
        }
    }
}
