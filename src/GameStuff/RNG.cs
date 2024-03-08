using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100commitow.src.GameStuff
{
    public class RNG
    {
        private static Random random;
        public static void Initialize()
        {
            random = new Random();
        }
        public static int RandomNumber(int min = 0, int max = 10)
        {
            return random.Next(min, max);
        }
    }
}
