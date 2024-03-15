using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100commitow.src.GameStuff.TileMap
{
    //TL - top left, BR - bottom right, etc...
    public enum Tiles
    {
        Air = 0,
        SpawnPoint = 1,
        First_Wall_TL = 16,
        First_Wall_TM = 17,
        First_Wall_TR = 18,
        First_Wall_ML = 31,
        First_Wall_MM = 32,
        First_Wall_MR = 33,
        First_Wall_BL = 46,
        First_Wall_BM = 47,
        First_Wall_BR = 48,
        Door = 2,
        Chest = 3,
        Barrel = 190
    }
}
