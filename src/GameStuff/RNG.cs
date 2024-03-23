using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100commitow.src.GameStuff
{
    public class RNG
    {
        private static Random _random;
        public static Random Random
        {
            get
            {
                if(_random == null)
                    _random = new Random();
                return _random;
            }
        }

        public static int RandomNumber(int min = 0, int max = 10)
        {
            return Random.Next(min, max);
        }
    }
}
