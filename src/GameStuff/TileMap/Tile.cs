using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100commitow.src.GameStuff.TileMap
{
    public class Tile
    {
        public Tiles type;

        public Tile()
        { 
            
        }

        public static bool isCollidable(Tiles tile)
        {
            List<Tiles> non_collidables = new List<Tiles>()
            {
                Tiles.Air,
                Tiles.First_Wall_MM
            };
            return !non_collidables.Contains(tile);
        }
    }
}
