using UnityEngine;

namespace Projectiles.Implementation
{
    public class DefaultProjectileEmitterController : ProjectileEmitterControllerBase
    {
        [SerializeField]
        private GameObject projectilePrefabGameObject;
        [SerializeField]
        private GameObject projectilePresentationPrefabGameObject;
        
        private IProjectileEmitter projectileEmitter;
        private IProjectile projectilePrefab;
        private IProjectilePresentation projectilePresentationPrefab;
        protected override IProjectileEmitter ProjectileEmitter => projectileEmitter;
        protected override IProjectile ProjectilePrefab => projectilePrefab;
        protected override IProjectilePresentation ProjectilePresentationPrefab => projectilePresentationPrefab;

        private void Awake()
        {
            projectilePrefab = projectilePrefabGameObject.GetComponent<IProjectile>();
            projectilePresentationPrefab = projectilePresentationPrefabGameObject.GetComponent<IProjectilePresentation>();
            projectileEmitter = new DefaultPooledProjectileEmitter();
        }
    }
}
