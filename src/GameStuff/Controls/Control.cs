using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src.GameStuff.Controls
{
    public class Control
    {
        public Rectangle rect;
        public Texture2D texture;
        public Color color;
        public Control()
        {
            this.rect = new Rectangle(0, 0, 1, 1);
            this.texture = new Texture2D(Globals.graphicsDevice, 1, 1);
            this.texture.SetData(new Color[] { Color.White });
            this.color = Color.White;
        }
        public virtual void Update()
        {

        }
        public virtual void Draw()
        {

        }
    }
}
