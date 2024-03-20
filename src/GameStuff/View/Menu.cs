using _100commitow.src.GameStuff.View;
using _100commitow.src.Inputs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100commitow.src.GameStuff.View
{
    public class Menu : UI
    {
        public Menu() 
        {
            texture = new Texture2D(Globals.graphicsDevice, 1, 1);
            texture.SetData(new[] { Color.White });

            int width = 100;
            int height = 100;
            
            int x = (Globals.graphicsDevice.Viewport.Width / 2) - (width / 3);
            int y = (Globals.graphicsDevice.Viewport.Height / 2) - (width / 3); //centering the menu
            rect = new Rectangle(x, y, width, height);
        }
        public override void Update()
        {
            if(KeyboardManager.Pressed(Keys.Escape))
            {
                Toggle();
            }
        }
        public override void Draw()
        {
            if (!visible) return;
            Globals.spriteBatch.Draw(texture, rect, Color.DarkSlateGray);
        }
    }
}
