using Microsoft.Xna.Framework;
using MonoGame.Extended;
using MonoGame.Extended.Sprites;
using src.GameStuff.LivingStuff;
using System.Collections.Generic;

namespace _100commitow.src.GameStuff
{
    //WORK IN PROGRESS
    public class Quadtree
    {
        private const int MAX_OBJECTS_PER_NODE = 10;
        private const int MAX_LEVELS = 5;

        private int level;
        private List<Entity> sprites;
        private Rectangle bounds;
        private Quadtree[] nodes;

        public Quadtree(int level, Rectangle bounds)
        {
            this.level = level;
            sprites = new List<Entity>();
            this.bounds = bounds;
            nodes = new Quadtree[4];
        }

        public void Clear()
        {
            sprites.Clear();

            for (int i = 0; i < nodes.Length; i++)
            {
                if (nodes[i] != null)
                {
                    nodes[i].Clear();
                    nodes[i] = null;
                }
            }
        }

        public void Remove(Entity entity)
        {
            int index = GetIndex(entity);

            if (index != -1 && nodes[0] != null)
            {
                nodes[index].Remove(entity);
                return;
            }

            sprites.Remove(entity);
        }

        private void Split()
        {
            int subWidth = bounds.Width / 2;
            int subHeight = bounds.Height / 2;
            int x = bounds.X;
            int y = bounds.Y;

            nodes[0] = new Quadtree(level + 1, new Rectangle(x + subWidth, y, subWidth, subHeight));
            nodes[1] = new Quadtree(level + 1, new Rectangle(x, y, subWidth, subHeight));
            nodes[2] = new Quadtree(level + 1, new Rectangle(x, y + subHeight, subWidth, subHeight));
            nodes[3] = new Quadtree(level + 1, new Rectangle(x + subWidth, y + subHeight, subWidth, subHeight));
        }

        private int GetIndex(Entity entity)
        {
            int index = -1;
            double verticalMidpoint = bounds.X + (bounds.Width / 2);
            double horizontalMidpoint = bounds.Y + (bounds.Height / 2);

            bool topQuadrant = (entity.hitbox.Y < horizontalMidpoint && entity.hitbox.Y + entity.hitbox.Height < horizontalMidpoint);
            bool bottomQuadrant = (entity.hitbox.Y > horizontalMidpoint);

            if (entity.hitbox.X < verticalMidpoint && entity.hitbox.X + entity.hitbox.Width < verticalMidpoint)
            {
                if (topQuadrant)
                {
                    index = 1;
                }
                else if (bottomQuadrant)
                {
                    index = 2;
                }
            }
            else if (entity.hitbox.X > verticalMidpoint)
            {
                if (topQuadrant)
                {
                    index = 0;
                }
                else if (bottomQuadrant)
                {
                    index = 3;
                }
            }

            return index;
        }

        public void Insert(Entity entity)
        {
            if (nodes[0] != null)
            {
                int index = GetIndex(entity);

                if (index != -1)
                {
                    nodes[index].Insert(entity);
                    return;
                }
            }

            sprites.Add(entity);

            if (sprites.Count > MAX_OBJECTS_PER_NODE && level < MAX_LEVELS)
            {
                if (nodes[0] == null)
                {
                    Split();
                }

                int i = 0;
                while (i < sprites.Count)
                {
                    int index = GetIndex(sprites[i]);
                    if (index != -1)
                    {
                        nodes[index].Insert(sprites[i]);
                        sprites.RemoveAt(i);
                    }
                    else
                    {
                        i++;
                    }
                }
            }
        }

        public List<Entity> Retrieve(List<Entity> returnObjects, Entity entity)
        {
            int index = GetIndex(entity);
            if (index != -1 && nodes[0] != null)
            {
                nodes[index].Retrieve(returnObjects, entity);
            }

            returnObjects.AddRange(sprites);
            return returnObjects;
        }
    }
}
