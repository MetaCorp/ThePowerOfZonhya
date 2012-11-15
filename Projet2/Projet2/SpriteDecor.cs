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
    class SpriteDecor
    {
        ElementDecor _elementDecor;

        Texture2D _texture;

        int _xIndex, _yIndex;
        int _width, _height;

        public SpriteDecor(ElementDecor _elementDecor)
        {
            this._elementDecor = _elementDecor;
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
            for (int y = 0; y < _elementDecor.NbDecor; y++)
            {
                switch (_elementDecor.DecorTableau[0, y])
                {
                    case 1 :
                        _xIndex = 0; _yIndex = 8; _width = 64; _height = 64;
                        break;

                    case 2:
                        _xIndex = 1; _yIndex = 8; _width = 64; _height = 64;
                        break;

                    case 3:
                        _xIndex = 2; _yIndex = 8; _width = 64; _height = 64;
                        break;

                    case 4:
                        _xIndex = 2; _yIndex = 8; _width = 64; _height = 64;
                        break;

                    case 5:
                        _xIndex = 0; _yIndex = 13; _width = 64; _height = 64*3;
                        break;
                }

                _spriteBatch.Draw(_texture, new Rectangle(32 * (_elementDecor.DecorTableau[1,y] -_elementDecor.DecorTableau[2,y]), 16 * (_elementDecor.DecorTableau[1,y] +_elementDecor.DecorTableau[2,y]), _width, _height), new Rectangle(64 * _xIndex, 64 * _yIndex, _width, _height), Color.White);
              
            }


        }

    }
}
