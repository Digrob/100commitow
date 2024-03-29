﻿using _100commitow.src.GameStuff.DungeonGeneration;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using src;
using src.GameStuff.Places;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src.GameStuff.DungeonGeneration
{
    public class RandomizedWorld : World
    {
        public Room[,] rooms;
        private readonly int worldWidth = 160;
        private readonly int worldHeight = 160;
        private readonly int roomWidth = 16;
        private readonly int roomHeight = 16;
        private Random random = new Random();
        public RandomizedWorld()
        {
            rooms = new Room[worldWidth, worldHeight];
            GenerateRooms();
        }
        private void GenerateRooms()
        {
            Rectangle current_location = new Rectangle(0, 0, roomWidth, roomHeight);
            


        }

        public override void Draw()
        {
            foreach (Room room in rooms)
            {
                room.Draw();
            }
        }
    }
}
