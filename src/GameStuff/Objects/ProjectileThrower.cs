using _100commitow.src.GameStuff;
using _100commitow.src.GameStuff.Objects;
using _100commitow.src.GameStuff.View;
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
            projectile = new FollowingProjectile(80);
            projectile.weapon = this;
            statusEffect = StatusEffects.None;
        }
        public override void Shoot()
        {
            if (HUD.HoveringOverUI())
                return;
            Projectile newProjectile = projectile.Clone() as FollowingProjectile;
            newProjectile.direction = Vector2.Normalize(MouseManager.GetPosition() - Globals.camera.Center);
            newProjectile.position = parent.center + newProjectile.direction*30;
            newProjectile.parent = parent;
            newProjectile.statusEffect = statusEffect;
            WorldManager.world.AddEntity(newProjectile);
        }
    }
}
   