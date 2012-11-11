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

                    if (_tileArray[x, y] == 'O')
                        _spriteBatch.Draw(_texture, new Rectangle(100 + _tileStepX * (x - y), _tileStepY * (x + y) - 32, _tileWidth, _tileHeight), new Rectangle(0, 0, 64, 64), Color.White);

                }
            }
        }
    }
}
