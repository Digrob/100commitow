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
        public bool IsTouchingLeft(Entity entity)
        {
            return entity.hitbox.Right + entity.velocity.X > hitbox.Left &&
              entity.hitbox.Left < hitbox.Left &&
              entity.hitbox.Bottom > hitbox.Top &&
              entity.hitbox.Top < hitbox.Bottom;
        }

        public bool IsTouchingRight(Entity entity)
        {
            return entity.hitbox.Left + entity.velocity.X < hitbox.Right &&
              entity.hitbox.Right > hitbox.Right &&
              entity.hitbox.Bottom > hitbox.Top &&
              entity.hitbox.Top < hitbox.Bottom;
        }

        public bool IsTouchingTop(Entity entity)
        {
            return entity.hitbox.Bottom + entity.velocity.Y > hitbox.Top &&
              entity.hitbox.Top < hitbox.Top &&
              entity.hitbox.Right > hitbox.Left &&
              entity.hitbox.Left < hitbox.Right;
        }

        public bool IsTouchingBottom(Entity entity)
        {
            return entity.hitbox.Top + entity.velocity.Y < hitbox.Bottom &&
              entity.hitbox.Bottom > hitbox.Bottom &&
              entity.hitbox.Right > hitbox.Left &&
              entity.hitbox.Left < hitbox.Right;
        }
    }
}
