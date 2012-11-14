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
        int _tileTotalWidth;
        public int TileTotalWidth { get { return _tileTotalWidth; } set { _tileTotalWidth = value; } }
            
        int _tileTotalHeight;
        public int TileTotalHeight { get { return _tileTotalHeight; } set { _tileTotalHeight = value; } }

        int _tileWidth;
        public int TileWidth { get { return _tileWidth; } set { _tileWidth = value; } }
        
        int _tileHeight;
        public int TileHeight { get { return _tileHeight; } set { _tileHeight = value; } }

        int _tileStepX;
        public int TileStepX { get { return _tileStepX; } set { _tileStepX = value; } }

        int _tileStepY;
        public int TileStepY { get { return _tileStepY; } set { _tileStepY = value; } }

        Char[,] _tileArray;
        public Char[,] TileArray { get { return _tileArray; } set { _tileArray = value; } }

        int _xTile; // pour le draw
        public int XTile { get { return _xTile; } set { _xTile = value; } }

        int _yTile;
        public int YTile { get { return _yTile; } set { _yTile = value; } }

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

        public void Update(GameTime _gameTime)
        {

        }

        public Vector2 setTileHover(Vector2 _positionSouris)
        {
            return _positionSouris;
        }
    }
}
