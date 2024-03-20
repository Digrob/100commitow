using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100commitow.src.GameStuff.View
{
    public class UI
    {
        public bool visible;
        public Rectangle rect;

        protected Texture2D texture;
        public UI()
        {
            visible = false;
        }

        public void Toggle()
        {
            visible = !visible;
        }

        public virtual void Update()
        {

        }

        public virtual void Draw()
        {

        }
    }
}
