using _100commitow.src.Inputs;
using Microsoft.Xna.Framework.Input;
using src.GameStuff.LivingStuff;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace src.GameStuff.Objects
{
    public class Weapon
    {
        public Entity parent;
        public Projectile projectile;
        public Action onShoot;
        public Vector2 direction;

        public Weapon(Entity parent)
        {
            this.parent = parent;
        }

        public virtual void Update(Entity parent)
        {
            this.parent = parent;
            if (MouseManager.LeftPressed())
            {
                Shoot();
            }
        }

        public virtual void Shoot()
        {

        }
    }
}
