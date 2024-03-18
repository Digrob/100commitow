using _100commitow.src.GameStuff;
using _100commitow.src.Inputs;
using Microsoft.Xna.Framework;
using src.GameStuff.LivingStuff;
using src.GameStuff.Places;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src.GameStuff.Objects
{
    public class ProjectileThrower : Weapon
    {
        public ProjectileThrower(Entity parent) : base(parent)
        {
            this.parent = parent;
            projectile = new Projectile();
        }
        public override void Shoot()
        {
            Projectile newProjectile = projectile.Clone() as Projectile;
            newProjectile.direction = Vector2.Normalize(MouseManager.GetPosition() - Globals.camera.Center);
            newProjectile.position = parent.center + newProjectile.direction*30;
            newProjectile.parent = parent;
            newProjectile.statusEffect = StatusEffects.Poisoned;
            WorldManager.world.AddEntity(newProjectile);
        }
    }
}
    