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
        public List<Control> controls;
        protected Texture2D texture;
        private int spacing = 20;
        public UI()
        {
            visible = false;
            controls = new List<Control>();
        }

        public void AddControl(Control control)
        {
            int width = 200;
            int height = 100;
            int y = rect.Y + controls.Count * (height + spacing);
            int x = rect.X;
            Rectangle bounds = new Rectangle(x, y, width, height);
            control.rect = bounds;
            controls.Add(control);
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
