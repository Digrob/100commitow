using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using src;
using src.GameStuff.LivingStuff;
using src.GameStuff.Objects;
using src.GameStuff.Places;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100commitow.src.GameStuff.LivingStuff
{
    public class Enemy : Entity
    {
        public Vector2 direction;

        private float cooldown = 0;
        public int xpAward;
        public Enemy(Vector2 position) : base(position)
        {
            texture = Textures.Get("character");
            color = Color.Red;
            direction = Vector2.Zero;
            isAlive = true;
            hitbox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            health = 10;
            maxHealth = health;
            speed = 1;
            damage = 10f;
            xpAward = RNG.RandomNumber(5, 25);
        }

        public override void Update()
        {
            base.Update();
            Player player = (Player)WorldManager.world.GetPlayerEntity();
            if (player == null)
                return;
            direction = Vector2.Normalize(player.position - position);
            position += direction * speed;
            if (CollidesWith(player) && cooldown <= 0.00001)
            {
                damage = RNG.RandomNumber(0, 30);
                player.Damage(damage);
                cooldown = 5;
            }
            else
                cooldown = MathHelper.Lerp(cooldown, 0, 0.5f);
        }
    }
}
