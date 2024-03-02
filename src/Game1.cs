using _100commitow.src;
using _100commitow.src.GameStuff;
using _100commitow.src.Inputs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using src.GameStuff;

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
        }

        protected override void Initialize()
        {
            base.Initialize();
            WorldManager.world = new World();
        }

        protected override void LoadContent()
        {
            Globals.graphicsDevice = GraphicsDevice;
            Globals.spriteBatch = new SpriteBatch(GraphicsDevice);
            Globals.content = Content;
            Textures.Load();
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardManager.Update();
            MouseManager.Update();
            WorldManager.world.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            Globals.spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);
            WorldManager.world.Draw();
            Globals.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
