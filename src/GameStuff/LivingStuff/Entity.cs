using _100commitow.src;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using src.GameStuff.Places;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src.GameStuff.LivingStuff
{
    public class Entity : ICloneable
    {
        public World world;
        public Vector2 position;
        public Vector2 origin;
        public SpriteEffects spriteEffect;
        public int rotation;
        public Vector2 scale;
        public int depth;
        public Texture2D texture;
        public Vector2 center;

        public Entity()
        {
            position = Vector2.Zero;
            rotation = 0;
            origin = Vector2.Zero;
            spriteEffect = SpriteEffects.None;
            depth = 1;
            scale = Vector2.One;
            center = position;
        }
        public Entity(Vector2 position)
        {
            this.position = position;
            rotation = 0;
            origin = Vector2.Zero;
            spriteEffect = SpriteEffects.None;
            depth = 1;
            scale = Vector2.One;
            center = position;
        }
        public Entity(string texture, Vector2 position)
        {
            this.position = position;
            this.texture = Textures.Get(texture);
            rotation = 0;
            origin = new Vector2(this.texture.Width / 2, this.texture.Height / 2);
            spriteEffect = SpriteEffects.None;
            depth = 1;
            scale = Vector2.One;
            center = new Vector2(position.X+this.texture.Width / 2, position.Y+this.texture.Height / 2);
        }

        public virtual void Update()
        {

        }

        public virtual void Draw()
        {
            if (texture == null) return;
            Globals.spriteBatch.Draw(texture, position, null, Color.White, rotation, origin, scale, spriteEffect, depth);
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
