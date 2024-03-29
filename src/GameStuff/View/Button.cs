using _100commitow.src.Inputs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100commitow.src.GameStuff.View
{
    public class Button : Control
    {
        public EventHandler onClick;
        private Texture2D texture;
        private Vector2 textPosition;
        private string text;
        private Vector2 textSize;
        private Color color;
        public Button(string text)
        {
            texture = new Texture2D(Globals.graphicsDevice, 1, 1);
            texture.SetData(new[] { Color.White });
            this.text = text;
            textSize = Textures.font.MeasureString(text);
            rect = new Rectangle(0, 0, 100, 20);
            color = Color.White;
        }

        public override void Update()
        {
            textPosition = new Vector2(
                rect.X + (rect.Width - textSize.X) / 2,
                rect.Y + (rect.Height - textSize.Y) / 2
            );
            if (MouseManager.InsideARect(rect))
            {
                color = Color.LightGray;
                if (MouseManager.LeftPressed())
                    onClick?.Invoke(null, new EventArgs());
                if(MouseManager.LeftDown())
                    color = Color.Gray;
            }
        }

        public override void Draw()
        {
            Globals.spriteBatch.Draw(texture, rect, null, color, 0, Vector2.Zero, SpriteEffects.None, 0.8f);

            Globals.spriteBatch.DrawString(Textures.font, text, textPosition, Color.Black, 0, Vector2.Zero, 1, SpriteEffects.None, 0.9f);
        }
    }
}
