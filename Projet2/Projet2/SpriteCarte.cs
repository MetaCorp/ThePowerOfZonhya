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
    class SpriteCarte
    {
        Carte _carte;

        Texture2D _textureTileSet, _textureTileHover;

        public SpriteCarte(Carte _carte)
        {
            this._carte = _carte;
        }

        public void LoadContent(ContentManager content, String _asset1, String _asset2)
        {
            _textureTileSet = content.Load<Texture2D>(_asset1);
            _textureTileHover = content.Load<Texture2D>(_asset2);
        }

        public void Update(GameTime _gameTime)
        {

        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            for (int y = 0; y < _carte.TileTotalHeight; y++)
            {
                for (int x = 0; x < _carte.TileTotalWidth; x++)
                {

                    switch (_carte.TileArray[x, y])
                    {

                        case '.':
                            _carte.XTile = 7; _carte.YTile = 0;
                            break;
                        case 'A':
                            _carte.XTile = 0; _carte.YTile = 0;
                            break;
                        case 'B':
                            _carte.XTile = 1; _carte.YTile = 0;
                            break;
                        case 'C':
                            _carte.XTile = 2; _carte.YTile = 0;
                            break;
                        case 'D':
                            _carte.XTile = 3; _carte.YTile = 0;
                            break;
                        case 'E':
                            _carte.XTile = 4; _carte.YTile = 0;
                            break;
                        case 'F':
                            _carte.XTile = 5; _carte.YTile = 0;
                            break;
                        case 'G':
                            _carte.XTile = 6; _carte.YTile = 0;
                            break;
                        case 'H':
                            _carte.XTile = 0; _carte.YTile = 1;
                            break;
                        case 'I':
                            _carte.XTile = 1; _carte.YTile = 1;
                            break;
                        case 'J':
                            _carte.XTile = 2; _carte.YTile = 1;
                            break;
                        case 'K':
                            _carte.XTile = 3; _carte.YTile = 1;
                            break;
                        case 'L':
                            _carte.XTile = 4; _carte.YTile = 1;
                            break;
                        case 'M':
                            _carte.XTile = 5; _carte.YTile = 1;
                            break;
                        case 'N':
                            _carte.XTile = 6; _carte.YTile = 1;
                            break;
                        case 'O':
                            _carte.XTile = 7; _carte.YTile = 1;
                            break;
                        case 'P':
                            _carte.XTile = 0; _carte.YTile = 2;
                            break;
                        case 'Q':
                            _carte.XTile = 1; _carte.YTile = 2;
                            break;
                        case 'R':
                            _carte.XTile = 2; _carte.YTile = 2;
                            break;
                        case 'S':
                            _carte.XTile = 3; _carte.YTile = 2;
                            break;
                        case 'T':
                            _carte.XTile = 0; _carte.YTile = 3;
                            break;
                        case 'U':
                            _carte.XTile = 1; _carte.YTile = 3;
                            break;
                        case 'V':
                            _carte.XTile = 2; _carte.YTile = 3;
                            break;
                        case 'W':
                            _carte.XTile = 3; _carte.YTile = 3;
                            break;
                        case 'X':
                            _carte.XTile = 4; _carte.YTile = 3;
                            break;
                        case 'Y':
                            _carte.XTile = 5; _carte.YTile = 3;
                            break;
                        case 'Z':
                            _carte.XTile = 6; _carte.YTile = 3;
                            break;
                        case '1':
                            _carte.XTile = 7; _carte.YTile = 3;
                            break;
                        case '2':
                            _carte.XTile = 8; _carte.YTile = 3;
                            break;
                        case '3':
                            _carte.XTile = 0; _carte.YTile = 4;
                            break;
                        case '4':
                            _carte.XTile = 1; _carte.YTile = 4;
                            break;
                        case '5':
                            _carte.XTile = 2; _carte.YTile = 4;
                            break;
                        case '6':
                            _carte.XTile = 3; _carte.YTile = 4;
                            break;
                        default:
                            break;
                    }

                    _spriteBatch.Draw(_textureTileSet, new Rectangle(350 + _carte.TileStepX * (x - y), _carte.TileStepY * (x + y) - 250, _carte.TileWidth, _carte.TileHeight), new Rectangle(_carte.XTile * 64, _carte.YTile * 64, 64, 64), Color.White);

                }
            }

            //_spriteBatch.Draw(

        }

    }
}
