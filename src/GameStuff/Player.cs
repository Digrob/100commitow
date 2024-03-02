using _100commitow.src.Inputs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using src;
using src.GameStuff;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100commitow.src.GameStuff
{
    internal class Player : Entity
    {
        public Projectile projectile;
        public SpriteEffects flip;
        public Player(Vector2 position) : base(position)
        {
            this.texture = Textures.Get("character");
            flip = SpriteEffects.None;
            projectile = new Projectile();
        }

        public override void Update()
        {
            if(KeyboardManager.Down(Microsoft.Xna.Framework.Input.Keys.W))
            {
                position.Y -= 3;
            }
            if(KeyboardManager.Down(Microsoft.Xna.Framework.Input.Keys.S))
            {
                position.Y += 3;
            }
            if (KeyboardManager.Down(Microsoft.Xna.Framework.Input.Keys.A))
            {
                position.X -= 3;
                flip = SpriteEffects.FlipHorizontally;
            }
            if (KeyboardManager.Down(Microsoft.Xna.Framework.Input.Keys.D))
            {
                position.X += 3;
                flip = SpriteEffects.None;
            }
            if(Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                Projectile newProjectile = projectile.Clone() as Projectile;
                newProjectile.direction = Vector2.Normalize(MouseManager.GetPosition() - position);
                newProjectile.position = position;
                newProjectile.parent = this;
                WorldManager.world.AddEntity(newProjectile);
            }
        }

        public override void Draw()
        {
            Globals.spriteBatch.Draw(texture, position, null, Color.White, 0, Vector2.Zero, Vector2.One, flip, 1);
        }
    }
}
