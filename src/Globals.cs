using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using _100commitow.src.GameStuff.View;
using System.ComponentModel.Design;
using src.GameStuff.GameStates;

namespace src
{
    internal class Globals
    {
        public static GraphicsDevice graphicsDevice;
        public static SpriteBatch spriteBatch;
        public static ContentManager content;
        public static Rectangle windowBounds;
        public static Camera camera;
        public static List<GameState> gameStates;
        public static string weaponCode;
    }
}
