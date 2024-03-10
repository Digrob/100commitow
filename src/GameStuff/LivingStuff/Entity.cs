using _100commitow.src;
using _100commitow.src.GameStuff;
using _100commitow.src.GameStuff.Blocks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using src.GameStuff.Objects;
using src.GameStuff.Places;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src.GameStuff.LivingStuff
{
    /// <summary>
    /// Any object in the game, either alive or not
    /// </summary>
    public class Entity : ICloneable
    {
        public World world;
        public Vector2 position;
        public Vector2 origin;
        public Vector2 velocity;
        public SpriteEffects spriteEffect;
        public int rotation;
        public Vector2 scale;
        public float depth;
        public Texture2D texture;
        public Vector2 center;
        public Rectangle hitbox;
        public Color color;
        public bool isAlive;
        public float health;
        public float maxHealth;
        public bool queuedForDeath;
        public StatusEffects statusEffect;
        public bool immobilized;
        public float speed;
        
        private Rectangle red_rect;
        private Rectangle green_rect;
        private Texture2D red_rect_texture;
        private Texture2D green_rect_texture;
        private float statusEffectTimer;
        private Color healthBarColor;

        public Entity()
        {
            position = Vector2.Zero;
            hitbox = new Rectangle((int)position.X, (int)position.Y, 1,1);
            rotation = 0;
            origin = Vector2.Zero;
            spriteEffect = SpriteEffects.None;
            depth = 0.1f;
            scale = Vector2.One;
            center = position;
            color = Color.White;
            isAlive = false;
            health = 0;
            maxHealth = 0;
            queuedForDeath = false;
            red_rect_texture = new Texture2D(Globals.graphicsDevice, 1, 1);
            red_rect_texture.SetData(new Color[] { Color.Red });
            green_rect_texture = new Texture2D(Globals.graphicsDevice, 1, 1);
            green_rect_texture.SetData(new Color[] { Color.Green });
            red_rect = new Rectangle((int)position.X, (int)position.Y, 50, 10);
            green_rect = new Rectangle((int)position.X, (int)position.Y, 50, 10);
            statusEffect = StatusEffects.None;
            statusEffectTimer = 0f;
            healthBarColor = Color.Green;
            immobilized = false;
            speed = 1;
        }
        public Entity(Vector2 position)
        {
            this.position = position;
            hitbox = new Rectangle((int)position.X, (int)position.Y, 1,1);
            rotation = 0;
            origin = Vector2.Zero;
            spriteEffect = SpriteEffects.None;
            depth = 0.1f;
            scale = Vector2.One;
            center = position;
            color = Color.White;
            isAlive = false;
            health = 0;
            maxHealth = 0;
            queuedForDeath = false;
            red_rect_texture = new Texture2D(Globals.graphicsDevice, 1, 1);
            red_rect_texture.SetData(new Color[] { Color.Red });
            green_rect_texture = new Texture2D(Globals.graphicsDevice, 1, 1);
            green_rect_texture.SetData(new Color[] { Color.Green });
            red_rect = new Rectangle((int)position.X, (int)position.Y, 50, 10);
            green_rect = new Rectangle((int)position.X, (int)position.Y, 50, 10);
            statusEffect = StatusEffects.None;
            statusEffectTimer = 0f;
            healthBarColor = Color.Green;
            immobilized = false;
            speed = 1;
        }
        public Entity(string texture, Vector2 position)
        {
            this.position = position;
            this.texture = Textures.Get(texture);
            hitbox = new Rectangle((int)position.X, (int)position.Y, this.texture.Width, this.texture.Height);
            rotation = 0;
            origin = new Vector2(this.texture.Width / 2, this.texture.Height / 2);
            spriteEffect = SpriteEffects.None;
            depth = 0.1f;
            scale = Vector2.One;
            center = new Vector2(position.X+this.texture.Width / 2, position.Y+this.texture.Height / 2);
            color = Color.White;
            isAlive = false;
            health = 0;
            maxHealth = 0;
            queuedForDeath = false;
            red_rect_texture = new Texture2D(Globals.graphicsDevice, 1, 1);
            red_rect_texture.SetData(new Color[] { Color.Red });
            green_rect_texture = new Texture2D(Globals.graphicsDevice, 1, 1);
            green_rect_texture.SetData(new Color[] { Color.Green });
            red_rect = new Rectangle((int)position.X, (int)position.Y, 50, 10);
            green_rect = new Rectangle((int)position.X, (int)position.Y, 50, 10);
            statusEffect = StatusEffects.None;
            statusEffectTimer = 0f;
            healthBarColor = Color.Green;
            immobilized = false;
            speed = 1;
        }

        public void Damage(Projectile projectile)
        {
            float health_after_damage = health - projectile.damage;
            statusEffect = projectile.statusEffect;
            if (statusEffect != StatusEffects.None)
            {
                statusEffectTimer = 10f;
                if(statusEffect == StatusEffects.Poisoned)
                {
                    SetHealthBarColor(Color.DarkGreen);
                }
                else if(statusEffect == StatusEffects.Frozen)
                {
                    SetHealthBarColor(Color.LightBlue);
                }
            }
            else
            {
                SetHealthBarColor(Color.Green);
            }
            health = health_after_damage;
        }

        public virtual void Update()
        {
            hitbox.X = (int)position.X;
            hitbox.Y = (int)position.Y;
            if (isAlive && health <= 0)
                queuedForDeath = true;
            foreach (var entity in WorldManager.world.entities)
            {
                if (entity != this && entity is Wall)
                {
                    Wall wall = entity as Wall;
                    if ((velocity.X > 0 && wall.IsTouchingLeft(this)) ||
                        (velocity.X < 0 && wall.IsTouchingRight(this)))
                        velocity.X = 0;

                    if ((velocity.Y > 0 && wall.IsTouchingTop(this)) ||
                        (velocity.Y < 0 && wall.IsTouchingBottom(this)))
                        velocity.Y = 0;
                }
            }
            if (isAlive)
            {
                StatusEffectChecks();
                UpdateHealthBar();
            }
        }
        private void StatusEffectChecks()
        {
            if (statusEffect != StatusEffects.None)
            {
                statusEffectTimer = MathHelper.Lerp(statusEffectTimer, 0, 0.1f);
                if (statusEffectTimer <= 0.0001)
                {
                    statusEffectTimer = 0;
                    statusEffect = StatusEffects.None;
                    return;
                }

                if (statusEffect == StatusEffects.Poisoned)
                {
                    if (RNG.RandomNumber(0, 100) > 90)
                        health -= 0.1f;
                }
                else if (statusEffect == StatusEffects.Frozen)
                {
                    speed = 0.5f;
                }
            }
            else if (healthBarColor != Color.Green)
            {
                SetHealthBarColor(Color.Green);
                speed = 1f;
            }
        }

        private void UpdateHealthBar()
        {
            red_rect.X = (int)position.X - 10;
            red_rect.Y = (int)position.Y - 15;
            green_rect.X = (int)position.X - 10;
            green_rect.Y = (int)position.Y - 15;
            health = MathHelper.Clamp(health, 0, maxHealth);
            float greenWidth = 50 * (health / maxHealth);
            green_rect.Width = (int)greenWidth;
        }
        private void SetHealthBarColor(Color color)
        {
            green_rect_texture.SetData(new Color[] { color });
            healthBarColor = color;
        }
        public virtual void Draw()
        {
            if (texture == null) return;
            Globals.spriteBatch.Draw(texture, position, null, color, rotation, origin, scale, spriteEffect, depth);
            if(isAlive)
            {
                Globals.spriteBatch.Draw(red_rect_texture, red_rect, null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0.05f);
                Globals.spriteBatch.Draw(green_rect_texture, green_rect, null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0.1f);
            }
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
