using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using src;
using src.GameStuff.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100commitow.src.GameStuff.View
{
    /// <summary>
    /// This is an UI, which is in the HUD, instead of a different GameState
    /// </summary>
    public class UI
    {
        public bool visible;
        public Rectangle rect;
        public List<Control> controls;
        public int menuPadding;
        public Color color;
        protected Texture2D texture;
        private int spacing = 20;
        public UI()
        {
            visible = false;
            controls = new List<Control>();
            menuPadding = 100;
            rect = new Rectangle(menuPadding/2, menuPadding/2, Globals.windowBounds.Width - menuPadding, Globals.windowBounds.Height - menuPadding);
            
        }

        public UI(int menuPadding)
        {
            visible = false;
            controls = new List<Control>();
            this.menuPadding = menuPadding;
            rect = new Rectangle(menuPadding/2, menuPadding/2, Globals.windowBounds.Width - menuPadding, Globals.windowBounds.Height - menuPadding);
        }

        public void AddControl(Control control)
        {
            int width = control.rect.Width;
            int height = control.rect.Height;
            int x = rect.X;
            int y = rect.Y;
            foreach(var _ in controls)
            {
                x += width + spacing;
                if(x > rect.Width)
                {
                    x = rect.X;
                    y += rect.Height + spacing;
                }
            }
            Rectangle bounds = new Rectangle(x, y, width, height);
            control.rect = bounds;
            controls.Add(control);
        }
        public virtual void Update()
        {
            foreach(var control in controls)
            {
                control.Update();
            }
        }

        public virtual void Draw()
        {
            Globals.spriteBatch.Draw(texture, rect, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.95f);
            foreach(var control in controls)
            {
                Globals.spriteBatch.Draw(control.texture, control.rect, null, control.color, 0f, Vector2.Zero, SpriteEffects.None, 0.96f);
            }
        }
    }
}
