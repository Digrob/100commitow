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
        private static bool locked = false;
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

        public static void Lock()
        {
            locked = true;
        }

        public static void Unlock()
        {
            locked = false;
        }

        public static bool Pressed(Keys key, bool ignoreLock = false)
        {
            return (!locked || ignoreLock) && state.IsKeyDown(key) && state != prevState;
        }

        public static bool Down(Keys key, bool ignoreLock = false)
        {
            return (!locked || ignoreLock) && state.IsKeyDown(key);
        }
    }
}
