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

        // ============= Proivisoire ==============


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;


            _moteurAudio = new MoteurAudio();
            _moteurGraphique = new MoteurGraphique();
            _moteurJeu = new MoteurJeu();
            _moteurReseau = new MoteurReseau();
            _moteurSysteme = new MoteurSysteme();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            _moteurGraphique.Initialize(_moteurSysteme.lireCarte(Environment.CurrentDirectory + @"\carte.txt"), _moteurJeu);
            _moteurJeu.Initialize(_moteurSysteme.EvenementUtilisateur);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            _moteurGraphique.LoadContent(Content);
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
