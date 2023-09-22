using UnityEngine;

namespace Projectiles.Implementation
{
    [RequireComponent(typeof(IProjectile))]
    public abstract class PhysicsControllerBase : MonoBehaviour
    {
        protected abstract IProjectilePhysicsFactory ProjectilePhysicsFactory { get; }
        
        private IProjectile projectile;
        protected IProjectilePhysics physics;
        
        protected virtual void Awake()
        {
            projectile = GetComponent<IProjectile>();
            physics = ProjectilePhysicsFactory.Create(projectile);
        }
        
        private void FixedUpdate()
        {
            physics.UpdatePhysics();
        }
    }
}
