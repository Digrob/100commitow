﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using src;
using src.GameStuff.Places;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100commitow.src.GameStuff.Places
{
    public class RandomizedWorld : World
    {
        public Room[,] rooms;
        private readonly int worldWidth = 160;
        private readonly int worldHeight = 160;
        private Random random = new Random();
        public RandomizedWorld()
        {
            rooms = new Room[worldWidth, worldHeight];
            GenerateRooms();
        }

        private void GenerateRooms()
        {
            //here will be the code for randomizing the level
            //imagine that there's a square in the center,
            //and the snake comes out of it, and goes in random directions
            //and it leaves the spaces behind it
            //that's gonna be the room generation later
        }

        public override void Draw()
        {
            foreach(Room room in rooms)
            {
                room.Draw();
            }
        }
    }
}
