using _100commitow.src.GameStuff.LivingStuff;
using Microsoft.Xna.Framework;
using src.GameStuff.LivingStuff;
using src.GameStuff.Objects;
using src.GameStuff.Places;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100commitow.src.GameStuff.Objects
{
    public class FollowingProjectile : Projectile
    {
        public float followRadius;
        public FollowingProjectile(float followRadius = 10)
        {
            this.followRadius = followRadius;
        }

        private Entity? GetClosestEntity()
        {
            Entity closestEntity = null;
            float closestDistance = float.MaxValue;
            foreach (Entity entity in WorldManager.world.entities)
            {
                if (!(entity is Enemy)) continue;
                float distance = Vector2.Distance(position, entity.position);
                if (distance < followRadius && distance < closestDistance)
                {
                    closestDistance = distance;
                    closestEntity = entity;
                }
            }
            return closestEntity;
        }

        public override void Update()
        {
            Entity closestEntity = GetClosestEntity();
            if (closestEntity != null)
                direction = Vector2.Normalize(closestEntity.position - position);
            base.Update();

        }
    }
}
