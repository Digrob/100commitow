using _100commitow.src.Inputs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using src;
using src.GameStuff.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100commitow.src.GameStuff.Controls
{
    public class Textbox : Control
    {
        public string text;
        public Vector2 pos;
        private Keys[] lastPressedKeys;

        public Textbox(Rectangle rect)
        {
            this.texture = new Texture2D(Globals.graphicsDevice, 1, 1);
            this.texture.SetData(new Color[] { Color.White });
            this.rect = rect;
            this.text = "";
            this.color = Color.Black;
        }

        public override void Update()
        {
            KeyboardState state = Keyboard.GetState();
            Keys[] pressedKeys = state.GetPressedKeys();

            foreach (Keys key in pressedKeys)
            {
                if (!lastPressedKeys.Contains(key))
                {
                    if (key == Keys.Back && text.Length > 0)
                    {
                        text = text.Substring(0, text.Length - 1);
                    }
                    else if (key == Keys.Space)
                    {
                        text += " ";
                    }
                    else
                    {
                        if (key.ToString().Length == 1)
                        {
                            text += key.ToString();
                        }
                    }
                }
            }
            lastPressedKeys = pressedKeys;
        }

        public override void Draw()
        {
            Globals.spriteBatch.Draw(texture, rect, null, Color.Black, 0f, Vector2.Zero, SpriteEffects.None, 0.99f);
            Globals.spriteBatch.DrawString(Textures.font, text, new Vector2(rect.X, rect.Y) + new Vector2(5, 5), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 1f);
        }
    }
}
