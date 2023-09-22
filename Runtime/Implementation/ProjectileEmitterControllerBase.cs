using UnityEngine;

namespace Projectiles.Implementation
{
    public abstract class ProjectileEmitterControllerBase : MonoBehaviour
    {
        [SerializeField]
        private Transform projectileSpawnPoint;
        
        protected abstract IProjectileEmitter ProjectileEmitter { get; }
        protected abstract IProjectile ProjectilePrefab { get; }
        protected abstract IProjectilePresentation ProjectilePresentationPrefab { get; }

        public Transform ProjectileSpawnPoint => projectileSpawnPoint;

        public void EmitProjectile(Vector3 direction)
        {
            ProjectileEmitter.EmitProjectile(ProjectilePrefab, ProjectilePresentationPrefab, projectileSpawnPoint.position, direction);
        }
    }
}