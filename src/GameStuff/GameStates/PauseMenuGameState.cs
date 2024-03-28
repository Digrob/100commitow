using _100commitow.src.GameStuff.View;
using _100commitow.src.Inputs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using src;
using src.GameStuff.GameStates;
using src.GameStuff.Places;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace _100commitow.src.GameStuff.GameStates
{
    public class PauseMenuGameState : GameState
    {
        private Texture2D texture;
        private List<Control> controls;
        private Vector2 titlePosition;
        private Vector2 menuPosition;
        private string title;
        private int spacing;
        private bool stopFromExiting;
        public override void Initialize()
        {
            stopFromExiting = true;
            title = "The game is paused";
            spacing = 20;
            controls = new List<Control>()
            {
                new Button("RESUME"),
                new Button("OPTIONS"),
                new Button("QUIT")
            };
            titlePosition = new Vector2((Globals.windowBounds.Width - Textures.font.MeasureString(title).X) / 2, 50);
            menuPosition = new Vector2(Globals.windowBounds.Width / 2, Globals.windowBounds.Height / 2);
        }

        public override void LoadContent()
        {
            
        }

        public override void UnloadContent()
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            foreach(Control control in controls)
            {
                control.Update();
            }
        }

        public override void Draw()
        {
            Globals.graphicsDevice.Clear(Color.Black);

            Globals.spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend, SamplerState.PointClamp);
            Globals.spriteBatch.DrawString(Textures.font, title, titlePosition, Color.White);

            int totalHeight = controls.Count * (Textures.font.LineSpacing + spacing);
            int startY = (int)(menuPosition.Y - totalHeight / 2);
            int i = 0;
            foreach (Control item in controls)
            {
                int x = (int)(menuPosition.X - item.rect.Width / 2);
                int y = startY + i * (item.rect.Height + spacing);
                item.rect.X = x;
                item.rect.Y = y;
                item.Draw();
                i++;
            }
            Globals.spriteBatch.End();
        }
    }
}
