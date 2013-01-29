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

namespace FinalYearProjectV0._1
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;

        public SpriteBatch spriteBatch;
        public SpriteFont gameFont;

        public static Game1 Instance;
        
        List<Entity> children = new List<Entity>();
        Player player;
        HUD hud;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this) { PreferredBackBufferWidth = 1300, PreferredBackBufferHeight = 650 };
            Content.RootDirectory = "Content";

            Instance = this;
        }

        protected override void Initialize()
        {
            player = new Player();
            hud = new HUD();
            children.Add(player);

            for (int i = 0; i < children.Count; i++)
            {
                children[i].Initialize();
            }

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            gameFont = Content.Load<SpriteFont>("GameFont");

            hud.LoadContent();

            for (int i = 0; i < children.Count; i++)
            {
                children[i].LoadContent();
            }
        }

        protected override void UnloadContent()
        {
            for (int i = 0; i < children.Count; i++)
            {
                children[i].UnloadContent();
            }
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState keyState = Keyboard.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            if(keyState.IsKeyDown(Keys.Escape))
                this.Exit();

            hud.Update(player, gameTime);

            for (int i = 0; i < children.Count; i++)
            {
                children[i].Update(gameTime);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            hud.Draw(gameTime);
            //spriteBatch.DrawString(gameFont, "VelX: " + player._velocity.X, new Vector2(10, 10), Color.White);
            //spriteBatch.DrawString(gameFont, "VelY: " + player._velocity.Y, new Vector2(10, 25), Color.White);
            spriteBatch.End();

            spriteBatch.Begin();
                for (int i = 0; i < children.Count; i++)
                {
                    children[i].Draw(gameTime);
                }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
