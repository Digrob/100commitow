using _100commitow.src.GameStuff.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using src;
using src.GameStuff.Controls;
using src.GameStuff.LivingStuff;
using src.GameStuff.Objects;
using src.GameStuff.Places;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100commitow.src.GameStuff.UIs
{
    public class UIWeaponSelection : UI
    {
        public UIWeaponSelection()
        {
            color = Color.Black;
            texture = new Texture2D(Globals.graphicsDevice, 1, 1);
            texture.SetData(new Color[] { Color.Black });
            Initialize();
        }

        private void Initialize()
        {
            foreach(StatusEffects statusEffect in Enum.GetValues(typeof(StatusEffects)))
            {
                Button button = new Button(new Rectangle(0,0,50,50), statusEffect.ToString(), false);
                button.color = StatusEffectManager.GetColor(statusEffect);
                button.onClick += (sender, e) =>
                {
                    (WorldManager.world.GetPlayerEntity() as Player).weapon.statusEffect = statusEffect;
                };
                AddControl(button);
            }
        }
    }
}
