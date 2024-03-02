using _100commitow.src;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src.GameStuff
{
    public class Entity : ICloneable
    {
        public World world;
        public Vector2 position;
        public Texture2D texture;

        public Entity()
        {
            this.position = Vector2.Zero;
        }
        public Entity(Vector2 position)
        {
            this.position = position;
        }
        public Entity(string texture, Vector2 position)
        {
            this.position = position;
            this.texture = Textures.Get(texture);
        }

        public virtual void Update()
        {

        }

        public virtual void Draw()
        {
            if (texture == null) return;
            Globals.spriteBatch.Draw(texture, new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height), Color.White);
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
