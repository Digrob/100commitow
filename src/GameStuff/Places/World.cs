﻿using _100commitow.src;
using _100commitow.src.GameStuff;
using _100commitow.src.GameStuff.Blocks;
using _100commitow.src.GameStuff.LivingStuff;
using _100commitow.src.GameStuff.TileMap;
using _100commitow.src.GameStuff.View;
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
        public TileMap tileMap;
        public World()
        {
            quadtree = new Quadtree(0, Globals.windowBounds);
            random = new Random();
            Initialize();
            entities.ForEach(x => quadtree.Insert(x));
        }

        public static void SetAsCurrentWorld(World world)
        {
            WorldManager.world = world;
        }

        private void Initialize()
        {
            entities = new List<Entity>()
            {
                new Player(new Microsoft.Xna.Framework.Vector2(0, 0)),
                new Wall(new Vector2(400, 200))
            };
            tileMap = new TileMap(Textures.Get("tilemap"), 16, 16);
            Tiles[,] tileMapArr = new Tiles[,]
            {
                { Tiles.First_Wall_TL, Tiles.First_Wall_TM, Tiles.First_Wall_TM, Tiles.First_Wall_TM, Tiles.First_Wall_TM, Tiles.First_Wall_TR },
                { Tiles.First_Wall_ML, Tiles.First_Wall_MM, Tiles.First_Wall_MM, Tiles.First_Wall_MM, Tiles.First_Wall_MM, Tiles.First_Wall_MR },
                { Tiles.First_Wall_ML, Tiles.First_Wall_MM, Tiles.First_Wall_MM, Tiles.First_Wall_MM, Tiles.First_Wall_MM, Tiles.First_Wall_MR },
                { Tiles.First_Wall_ML, Tiles.First_Wall_MM, Tiles.First_Wall_MM, Tiles.First_Wall_MM, Tiles.First_Wall_MM, Tiles.First_Wall_MR },
                { Tiles.First_Wall_BL, Tiles.First_Wall_BM, Tiles.First_Wall_BM, Tiles.First_Wall_BM, Tiles.First_Wall_BM, Tiles.First_Wall_BR },
            };
            tileMap.LoadMap(tileMapArr);
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
                entities.Add(new Enemy(new Vector2(100, 100)));
            }
            List<Entity> temp_list = new List<Entity>(entities);
            foreach (Entity entity in temp_list)
            {
                entity.Update();
            }
            //basic collision system, add quad tree later
            foreach (Entity entity in temp_list)
            {
                if (entity.queuedForDeath)
                {
                    RemoveEntity(entity);
                    break;
                }
                foreach (Entity another_entity in temp_list)
                {
                    if (entity == another_entity) continue;
                    if (entity is Enemy && another_entity is Projectile && entity.hitbox.Intersects(another_entity.hitbox))
                    {
                        entity.Damage(another_entity as Projectile);
                        RemoveEntity(another_entity);
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
            tileMap.Draw(2);
        }
    }
}
