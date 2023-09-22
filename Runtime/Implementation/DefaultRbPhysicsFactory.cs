using UnityEngine;

namespace Projectiles.Implementation
{
    public class DefaultRbPhysicsFactory : IProjectilePhysicsFactory
    {
        private readonly Rigidbody rb;
        
        public DefaultRbPhysicsFactory(Rigidbody rb)
        {
            this.rb = rb;
        }

        public IProjectilePhysics Create(IProjectile projectile)
        {
            return new DefaultRbPhysics(projectile, rb);
        }
    }
}
