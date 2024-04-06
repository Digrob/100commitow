using _100commitow.src.GameStuff.UIs;
using _100commitow.src.Inputs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using src;
using src.GameStuff.Controls;
using src.GameStuff.LivingStuff;
using src.GameStuff.Places;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100commitow.src.GameStuff.View
{
    /// <summary>
    /// A static layer which displays statuses like player's hp or level
    /// </summary>
    public class HUD
    {
        public static UI queuedUI;

        private static UI? UI;
        private static bool initialized = false;
        private static Rectangle red_rect;
        private static Rectangle green_rect;
        private static Texture2D red_rect_texture;
        private static Texture2D green_rect_texture;
        private static Player player;
        private static void Initialize()
        {
            player = WorldManager.world.character as Player;
            red_rect = new Rectangle(0, 30, 125, 25);
            green_rect = new Rectangle(0, 30, 125, 25);
            red_rect_texture = new Texture2D(Globals.graphicsDevice, 1, 1);
            red_rect_texture.SetData(new Color[] { Color.Red });
            green_rect_texture = new Texture2D(Globals.graphicsDevice, 1, 1);
            green_rect_texture.SetData(new Color[] { Color.Green });
            initialized = true;
            UI = null;
        }
        private static void UpdateHealthBar()
        {
            player.health = MathHelper.Clamp(player.health, 0, player.maxHealth);
            float greenWidth = 125 * (player.health / player.maxHealth);
            green_rect.Width = (int)greenWidth;
        }

        public static bool HoveringOverUI()
        {
            if (UI == null)
                return false;
            return MouseManager.InsideARect(UI.rect);
        }

        public static bool IsUINull()
        {
            return UI == null;
        }
        public static void Update()
        {
            if (!initialized)
                Initialize();
            if(queuedUI != null)
            {
                if (queuedUI.GetType() == typeof(UINone))
                {
                    UI = null;
                    queuedUI = null;
                }
                else
                {
                    UI = queuedUI;
                    queuedUI = null;
                }
            }
            if (UI != null)
                UI.Update();
            UpdateHealthBar();
        }
        public static void Draw()
        {
            Globals.spriteBatch.DrawString(Textures.font, $"Health: {player.health}", new Vector2(0, 0), Color.White);
            Globals.spriteBatch.Draw(red_rect_texture, red_rect, null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0.8f);
            Globals.spriteBatch.Draw(green_rect_texture, green_rect, null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0.81f);
            Globals.spriteBatch.DrawString(Textures.font, $"Level: {player.level}", new Vector2(0, 65), Color.White);
            Globals.spriteBatch.DrawString(Textures.font, $"XP: {player.xp}/{player.xpCap}", new Vector2(0, 80), Color.White);
            if (UI != null)
                UI.Draw();
        }
    }
}
