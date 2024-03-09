using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
            this.tilesetTexture = SetTextureFiltering(tilesetTexture, TextureFilter.Linear);
            this.tileWidth = tileWidth;
            this.tileHeight = tileHeight;
            this.sourceRectangles = new List<Rectangle>();
        }

        private Texture2D SetTextureFiltering(Texture2D texture, TextureFilter filter)
        {
            SamplerState samplerState = new SamplerState
            {
                Filter = filter,
                AddressU = TextureAddressMode.Clamp,
                AddressV = TextureAddressMode.Clamp
            };

            Globals.graphicsDevice.SamplerStates[0] = samplerState;

            return texture;
        }

        public void LoadMap(int[,] tileMap)
        {
            this.tileMap = tileMap;
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
