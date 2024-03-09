using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100commitow.src.GameStuff.View
{
    public static class Util
    {
        public static int Clamp(int value, int min, int max)
        {
            if(min > max)
                throw new ArgumentOutOfRangeException("min > max");

            if (value < min)
                return min;
            else if (value > max)
                return max;
            else
                return value;
        }

        public static float Clamp(float value, float min, float max)
        {
            if (min > max)
                throw new ArgumentOutOfRangeException("min > max");

            if (value < min)
                return min;
            else if (value > max)
                return max;
            else
                return value;
        }
    }
}
