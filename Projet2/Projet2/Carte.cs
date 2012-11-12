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
    class Carte
    {
        Texture2D _texture;

        int _tileTotalWidth, _tileTotalHeight;
        int _tileWidth, _tileHeight;
        int _tileStepX, _tileStepY;
        Char[,] _tileArray;

        int _xTile, _yTile;

        public Carte(Char[,] _tileArray, int _tileTotalWidth, int _tileTotalHeight, int _tileWidth, int _tileHeight, int _tileStepX, int _tileStepY)
        {
            this._tileTotalWidth = _tileTotalWidth;
            this._tileTotalHeight = _tileTotalHeight;

            this._tileArray = _tileArray;

            this._tileWidth = _tileWidth;
            this._tileHeight = _tileHeight;
            this._tileStepX = _tileStepX;
            this._tileStepY = _tileStepY;
        }

        public void LoadContent(ContentManager content, String _asset)
        {
            _texture = content.Load<Texture2D>(_asset);
        }

        public void Update(GameTime _gameTime)
        {

        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            for (int y = 0; y < _tileTotalHeight; y++)
            {
                for (int x = 0; x < _tileTotalWidth; x++)
                {

                    switch(_tileArray[x, y]) 
                    {
                        
                        case '.' : 
                            _xTile = 7; _yTile = 0;
                            break;
                        case 'A':
                            _xTile = 0; _yTile = 0;
                            break;
                        case 'B':
                            _xTile = 1; _yTile = 0;
                            break;
                        case 'C':
                            _xTile = 2; _yTile = 0;
                            break;
                        case 'D':
                            _xTile = 3; _yTile = 0;
                            break;
                        case 'E':
                            _xTile = 4; _yTile = 0;
                            break;
                        case 'F':
                            _xTile = 5; _yTile = 0;
                            break;
                        case 'G':
                            _xTile = 6; _yTile = 0;
                            break;
                        case 'H':
                            _xTile = 1; _yTile = 0;
                            break;
                        case 'I':
                            _xTile = 1; _yTile = 1;
                            break;
                        case 'J':
                            _yTile = 1; _xTile = 2;
                            break;
                        case 'K':
                            _yTile = 1; _xTile = 3;
                            break;
                        case 'L':
                            _yTile = 1; _xTile = 4;
                            break;
                        case 'M':
                            _yTile = 1; _xTile = 5;
                            break;
                        case 'N':
                            _yTile = 1; _xTile = 6;
                            break;
                        case 'O':
                            _yTile = 1; _xTile = 7;
                            break;
                        case 'P':
                            _yTile = 2; _xTile = 0;
                            break;
                        case 'Q':
                            _yTile = 2; _xTile = 1;
                            break;
                        case 'R':
                            _yTile = 2; _xTile = 2;
                            break;
                        case 'S':
                            _yTile = 2; _xTile = 3;
                            break;
                        case 'T':
                            _yTile = 3; _xTile = 0;
                            break;
                        case 'U':
                            _yTile = 3; _xTile = 1;
                            break;
                        case 'V':
                            _yTile = 3; _xTile = 2;
                            break;
                        case 'W':
                            _yTile = 3; _xTile = 3;
                            break;
                        case 'X':
                            _yTile = 3; _xTile = 4;
                            break;
                        case 'Y':
                            _yTile = 3; _xTile = 5;
                            break;
                        case 'Z':
                            _yTile = 3; _xTile = 6;
                            break;
                        case '1':
                            _yTile = 3; _xTile = 7;
                            break;
                        case '2':
                            _yTile = 3; _xTile = 8;
                            break;
                        case '3':
                            _yTile = 4; _xTile = 0;
                            break;
                        case '4':
                            _yTile = 4; _xTile = 1;
                            break;
                        case '5':
                            _yTile = 4; _xTile = 2;
                            break;
                        case '6':
                            _yTile = 4; _xTile = 3;
                            break;
                        default :
                            break;
                    }

                    _spriteBatch.Draw(_texture, new Rectangle(350 + _tileStepX * (x - y), _tileStepY * (x + y) - 250, _tileWidth, _tileHeight), new Rectangle(_xTile * 64, _yTile * 64, 64, 64), Color.White);

                }
            }
        }
    }
}
