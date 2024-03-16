using Microsoft.Xna.Framework;
using MonoGame.Extended.Sprites;
using src.GameStuff.LivingStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100commitow.src.GameStuff.Blocks
{
    public class Wall : Entity
    {
        public Wall()
        {
            texture = Textures.Get("wall");
            scale = new Vector2(4,4);
        }

        public Wall(Vector2 pos)
        {
            texture = Textures.Get("wall");
            position = pos;
            scale = new Vector2(4, 4);
            center = new Vector2(position.X + this.texture.Width / 2, position.Y + this.texture.Height / 2);
            depth = 1;
            hitbox = new Rectangle((int)position.X, (int)position.Y, texture.Width*(int)scale.X, texture.Height*(int)scale.Y);
        }
        
    }
}
