﻿using _100commitow.src;
using _100commitow.src.GameStuff;
using _100commitow.src.GameStuff.LivingStuff;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Sprites;
using MonoGame.Extended.TextureAtlases;
using src.GameStuff.LivingStuff;
using src.GameStuff.Objects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src.GameStuff.Places
{
    public class World
    {
        public List<Entity> entities;
        public Entity character;
        public Random random;
        public Quadtree quadtree;

        public World()
        {
            quadtree = new Quadtree(0, Globals.windowBounds);
            random = new Random();
            entities = new List<Entity>()
            {
                new Player(new Microsoft.Xna.Framework.Vector2(0, 0))
            };
            entities.ForEach(x => quadtree.Insert(x));
        }

        public void AddEntity(Entity entity)
        {
            entities.Add(entity);
            //quadtree.Insert(entity);
        }

        public void RemoveEntity(Entity entity)
        {
            entities.Remove(entity);
            //quadtree.Remove(entity);
        }

        public Entity? GetPlayerEntity()
        {
            return entities.FirstOrDefault(x=>x.GetType().Equals(typeof(Player)));
        }

        public int HowManyEntities()
        {
            return entities.Count();
        }

        public int HowManyEntities(Type entityType)
        {
            return entities.Count(x=>x.GetType() == entityType);
        }

        public virtual void Update()
        {
            if(HowManyEntities(typeof(Enemy)) < 1)
            {
                entities.Add(new Enemy(new Microsoft.Xna.Framework.Vector2(100, 100)));
            }
            List<Entity> temp_list = new List<Entity>(entities);
            foreach (Entity entity in temp_list)
            {
                entity.Update();
            }
            //basic collision system, add quad tree later
            foreach (Entity entity in temp_list)
            {
                foreach (Entity another_entity in temp_list)
                {
                    if (!(entity is Player) && !(another_entity is Player) && entity != another_entity && entity.hitbox.Intersects(another_entity.hitbox))
                    {
                        if (entity is Enemy && another_entity is Projectile)
                        {
                            RemoveEntity(another_entity);
                            RemoveEntity(entity);
                        }
                    }
                }
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
