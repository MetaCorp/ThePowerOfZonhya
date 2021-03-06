﻿using System;
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

    class SpriteAnime : Sprite
    {
        int _currentIndexX, _currentIndexY;
        int _maxIndexX, _maxIndexY;
        int _vitesseAnimation;

        bool _flip;

        public SpriteAnime(Vector2 _position, int _maxIndexX, int _maxIndexY, int _vitesseAnimation)
            : base(_position)
        {
            this.Position = _position;

            Color = Color.White;

            this._maxIndexX = _maxIndexX;
            this._maxIndexY = _maxIndexY;

            this._vitesseAnimation = _vitesseAnimation;

            _currentIndexX = 1;
            _currentIndexY = 0;
        }

        public void Update(Vector2 _position, int _orientation, bool _isMouving, GameTime _gameTime)
        {
            if (_gameTime.TotalGameTime.Milliseconds % _vitesseAnimation == 0)
            {
                if (_isMouving)
                    _currentIndexX = (_currentIndexX + 1) % (_maxIndexX + 1);
                else _currentIndexX = 1;
            }

            this.Position = _position;

            if (_orientation == 0)
                _currentIndexY = 2;//flip
            else if (_orientation == 1)
                _currentIndexY = 4;//flip
            else if (_orientation == 2)
                _currentIndexY = 1;
            else if (_orientation == 3)
                _currentIndexY = 4;
            else if (_orientation == 4)
                _currentIndexY = 2;
            else if (_orientation == 5)
                _currentIndexY = 3;
            else if (_orientation == 6)
                _currentIndexY = 0;
            else if (_orientation == 7)
                _currentIndexY = 3;//flip

            if (_orientation == 0 || _orientation == 1 || _orientation == 7)
                _flip = true;
            else _flip = false;

        }

        //.flipHorizontaly

        public new void Draw(SpriteBatch _spriteBatch)
        {
            if (!_flip)
                _spriteBatch.Draw(Texture, Position, new Rectangle(_currentIndexX * 32, _currentIndexY * 32, 32, 32), Color);
            else _spriteBatch.Draw(Texture, new Rectangle((int)Position.X, (int)Position.Y, 32, 32), new Rectangle(_currentIndexX * 32, _currentIndexY * 32, 32, 32), Color, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 1);
        }

    }
}
