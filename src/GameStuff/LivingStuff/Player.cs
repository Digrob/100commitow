﻿using _100commitow.src;
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
using System.Diagnostics;
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
        public float xp;
        public float xpCap;
        public int level;
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
            xp = 0;
            xpCap = 50;
            level = 1;
        }

        public void AwardWithExp(int amount)
        {
            xp += amount;
            if(xp >= xpCap)
            {
                xp -= xpCap;
                xpCap += (xpCap * 0.1f);
                level++;
            }
        }

        public override void Update()
        {
            Move();
            base.Update();
            weapon?.Update(this);
            center = new Vector2(position.X+texture.Width/4, position.Y+texture.Height/4);
            position += velocity;
            velocity = Vector2.Zero;
            //for debug purposes
            //if (health != 100)
            //health = 100;
        }
        private void Move()
        {
            if(KeyboardManager.Pressed(Keys.R))
            {
                health = 100;
            }
            if (!cancelMovementX && KeyboardManager.Down(Keys.A))
            {
                velocity.X = -speed;
                spriteEffect = SpriteEffects.FlipHorizontally;
            }
            else if (!cancelMovementX && KeyboardManager.Down(Keys.D))
            {
                velocity.X = speed;
                spriteEffect = SpriteEffects.None;
            }

            if (!cancelMovementY && KeyboardManager.Down(Keys.W))
            {
                velocity.Y = -speed;
            }
            else if (!cancelMovementY && KeyboardManager.Down(Keys.S))
            {
                velocity.Y = speed;
            }
        }
    }
}
