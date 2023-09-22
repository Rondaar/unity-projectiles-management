using System.Collections.Generic;
using UnityEngine;

namespace Projectiles.Implementation
{
    [CreateAssetMenu(fileName = nameof(DefaultProjectileDataSo), menuName = nameof(Projectiles) + "/" + nameof(Projectiles.Implementation) + "/" + nameof(DefaultProjectileDataSo))]
    public class DefaultProjectileDataSo : ScriptableObject
    {
        [field: SerializeField]
        public float Speed { get; private set; }
        [field: SerializeField]
        public float ExpireTime { get; private set; }
        [field: SerializeField]
        public bool ExpireOnHit { get; private set; }
        [field: SerializeField]
        public List<ProjectileTargetEffectFactorySo> HitTargetEffectFactories { get; private set; }
    }
}
