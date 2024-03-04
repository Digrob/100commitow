using Microsoft.Xna.Framework.Graphics;
using src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace _100commitow.src
{
    public class Textures
    {
        public static Dictionary<string, Texture2D> textures;
        public static SpriteFont font;
        
        public static void Load()
        {
            textures = new Dictionary<string, Texture2D>
            {
                { "character", Globals.content.Load<Texture2D>("character_placeholder") },
                { "projectile", Globals.content.Load<Texture2D>("test_projectile") }
            };
            font = Globals.content.Load<SpriteFont>("File");
        }

        public static Texture2D Get(string key)
        {
            return textures[key];
        }
    }
}
