using Microsoft.Xna.Framework;
using src.GameStuff.LivingStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _100commitow.src.GameStuff.TileMap
{
    public class Tile : Entity
    {
        public bool collidable;
        public Tiles type;

        public Tile(Tiles type, Rectangle hitbox, Rectangle sourceRectangle)
        {
            this.type = type;
            this.hitbox = hitbox;
            this.sourceRectangle = sourceRectangle;
            this.collidable = isCollidable(type);
        }

        public static bool isCollidable(Tiles tile)
        {
            List<Tiles> non_collidables = new List<Tiles>()
            {
                Tiles.Air,
                Tiles.SpawnPoint,
                Tiles.First_Wall_MM
            };
            return !non_collidables.Contains(tile);
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
