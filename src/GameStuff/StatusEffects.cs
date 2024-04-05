using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100commitow.src.GameStuff
{
    public enum StatusEffects
    {
        None,
        Frozen,
        Poisoned
    }

    public class StatusEffectManager
    {
        private static Dictionary<StatusEffects, Color> statusEffectColors = new Dictionary<StatusEffects, Color>
        {
            { StatusEffects.None, Color.Green },
            { StatusEffects.Poisoned, Color.DarkGreen },
            { StatusEffects.Frozen, Color.LightBlue },
        };

        public static Color GetColor(StatusEffects effect)
        {
            return statusEffectColors[effect];
        }
    }
}
