using _100commitow.src.GameStuff.Blocks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using Newtonsoft.Json.Linq;
using src;
using src.GameStuff.Places;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace _100commitow.src.GameStuff.TileMap
{
    public class TileMap
    {
        private Texture2D tilesetTexture;
        private int tileWidth;
        private int tileHeight;
        private int tilesPerRow;
        private List<Tile> tiles;
        public TileMap(Texture2D tilesetTexture, int tileWidth, int tileHeight)
        {
            this.tilesetTexture = tilesetTexture;
            this.tileWidth = tileWidth;
            this.tileHeight = tileHeight;
            this.tilesPerRow = tilesetTexture.Width / tileWidth;
            this.tiles = new List<Tile>();
        }

        public Vector2? GetSpawnpointPos()
        {
            foreach(var tile in tiles)
            {
                    if (tile.type == Tiles.SpawnPoint)
                        return new Vector2(tile.hitbox.X, tile.hitbox.Y);
            }
            return null;
        }

        public List<Tile> LoadMap(Tiles[,] tileMapArr)
        {
            int tilesPerRow = tilesetTexture.Width / tileWidth;

            for (int y = 0; y < tileMapArr.GetLength(0); y++)
            {
                for (int x = 0; x < tileMapArr.GetLength(1); x++)
                {
                    Tiles tileType = tileMapArr[y, x];

                    bool collidable = Tile.isCollidable(tileType);

                    int posX = x * tileWidth;
                    int posY = y * tileHeight;

                    Rectangle sourceRectangle = new Rectangle(
                        (int)tileType % tilesPerRow * tileWidth,
                        (int)tileType / tilesPerRow * tileHeight,
                        tileWidth, tileHeight);

                    Tile tile = new Tile(tileType, new Rectangle(posX, posY, tileWidth, tileHeight), sourceRectangle);
                    tiles.Add(tile);
                }
            }

            return tiles;
        }

        public Texture2D GetTile(int tileIndex)
        {
            int x = (tileIndex % tilesPerRow) * tileWidth;
            int y = (tileIndex / tilesPerRow) * tileHeight;

            Texture2D tileTexture = new Texture2D(Globals.graphicsDevice, 16, 16);

            Color[] data = new Color[tileWidth * tileHeight];
            tilesetTexture.GetData(0, new Rectangle(x, y, tileWidth, tileHeight), data, 0, tileWidth * tileHeight);
            tileTexture.SetData(data);

            return tileTexture;
        }
    }
}
