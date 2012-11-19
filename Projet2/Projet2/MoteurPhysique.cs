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
    class MoteurPhysique
    {

        Carte _carte1;
        Carte _carte2;
        ElementDecor _elementDecor;

        int[,] _collisionTableau;

        public MoteurPhysique()
        {

        }

        public void Initialize(Carte _carte1, Carte _carte2, ElementDecor _elementDecor)
        {
            this._carte1 = _carte1;
            this._carte2 = _carte2;
            this._elementDecor = _elementDecor;

            _collisionTableau = SetCollisionTableau(_carte1, _carte2, _elementDecor);
        }

        public List<Vector2> GetPath(Vector2 _positionDepart, Vector2 _positionFinale) // position sur les tiles isos
        {
            Node _currentNode = new Node(null, GetF(_positionDepart, _positionFinale, _positionDepart, 0), _positionDepart);
            List<Node> _openList = new List<Node>();
            List<Node> _closedList = new List<Node>();
            
            Vector2[] _adjacentNodePos = new Vector2[8];

            _openList.Add(_currentNode);

            while (_currentNode.Pos != _positionFinale)
            {
                _adjacentNodePos[0] = new Vector2(_currentNode.Pos.X + 1, _currentNode.Pos.Y);
                _adjacentNodePos[1] = new Vector2(_currentNode.Pos.X - 1, _currentNode.Pos.Y);
                _adjacentNodePos[2] = new Vector2(_currentNode.Pos.X, _currentNode.Pos.Y + 1);
                _adjacentNodePos[3] = new Vector2(_currentNode.Pos.X, _currentNode.Pos.Y - 1);
                _adjacentNodePos[4] = new Vector2(_currentNode.Pos.X + 1, _currentNode.Pos.Y + 1);
                _adjacentNodePos[5] = new Vector2(_currentNode.Pos.X - 1, _currentNode.Pos.Y - 1);
                _adjacentNodePos[6] = new Vector2(_currentNode.Pos.X + 1, _currentNode.Pos.Y - 1);
                _adjacentNodePos[7] = new Vector2(_currentNode.Pos.X - 1, _currentNode.Pos.Y + 1);

                for (int i = 0; i < 8; i++)
                    _openList.Add(new Node(_currentNode, GetF(_positionDepart, _positionFinale,  _adjacentNodePos[i], _collisionTableau[(int)_adjacentNodePos[i].X, (int)_adjacentNodePos[i].X]), _adjacentNodePos[i]));

                _closedList.Add(_openList[0]); // on deplace le noeud parent
                _openList.RemoveAt(0);

                for (int i = 0; i < 7; i++)
                {
                    if (_openList[0].F < _openList[1].F) // garde le f le plus petit
                        _openList.RemoveAt(1);
                    else _openList.RemoveAt(0);
                }

                _currentNode = _openList[0];
            }

        }

        public float GetF(Vector2 _startPos, Vector2 _endPos, Vector2 _currentPos, float _coef) // 0 si rien 1 si mur
        {
            return  (float) (Math.Sqrt( (double)(Math.Pow(_currentPos.X - _startPos.X, 2) + Math.Pow(_currentPos.X - _startPos.X, 2))) 
                           + Math.Sqrt( (double)(Math.Pow(_endPos.X - _currentPos.X, 2) + Math.Pow(_endPos.X - _currentPos.X, 2))) 
                           + _coef * 1000);
        }

        public int[,] SetCollisionTableau(Carte _carte1, Carte _carte2, ElementDecor _elementDecor)
        {
            int[,] _collisionTableau = new int[_carte1.TileTotalWidth,_carte1.TileTotalHeight];

            for (int y = 0; y < _carte1.TileTotalHeight; y++)
            {
                for (int x = 0; y < _carte1.TileTotalWidth; x++)
                {// reste a ajouter les numéros
                    if ((_carte1.TileArray[x, y] > 64 && _carte1.TileArray[x, y] < 91) || (_carte2.TileArray[x, y] > 64 && _carte2.TileArray[x, y] < 91))
                        _collisionTableau[x, y] = 1;

                    _collisionTableau[_elementDecor.DecorTableau[1, y], _elementDecor.DecorTableau[2, y]] = 1;
                }
            }


            return _collisionTableau;
        }
    }

    class Node
    {
        Node _parentNode;
        public Node ParentNode { get { return _parentNode; } set { _parentNode = value; } }

        float _f;
        public float F { get { return _f; } set { _f = value; } }

        Vector2 _pos;
        public Vector2 Pos { get { return _pos; } set { _pos = value; } }

        public Node(Node _parentNode, float _f, Vector2 _pos)
        {
            this._parentNode = _parentNode;
            this._f = _f;
            this._pos = _pos;
        }

    }
}
