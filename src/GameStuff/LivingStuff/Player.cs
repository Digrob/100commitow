using _100commitow.src;
using _100commitow.src.GameStuff.Blocks;
using _100commitow.src.Inputs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using src;
using src.GameStuff.Objects;
using src.GameStuff.Places;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src.GameStuff.LivingStuff
{
    public class Player : Entity
    {
        public Weapon weapon;
        public bool cancelMovementX;
        public bool cancelMovementY;
        public Player(Vector2 position) : base(position)
        {
            texture = Textures.Get("character");
            weapon = new ProjectileThrower(this);
            isAlive = true;
            velocity = Vector2.Zero;
            cancelMovementX = false;
            cancelMovementY = false;
            hitbox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            health = 100f;
            maxHealth = health;
            speed = 3;
        }

        public override void Update()
        {
            Move();
            base.Update();
            weapon?.Update(this);
            center = new Vector2(position.X+texture.Width/4, position.Y+texture.Height/4);
            position += velocity;
            velocity = Vector2.Zero;
        }
        private void Move()
        {
            if (!cancelMovementX && Keyboard.GetState().IsKeyDown(Keys.A))
            {
                velocity.X = -speed;
                spriteEffect = SpriteEffects.FlipHorizontally;
            }
            else if (!cancelMovementX && Keyboard.GetState().IsKeyDown(Keys.D))
            {
                velocity.X = speed;
                spriteEffect = SpriteEffects.None;
            }

            if (!cancelMovementY && Keyboard.GetState().IsKeyDown(Keys.W))
            {
                velocity.Y = -speed;
            }
            else if (!cancelMovementY && Keyboard.GetState().IsKeyDown(Keys.S))
            {
                velocity.Y = speed;
            }
        }
    }
}
