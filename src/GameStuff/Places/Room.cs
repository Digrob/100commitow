using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100commitow.src.GameStuff.Places
{
    public class Room
    {
        public readonly int Width = 16;
        public readonly int Height = 16;
        public Vector2 position;
        public Rectangle rect;
        public Room(Vector2 position)
        {
            this.position = position;
            rect = new Rectangle((int)position.X, (int)position.Y, Width, Height);
        }


        public void Update()
        {

        }
        public void Draw()
        {
            Texture2D temp_texture = new Texture2D(Globals.graphicsDevice, 1, 1);
            temp_texture.SetData(new Color[] { Color.Green });
            Globals.spriteBatch.Draw(temp_texture, rect, Color.White);
        }
    }
}
