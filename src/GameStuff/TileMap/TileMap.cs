using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using Newtonsoft.Json.Linq;
using src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100commitow.src.GameStuff.TileMap
{
    public class TileMap
    {
        private Texture2D tilesetTexture;
        private int tileWidth;
        private int tileHeight;
        private int[,] tileMap;
        private List<Rectangle> sourceRectangles;
        public TileMap(Texture2D tilesetTexture, int tileWidth, int tileHeight)
        {
            this.tilesetTexture = tilesetTexture;
            this.tileWidth = tileWidth;
            this.tileHeight = tileHeight;
            this.sourceRectangles = new List<Rectangle>();
        }

        private int[,] Rotate2DArray(int[,] array)
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);
            int[,] transposedArray = new int[cols, rows];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    transposedArray[j, i] = array[i, j];
                }
            }
            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows / 2; j++)
                {
                    int temp = transposedArray[i, j];
                    transposedArray[i, j] = transposedArray[i, rows - j - 1];
                    transposedArray[i, rows - j - 1] = temp;
                }
            }
            return transposedArray;
        }
        public void LoadMap(Tiles[,] tileMap)
        {
            int[,] intArray = new int[tileMap.GetLength(0), tileMap.GetLength(1)];

            for (int i = 0; i < tileMap.GetLength(0); i++)
            {
                for (int j = 0; j < tileMap.GetLength(1); j++)
                {
                    intArray[i, j] = (int)tileMap[i, j];
                }
            }
            int[,] rotatedArray = Rotate2DArray(intArray);
            this.tileMap = rotatedArray;
            int tilesPerRow = tilesetTexture.Width / tileWidth;
            sourceRectangles.Clear();
            for (int y = 0; y < tilesPerRow; y++)
            {
                for (int x = 0; x < tilesPerRow; x++)
                {
                    Rectangle sourceRectangle = new Rectangle(x * tileWidth, y * tileHeight, tileWidth, tileHeight);
                    sourceRectangles.Add(sourceRectangle);
                }
            }
        }

        public void Draw(int tileScale = 1)
        {
            for (int y = 0; y < tileMap.GetLength(1); y++)
            {
                for (int x = 0; x < tileMap.GetLength(0); x++)
                {
                    int tileIndex = tileMap[x, y];

                    if (tileIndex >= 0 && tileIndex < sourceRectangles.Count)
                    {
                        Rectangle sourceRectangle = sourceRectangles[tileIndex];
                        Rectangle destinationRectangle = new Rectangle(x * tileWidth * tileScale, y * tileHeight * tileScale, tileWidth * tileScale, tileHeight * tileScale);
                        Globals.spriteBatch.Draw(tilesetTexture, destinationRectangle, sourceRectangle, Color.White);
                    }
                }
            }
        }
    }
}
