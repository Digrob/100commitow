using _100commitow.src;
using _100commitow.src.GameStuff;
using _100commitow.src.GameStuff.GameStates;
using _100commitow.src.GameStuff.Places;
using _100commitow.src.GameStuff.View;
using _100commitow.src.Inputs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using src.GameStuff;
using src.GameStuff.DungeonGeneration;
using src.GameStuff.GameStates;
using src.GameStuff.Places;
using System.Collections.Generic;

namespace src
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 640;
            _graphics.PreferredBackBufferHeight = 480;
            _graphics.PreferredDepthStencilFormat = DepthFormat.Depth24Stencil8;
            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            Globals.graphicsDevice = GraphicsDevice;
            Globals.spriteBatch = new SpriteBatch(GraphicsDevice);
            Globals.content = Content;
            int w = _graphics.PreferredBackBufferWidth;
            int h = _graphics.PreferredBackBufferHeight;
            Globals.windowBounds = new Rectangle(0, 0, w, h);
            Globals.gameStates = new List<GameState>()
            {
                new MainGameState(),
                new PauseMenuGameState()
            };
            Textures.Load();
            GameStateManager.Instance.AddScreen(Globals.gameStates[0]);

        }

        protected override void UnloadContent()
        {
            GameStateManager.Instance.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardManager.Update();
            GameStateManager.Instance.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GameStateManager.Instance.Draw();

            base.Draw(gameTime);
        }
    }
}
