using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using src;

namespace src.GameStuff.GameStates
{
    /// <summary>
    /// A state of the game, for example in game state, or pause menu state
    /// </summary>
    public abstract class GameState
    {
        protected GraphicsDevice _graphicsDevice;
        public GameState()
        {
            _graphicsDevice = Globals.graphicsDevice;
        }
        public abstract void Initialize();
        public abstract void LoadContent();
        public abstract void UnloadContent();
        public abstract void Update(GameTime gameTime);
        public abstract void Draw();
    }
}
