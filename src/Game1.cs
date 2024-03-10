using _100commitow.src;
using _100commitow.src.GameStuff;
using _100commitow.src.GameStuff.View;
using _100commitow.src.Inputs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using src.GameStuff;
using src.GameStuff.Places;

namespace src
{
    public class Game1 : Game
    {
        private Camera camera;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 640;
            _graphics.PreferredBackBufferHeight = 480;
            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            base.Initialize();
            WorldManager.world = new World();
            RNG.Initialize();
        }

        protected override void LoadContent()
        {
            Globals.graphicsDevice = GraphicsDevice;
            Globals.spriteBatch = new SpriteBatch(GraphicsDevice);
            Globals.content = Content;
            Globals.window = Window;
            int w = _graphics.PreferredBackBufferWidth;
            int h = _graphics.PreferredBackBufferHeight;
            Globals.windowBounds = new Rectangle(0, 0, w, h);
            Textures.Load();
            camera = new Camera(GraphicsDevice.Viewport);
        }

        protected override void Update(GameTime gameTime)
        {
            camera.UpdateCamera(Globals.graphicsDevice.Viewport);
            KeyboardManager.Update();
            MouseManager.Update();
            WorldManager.world.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            Globals.spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend, transformMatrix: camera.Transform);
            WorldManager.world.Draw();
            Globals.spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}
