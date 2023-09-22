using UnityEngine;

namespace Projectiles.Implementation
{
    public class DefaultProjectile : ProjectileBase
    {
        [SerializeField]
        private DefaultProjectileDataSo initialData;
        
        public override float Speed => initialData.Speed;
        public override float ExpireTime => initialData.ExpireTime;
        public override bool ExpireOnHit => initialData.ExpireOnHit;
        
        private void Awake()
        {
            foreach (IProjectileTargetEffectFactory projectileTargetEffectFactory in initialData.HitTargetEffectFactories)
            {
                ProjectileTargetHitEffects.Add(projectileTargetEffectFactory.CreateEffect());
            }
        }
    }
}
