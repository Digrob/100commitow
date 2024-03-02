using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100commitow.src.Inputs
{
    public class MouseManager
    {
        private static MouseState state;
        private static MouseState prevState;
        public MouseManager()
        {

        }

        public static void Update()
        {
            prevState = state;
            state = Mouse.GetState();
        }

        public static bool LeftPressed()
        {
            return state.LeftButton == ButtonState.Pressed && state != prevState;
        }

        public static bool LeftDown()
        {
            return state.LeftButton == ButtonState.Pressed && state == prevState;
        }

        public static Vector2 GetPosition()
        {
            return state.Position.ToVector2();
        }
    }
}
