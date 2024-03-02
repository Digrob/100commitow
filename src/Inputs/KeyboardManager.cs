using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100commitow.src.Inputs
{
    public class KeyboardManager
    {
        private static KeyboardState state;
        private static KeyboardState prevState;
        public KeyboardManager() 
        { 

        }

        public static void Update()
        {
            prevState = state;
            state = Keyboard.GetState();
        }

        public static bool Pressed(Keys key)
        {
            return state.IsKeyDown(key) && state != prevState;
        }

        public static bool Down(Keys key)
        {
            return state.IsKeyDown(key) && state == prevState;
        }
    }
}
