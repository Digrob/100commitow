using _100commitow.src;
using _100commitow.src.Inputs;
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
    public class Button : Control
    {
        public EventHandler onClick;
        private Vector2 textPosition;
        private string text;
        private Vector2 textSize;
        private bool changeColorOnHover;
        public Button(string text = "", bool changeColorOnHover = true)
        {
            this.texture = new Texture2D(Globals.graphicsDevice, 1, 1);
            this.texture.SetData(new[] { Color.White });
            this.text = text;
            this.textSize = Textures.font.MeasureString(text);
            this.rect = new Rectangle(0, 0, 100, 20);
            this.color = Color.White;
            this.changeColorOnHover = true;
        }

        public Button(Rectangle rect, string text = "", bool changeColorOnHover = true)
        {
            this.texture = new Texture2D(Globals.graphicsDevice, 1, 1);
            this.texture.SetData(new[] { Color.White });
            this.text = text;
            this.textSize = Textures.font.MeasureString(text);
            this.rect = rect;
            this.color = Color.White;
            this.changeColorOnHover = changeColorOnHover;
        }

        public override void Update()
        {
            textPosition = new Vector2(
                rect.X + (rect.Width - textSize.X) / 2,
                rect.Y + (rect.Height - textSize.Y) / 2
            );
            if (changeColorOnHover)
            {
                if (MouseManager.InsideARect(rect))
                {
                    color = Color.LightGray;
                    if (MouseManager.LeftPressed())
                        onClick?.Invoke(null, new EventArgs());
                    if (MouseManager.LeftDown())
                        color = Color.Gray;
                }
                else if (color != Color.White)
                    color = Color.White;
            }
            else
            {
                if (MouseManager.InsideARect(rect))
                    if (MouseManager.LeftPressed())
                        onClick?.Invoke(null, new EventArgs());
            }

        }

        public override void Draw()
        {
            Globals.spriteBatch.Draw(texture, rect, null, color, 0, Vector2.Zero, SpriteEffects.None, 0.9f);

            Globals.spriteBatch.DrawString(Textures.font, text, textPosition, Color.Black, 0, Vector2.Zero, 1, SpriteEffects.None, 0.98f);
        }
    }
}
