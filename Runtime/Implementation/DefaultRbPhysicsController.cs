using UnityEngine;

namespace Projectiles.Implementation
{
    public class DefaultRbPhysicsController : PhysicsControllerBase
    {
        protected override IProjectilePhysicsFactory ProjectilePhysicsFactory => new DefaultRbPhysicsFactory(GetComponent<Rigidbody>());

        private void OnTriggerEnter(Collider other)
        {
            IProjectileTarget target = other.GetComponent<IProjectileTarget>();
            physics.OnCollide(target);
        }
    }
}
