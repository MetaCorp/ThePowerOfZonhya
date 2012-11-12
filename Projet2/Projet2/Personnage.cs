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
    class Personnage
    {
        String _nom;
        int _vieTotale, _vieActuelle;
        int _pointAction, _pointMouvement;

        float _vitesseX, _vitesseY;

        int _orientation; // dans le sens trigo en partant de 0 jusqu'a 7
        public int Orientation { get { return _orientation; } set { _orientation = value; } }

        bool _isMouving = false;
        public bool IsMouving { get { return _isMouving; } set { _isMouving = value; } }

        Vector2 _position;
        public Vector2 Position { get { return _position; } set { _position = value; } }

        Vector2 _direction;

        Vector2 _nextPosition;

        Texture2D _texture;
        public Texture2D Texture { get { return _texture; } set { _texture = value; } }

        public Personnage(String _nom, int _vieTotale, int _vieActuelle, int _pointAction, int _pointMouvement)
        {
            this._nom = _nom;
            this._pointAction = _pointAction;
            this._pointMouvement = _pointMouvement;
            this._vieActuelle = _vieActuelle;
            this._vieTotale = _vieTotale;

            _position = new Vector2(10, 10);
            _nextPosition = _position;

            _direction = Vector2.Normalize(new Vector2(3, 1));

            _vitesseX = 0.05f;
            _vitesseY = 2 * _vitesseX;

            _orientation = 6;
        }

        public void update(GameTime _gameTime)
        {

        }

        public void BougerPersonnage(MouseState _mouseState, GameTime _gameTime)
        {
            _isMouving = false;

            if (_mouseState.RightButton == ButtonState.Pressed)
            {
                _nextPosition.X = _mouseState.X - 16;
                _nextPosition.Y = _mouseState.Y - 32;
            }

            if (_nextPosition != _position)
            {
                _isMouving = true;

                if (Math.Abs(_nextPosition.X - _position.X) > 2)
                {
                    if (_nextPosition.X > _position.X + 1)
                        _direction.X = 3;
                    else if (_nextPosition.X < _position.X - 1)
                        _direction.X = -3;
                }
                else
                {
                    _position.X = _nextPosition.X;
                    _direction.X = 0;
                }

                if (Math.Abs(_nextPosition.Y - _position.Y) > 1)
                {
                    if (_nextPosition.Y > _position.Y)
                        _direction.Y = 1;
                    else if (_nextPosition.Y < _position.Y)
                        _direction.Y = -1;
                }
                else
                {
                    _position.Y = _nextPosition.Y;
                    _direction.Y = 0;
                }

                Console.WriteLine(_direction);

                _position.X += _direction.X * _vitesseX * (float)_gameTime.ElapsedGameTime.TotalMilliseconds;
                _position.Y += _direction.Y * _vitesseY * (float)_gameTime.ElapsedGameTime.TotalMilliseconds;
            }

            if (_direction.Equals(new Vector2(3, 0)))
                _orientation = 0;
            else if (_direction.Equals(new Vector2(3, -1)))
                _orientation = 1;
            else if (_direction.Equals(new Vector2(0, -1)))
                _orientation = 2;
            else if (_direction.Equals(new Vector2(-3, -1)))
                _orientation = 3;
            else if (_direction.Equals(new Vector2(-3, 0)))
                _orientation = 4;
            else if (_direction.Equals(new Vector2(-3, 1)))
                _orientation = 5;
            else if (_direction.Equals(new Vector2(0, 1)))
                _orientation = 6;
            else if (_direction.Equals(new Vector2(3, 1)))
                _orientation = 7;
        }
    }
}
