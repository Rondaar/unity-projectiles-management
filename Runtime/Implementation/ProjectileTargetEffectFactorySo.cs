using UnityEngine;

namespace Projectiles.Implementation
{
    public abstract class ProjectileTargetEffectFactorySo : ScriptableObject, IProjectileTargetEffectFactory
    {
        public abstract IProjectileTargetEffect CreateEffect();
    }
}
