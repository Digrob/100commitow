using _100commitow.src;
using _100commitow.src.Inputs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using src;
using src.GameStuff.Objects;
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
        public float speed;
        public Vector2 velocity;
        public Player(Vector2 position) : base(position)
        {
            texture = Textures.Get("character");
            weapon = new ProjectileThrower(this);
            isAlive = true;
            speed = 3;
            velocity = Vector2.Zero;
        }

        public override void Update()
        {
            base.Update();
            weapon?.Update(this);
            center = new Vector2(position.X+texture.Width/4, position.Y+texture.Height/4);
            Move();
            position += velocity;
            velocity = Vector2.Zero;
        }
        private void Move()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                velocity.X = -speed;
                spriteEffect = SpriteEffects.FlipHorizontally;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                velocity.X = speed;
                spriteEffect = SpriteEffects.None;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.W))
                velocity.Y = -speed;
            else if (Keyboard.GetState().IsKeyDown(Keys.S))
                velocity.Y = speed;
        }
    }
}
