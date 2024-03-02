using Microsoft.Xna.Framework;
using src.GameStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100commitow.src.GameStuff
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
            position += direction * speed;
        }
    }
}
