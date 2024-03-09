using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100commitow.src.GameStuff.View
{
    public sealed class Screen : IDisposable
    {
        public int Width
        {
            get { return this.target.Width; }
        }

        public int Height
        {
            get { return this.target.Height; }
        }

        private readonly static int MinDim = 64;
        private readonly static int MaxDim = 4096;
        private bool isDisposed;
        private Game game;
        private RenderTarget2D target;
        private bool isSet;

        public Screen(Game game, int width, int height)
        {
            width = Util.Clamp(width, Screen.MinDim, Screen.MaxDim);
            height = Util.Clamp(height, Screen.MinDim, Screen.MaxDim);

            this.game = game ?? throw new ArgumentNullException("game");
            this.target = new RenderTarget2D(this.game.GraphicsDevice, width, height);
        }

        public void Dispose()
        {
            if (this.isDisposed)
                return;

            this.target?.Dispose();
            this.isDisposed = true;
        }

        public void Set()
        {
            if (isSet)
                throw new Exception("It's already set");
            this.game.GraphicsDevice.SetRenderTarget(this.target);
            this.isSet = true;
        }

        public void UnSet()
        {
            if (!isSet)
                throw new Exception("It isn't set");
            this.game.GraphicsDevice.SetRenderTarget(null);
            this.isSet = false;
        }

        public void Present()
        {

        }
    }
}
