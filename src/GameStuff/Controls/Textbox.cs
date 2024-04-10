using _100commitow.src.Inputs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Timers;
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
        private Vector2 caretPosition;
        private float caretTimer;
        private bool showCaret;
        private List<string> lines;
        private Texture2D caretTexture;
        public Textbox(Rectangle rect)
        {
            this.texture = new Texture2D(Globals.graphicsDevice, 1, 1);
            this.texture.SetData(new Color[] { Color.White });
            this.rect = rect;
            this.text = "";
            this.color = Color.Black;
            this.showCaret = true;
            this.caretTimer = 0f;
            this.caretPosition = new Vector2(0, 0);
            this.caretTexture = new Texture2D(Globals.graphicsDevice, 1, 1);
            this.caretTexture.SetData(new Color[] { Color.White });
            this.lines = new List<string>();
        }

        private void KeepCaretActive()
        {
            showCaret = true;
            caretTimer = 0;
        }

        public override void Update()
        {
            KeyboardState state = Keyboard.GetState();
            Keys[] pressedKeys = state.GetPressedKeys();

            foreach (Keys key in pressedKeys)
            {
                if (!lastPressedKeys.Contains(key))
                {
                    KeepCaretActive();
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

            string[] words = text.Split(' ');
            string currentLine = "";
            lines.Clear();
            foreach (string word in words)
            {
                if (Textures.font.MeasureString(currentLine + word).X <= rect.Width)
                {
                    currentLine += word + " ";
                }
                else
                {
                    lines.Add(currentLine);
                    currentLine = word + " ";
                }
            }
            lines.Add(currentLine);

            caretPosition.X = rect.X + Textures.font.MeasureString(lines.Last()).X;
            //5 is the spacing between textbox bounds and the text
            caretPosition.Y = rect.Y - Textures.font.LineSpacing + 5;
            lastPressedKeys = pressedKeys;

            caretTimer += 2.5f;
            if (caretTimer >= 60)
            {
                caretTimer = 0;
                showCaret = !showCaret;
            }
        }

        private void DrawCaret(Vector2 pos)
        {
            var scale = new Vector2(1, 2);
            Globals.spriteBatch.Draw(caretTexture, new Rectangle((int)pos.X, (int)pos.Y, (int)Textures.font.MeasureString(" ").X, Textures.font.LineSpacing), null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 1f);
        }

        public override void Draw()
        {
            Globals.spriteBatch.Draw(texture, new Rectangle(rect.X-1, rect.Y-1, rect.Width+2, rect.Height+2), null, Color.DarkSlateGray, 0f, Vector2.Zero, SpriteEffects.None, 0.98f);
            Globals.spriteBatch.Draw(texture, rect, null, Color.Black, 0f, Vector2.Zero, SpriteEffects.None, 0.99f);
            Globals.spriteBatch.DrawString(Textures.font, text, new Vector2(rect.X, rect.Y) + new Vector2(5, 5), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 1f);

            if (showCaret)
            {
                DrawCaret(caretPosition + new Vector2(0, Textures.font.LineSpacing));
                //DrawCaret(new Vector2(rect.X, rect.Y));
            }
        }
    }
}
