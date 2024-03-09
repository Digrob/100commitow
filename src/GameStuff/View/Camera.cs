using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100commitow.src.GameStuff.View
{
    public class Camera
    {
        public readonly static float MinZ = 1f;
        public readonly static float MaxZ = 2048f;

        private Vector2 pos;
        private float z;
        private float baseZ;
        private float aspectRatio;
        private float fieldOfView;
        private Matrix view;
        private Matrix projection;

        public Camera(Screen screen)
        {
            if(screen is null)
            {
                throw new ArgumentNullException("screen");
            }

            pos = new Vector2(0, 0);
            baseZ = 1;
            z = baseZ;
            aspectRatio = (float)screen.Width / screen.Height;
        }
    }
}
