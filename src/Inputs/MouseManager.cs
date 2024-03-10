using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100commitow.src.Inputs
{
    public static class MouseManager
    {
        private static MouseState state;
        private static MouseState prevState;

        public static void Update()
        {
            prevState = state;
            state = Mouse.GetState();
        }

        public static bool IsCursorInsideTheGame()
        {
            int mouseX = state.X;
            int mouseY = state.Y;
            return Globals.windowBounds.Contains(mouseX, mouseY);
        }

        public static bool LeftPressed()
        {
            return IsCursorInsideTheGame() && state.LeftButton == ButtonState.Pressed && prevState.LeftButton != ButtonState.Pressed;
        }

        public static bool LeftDown()
        {
            return IsCursorInsideTheGame() && state.LeftButton == ButtonState.Pressed && prevState.LeftButton == ButtonState.Pressed;
        }

        public static Vector2 GetPosition()
        {
            return state.Position.ToVector2();
        }
    }
}
