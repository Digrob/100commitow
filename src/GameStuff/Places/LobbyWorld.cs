using _100commitow.src.GameStuff.TileMap;
using Microsoft.Xna.Framework;
using src.GameStuff.LivingStuff;
using src.GameStuff.Places;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100commitow.src.GameStuff.Places
{
    public class LobbyWorld : World
    {
        public LobbyWorld() 
        {
            Initialize();
            spawnPoint = tileMap.GetSpawnpointPos();
            character = new Player((Vector2)spawnPoint);
        }
        private void Initialize()
        {
            Tiles[,] tileMapArr = new Tiles[,]
            {
                { Tiles.First_Wall_TL, Tiles.First_Wall_TM, Tiles.First_Wall_TM, Tiles.First_Wall_TM, Tiles.First_Wall_TM, Tiles.First_Wall_TR },
                { Tiles.First_Wall_ML, Tiles.First_Wall_MM, Tiles.First_Wall_MM, Tiles.First_Wall_MM, Tiles.First_Wall_MM, Tiles.First_Wall_MR },
                { Tiles.First_Wall_ML, Tiles.First_Wall_MM, Tiles.First_Wall_MM, Tiles.First_Wall_MM, Tiles.First_Wall_MM, Tiles.First_Wall_MR },
                { Tiles.First_Wall_ML, Tiles.First_Wall_MM, Tiles.First_Wall_MM, Tiles.First_Wall_MM, Tiles.First_Wall_MM, Tiles.First_Wall_MR },
                { Tiles.First_Wall_ML, Tiles.First_Wall_MM, Tiles.First_Wall_MM, Tiles.First_Wall_MM, Tiles.First_Wall_MM, Tiles.First_Wall_MR },
                { Tiles.First_Wall_ML, Tiles.First_Wall_MM, Tiles.SpawnPoint, Tiles.First_Wall_MM, Tiles.First_Wall_MM, Tiles.First_Wall_MR },
                { Tiles.First_Wall_ML, Tiles.First_Wall_MM, Tiles.First_Wall_MM, Tiles.First_Wall_MM, Tiles.First_Wall_MM, Tiles.First_Wall_MR },
                { Tiles.First_Wall_ML, Tiles.First_Wall_MM, Tiles.First_Wall_MM, Tiles.First_Wall_MM, Tiles.First_Wall_MM, Tiles.First_Wall_MR },
                { Tiles.First_Wall_ML, Tiles.First_Wall_MM, Tiles.First_Wall_MM, Tiles.First_Wall_MM, Tiles.First_Wall_MM, Tiles.First_Wall_MR },
                { Tiles.First_Wall_ML, Tiles.First_Wall_MM, Tiles.First_Wall_MM, Tiles.First_Wall_MM, Tiles.First_Wall_MM, Tiles.First_Wall_MR },
                { Tiles.First_Wall_BL, Tiles.First_Wall_BM, Tiles.First_Wall_BM, Tiles.First_Wall_BM, Tiles.First_Wall_BM, Tiles.First_Wall_BR },
            };
            List<Tile> tiles = tileMap.LoadMap(tileMapArr);
            foreach(var tile in tiles)
            {
                AddEntity(tile);
            }
        }
    }
}