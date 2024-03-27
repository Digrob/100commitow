using _100commitow.src.GameStuff.Places;
using _100commitow.src.GameStuff.View;
using _100commitow.src.Inputs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using src;
using src.GameStuff.GameStates;
using src.GameStuff.Places;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace _100commitow.src.GameStuff.GameStates
{
    /// <summary>
    /// A main game state, when the player is in the game
    /// </summary>
    internal class MainGameState : GameState
    {
        private Camera camera;
        private bool stopFromExiting;
        public override void Initialize()
        {
            WorldManager.world = new LobbyWorld();
            stopFromExiting = true;
        }

        public override void LoadContent()
        {
            camera = new Camera(Globals.graphicsDevice.Viewport);
        }

        public override void UnloadContent()
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            Globals.camera = camera;
            camera.UpdateCamera(Globals.graphicsDevice.Viewport);
            KeyboardManager.Update();
            MouseManager.Update();
            WorldManager.world.Update();
            if (KeyboardManager.Down(Keys.Escape) && !stopFromExiting)
            {
                stopFromExiting = true;
                GameStateManager.Instance.AddScreen(Globals.gameStates[1]);
            }
            else if (!KeyboardManager.Down(Keys.Escape) && stopFromExiting)
            {
                stopFromExiting = false;
            }
        }
        public override void Draw()
        {
            Globals.graphicsDevice.Clear(Color.CornflowerBlue);

            Globals.spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend, SamplerState.PointClamp, transformMatrix: camera.Transform);
            WorldManager.world.Draw();
            Globals.spriteBatch.End();

            Globals.spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend, SamplerState.PointClamp, transformMatrix: camera.staticTransform);
            WorldManager.world.StaticDraw();
            Globals.spriteBatch.End();
        }
    }
}
