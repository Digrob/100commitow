using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using src;
using src.GameStuff.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100commitow.src.GameStuff.Controls
{
    public class Square : Control
    {
        public Square(Color color)
        {
            this.color = color;
            this.texture = new Texture2D(Globals.graphicsDevice, 1, 1);
            this.texture.SetData(new Color[] { color });
            this.rect = new Rectangle(0,0,50,50);
        }

        public override void Draw()
        {
            Globals.spriteBatch.Draw(texture, rect, Color.White);
        }
    }
}
