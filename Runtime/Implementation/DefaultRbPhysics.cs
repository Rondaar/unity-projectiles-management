using System;
using UnityEngine;

namespace Projectiles.Implementation
{
    [Serializable]
    public class DefaultRbPhysics : IProjectilePhysics
    {
        private Rigidbody rb;
        private IProjectile projectile;
        
        public DefaultRbPhysics(IProjectile projectile, Rigidbody rb)
        {
            this.rb = rb;
            Initialize(projectile);
        }

        public void Initialize(IProjectile projectile)
        {
            this.projectile = projectile;
        }

        public void UpdatePhysics()
        {
            rb.MovePosition(rb.transform.position + rb.transform.forward * projectile.Speed * Time.fixedDeltaTime);
        }

        public void OnCollide(IProjectileTarget target)
        {
            if (target == null) return;
            
            projectile.OnHit(target);
        }
    }
}
