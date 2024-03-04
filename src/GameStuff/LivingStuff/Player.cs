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
    internal class Player : Entity
    {
        public Weapon weapon;
        public Player(Vector2 position) : base(position)
        {
            texture = Textures.Get("character");
            weapon = new ProjectileThrower(this);
            isAlive = true;
        }

        public override void Update()
        {
            base.Update();
            weapon?.Update(this);
            center = new Vector2(position.X+texture.Width/4, position.Y+texture.Height/4);
            if (KeyboardManager.Down(Keys.W))
            {
                position.Y -= 3;
            }
            if (KeyboardManager.Down(Keys.S))
            {
                position.Y += 3;
            }
            if (KeyboardManager.Down(Keys.A))
            {
                position.X -= 3;
                spriteEffect = SpriteEffects.FlipHorizontally;
            }
            if (KeyboardManager.Down(Keys.D))
            {
                position.X += 3;
                spriteEffect = SpriteEffects.None;
            }
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
            }
        }
    }
}
