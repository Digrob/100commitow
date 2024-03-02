using _100commitow.src.GameStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src.GameStuff
{
    public class World
    {
        public List<Entity> entities;
        public Entity character;

        public World()
        {
            entities = new List<Entity>()
            {
                new Player(new Microsoft.Xna.Framework.Vector2(0, 0))
            };
        }

        public void AddEntity(Entity entity)
        {
            entities.Add(entity);
        }

        public void RemoveEntity(Entity entity)
        {
            entities.Remove(entity);
        }

        public virtual void Update()
        {
            List<Entity> temp_list = new List<Entity>(entities);
            foreach(Entity entity in temp_list)
            {
                entity.Update();
            }
        }
        public virtual void Draw()
        {
            List<Entity> temp_list = new List<Entity>(entities);
            foreach (Entity entity in temp_list)
            {
                entity.Draw();
            }
        }
    }
}
