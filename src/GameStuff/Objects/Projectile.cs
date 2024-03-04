using _100commitow.src;
using Microsoft.Xna.Framework;
using src.GameStuff.LivingStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src.GameStuff.Objects
{
    public class Projectile : Entity
    {
        public Entity parent;
        public Vector2 direction;
        public float speed;

        public Projectile() : base()
        {
            texture = Textures.Get("projectile");
            direction = Vector2.Zero;
            speed = 1f;
            hitbox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        }

        public Projectile(Vector2 direction) : base()
        {
            texture = Textures.Get("projectile");
            this.direction = direction;
            speed = 1f;
        }

        public Projectile(Vector2 direction, float speed) : base()
        {
            texture = Textures.Get("projectile");
            this.direction = direction;
            this.speed = speed;
        }
        public Projectile(Vector2 direction, float speed, Vector2 offset) : base()
        {
            texture = Textures.Get("projectile");
            this.direction = direction;
            this.speed = speed;
            position += offset;
        }

        public override void Update()
        {
            base.Update();
            position += direction * speed;
            
        }
    }
}
