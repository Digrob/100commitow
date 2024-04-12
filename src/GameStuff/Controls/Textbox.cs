using _100commitow.src.GameStuff.View;
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
        private Texture2D caretTexture;
        private bool active;
        private List<int> newlineIndicies;
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
            this.newlineIndicies = new List<int>();
            if (Globals.weaponCode != null)
                this.text = Globals.weaponCode;
        }

        public bool IsActive()
        {
            return active;
        }

        private void KeepCaretActive()
        {
            showCaret = true;
            caretTimer = 0;
        }

        private bool IsTextTooLong(string text)
        {
            return Textures.font.MeasureString(text).X > rect.Width;
        }

        private int CountNewlines(string s)
        {
            int length= s.Length;
            int count = 0;
            for (int i = 0; i < length; i++)
            {
                if (s[i] == '\n')
                    count++;
            }
            return count;
        }

        private int LastNewlineIndex(string text)
        {
            int index = text.LastIndexOf('\n');
            return index == -1 ? 0 : index;
        }

        private void ActivateCheck()
        {
            if (MouseManager.LeftPressed())
                active = MouseManager.InsideARect(rect);
        }

        private void RemoveLastBit()
        {
            if(text.Split(' ').Count() == 1)
            {
                text = "";
                return;
            }
            string last_bit = text.Split(' ').Last();
            int index = text.LastIndexOf(' ');
            text = text.Substring(0, index);
        }

        public override void Update()
        {
            ActivateCheck();
            KeyboardManager.Unlock();
            if (!active) return;
            KeyboardManager.Lock();
            KeyboardState state = Keyboard.GetState();
            Keys[] pressedKeys = state.GetPressedKeys();

            foreach (Keys key in pressedKeys)
            {
                if (!lastPressedKeys.Contains(key))
                {
                    KeepCaretActive();
                    if (key == Keys.Enter)
                    {
                        text += "\n";
                    }
                    if (key == Keys.Back && text.Length > 0)
                    {
                        if(Keyboard.GetState().IsKeyDown(Keys.LeftControl))
                        {
                            RemoveLastBit();
                        }
                        else if (text.EndsWith("\n") && newlineIndicies.Contains(text.Length))
                        {
                            newlineIndicies.Remove(text.Length);
                            text = text.Substring(0, text.Length - 2);
                        }
                        else
                            text = text.Substring(0, text.Length - 1);
                    }
                    else if (key == Keys.Space)
                    {
                        if (IsTextTooLong(text + " "))
                        {
                            text += "\n";
                            newlineIndicies.Add(text.Length);
                        }
                        text += " ";
                    }
                    else if(key == Keys.Escape)
                    {
                        active = false;
                        return;
                    }
                    else
                    {
                        if (key.ToString().Length == 1)
                        {
                            if (Keyboard.GetState().IsKeyDown(Keys.LeftControl) && key.ToString() == "S")
                            {
                                Globals.weaponCode = text;
                                active = false;
                                return;
                            }
                            if (IsTextTooLong(text + key.ToString()))
                            {
                                text += "\n";
                                newlineIndicies.Add(text.Length);
                            }
                            if (Keyboard.GetState().IsKeyDown(Keys.LeftShift))
                                text += key.ToString();
                            else
                                text += key.ToString().ToLower();
                        }
                    }
                }
            }
            if (Textures.font.LineSpacing * (CountNewlines(text)+1) > rect.Height)
                rect.Height = Textures.font.LineSpacing * (CountNewlines(text)+1) + 5;
            else if(Textures.font.LineSpacing * (CountNewlines(text) + 1) < rect.Height)
                rect.Height = Textures.font.LineSpacing * (CountNewlines(text) + 1) + 5;
            caretPosition.X = rect.X + Textures.font.MeasureString(text.Substring(LastNewlineIndex(text))).X + Textures.font.MeasureString(" ").X;
            //5 is the spacing between textbox bounds and the text
            caretPosition.Y = rect.Y - Textures.font.LineSpacing + 5 + (Textures.font.LineSpacing * CountNewlines(text));
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
            Globals.spriteBatch.Draw(caretTexture, new Rectangle((int)pos.X, (int)pos.Y, (int)Textures.font.MeasureString(" ").X, Textures.font.LineSpacing), null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 1f);
        }

        public override void Draw()
        {
            Globals.spriteBatch.Draw(texture, new Rectangle(rect.X-1, rect.Y-1, rect.Width+2, rect.Height+2), null, Color.DarkSlateGray, 0f, Vector2.Zero, SpriteEffects.None, 0.98f);
            Globals.spriteBatch.Draw(texture, rect, null, Color.Black, 0f, Vector2.Zero, SpriteEffects.None, 0.99f);
            Globals.spriteBatch.DrawString(Textures.font, text, new Vector2(rect.X, rect.Y) + new Vector2(5, 5), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 1f);

            if (showCaret && active)
            {
                DrawCaret(caretPosition + new Vector2(0, Textures.font.LineSpacing));
                //DrawCaret(new Vector2(rect.X, rect.Y));
            }
        }
    }
}
