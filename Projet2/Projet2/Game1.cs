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

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // ============= Initialisation des moteurs =============
        MoteurAudio _moteurAudio;
        MoteurGraphique _moteurGraphique;
        MoteurJeu _moteurJeu;
        MoteurReseau _moteurReseau;
        MoteurSysteme _moteurSysteme;
        MoteurPhysique _moteurPhysique;

        // ============= Proivisoire ==============

        Texture2D _mouseMap;
        Color[] _colorMouseMap;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;

            _moteurPhysique = new MoteurPhysique();
            _moteurAudio = new MoteurAudio();
            _moteurGraphique = new MoteurGraphique();
            _moteurJeu = new MoteurJeu();
            _moteurReseau = new MoteurReseau();
            _moteurSysteme = new MoteurSysteme();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            _colorMouseMap = new Color[64 * 32];
            

            _moteurJeu.Initialize(_moteurSysteme, _moteurPhysique, _colorMouseMap);
            _moteurGraphique.Initialize(_moteurJeu);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            _moteurGraphique.LoadContent(Content);

            _mouseMap = Content.Load<Texture2D>("mousemap");
            _mouseMap.GetData<Color>(_colorMouseMap);
        }

        protected override void UnloadContent() { }

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            _moteurSysteme.Update(gameTime);
            _moteurGraphique.Update(gameTime);
            _moteurJeu.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightGray);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            _moteurGraphique.Draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
