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
        public Rectangle hitbox;
        public Color color;
        public bool isAlive;
        public Entity()
        {
            position = Vector2.Zero;
            hitbox = new Rectangle((int)position.X, (int)position.Y, 1,1);
            rotation = 0;
            origin = Vector2.Zero;
            spriteEffect = SpriteEffects.None;
            depth = 1;
            scale = Vector2.One;
            center = position;
            color = Color.White;
            isAlive = false;
        }
        public Entity(Vector2 position)
        {
            this.position = position;
            hitbox = new Rectangle((int)position.X, (int)position.Y, 1,1);
            rotation = 0;
            origin = Vector2.Zero;
            spriteEffect = SpriteEffects.None;
            depth = 1;
            scale = Vector2.One;
            center = position;
            color = Color.White;
            isAlive = false;
        }
        public Entity(string texture, Vector2 position)
        {
            this.position = position;
            this.texture = Textures.Get(texture);
            hitbox = new Rectangle((int)position.X, (int)position.Y, this.texture.Width, this.texture.Height);
            rotation = 0;
            origin = new Vector2(this.texture.Width / 2, this.texture.Height / 2);
            spriteEffect = SpriteEffects.None;
            depth = 1;
            scale = Vector2.One;
            center = new Vector2(position.X+this.texture.Width / 2, position.Y+this.texture.Height / 2);
            color = Color.White;
            isAlive = false;
        }

        public virtual void Update()
        {
            hitbox.X = (int)position.X;
            hitbox.Y = (int)position.Y;
        }

        public virtual void Draw()
        {
            if (texture == null) return;
            Globals.spriteBatch.Draw(texture, position, null, color, rotation, origin, scale, spriteEffect, depth);
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
