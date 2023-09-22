using UnityEngine;

namespace Projectiles
{
    public interface IProjectileEmitter
    {
        public void EmitProjectile(IProjectile projectile, IProjectilePresentation presentation, Vector3 startPosition, Vector3 direction);
    }
}
