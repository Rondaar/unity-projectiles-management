using System;
using System.Collections.Generic;
using UnityEngine;

namespace Projectiles
{
    public interface IProjectile : IGameObject
    {
        float Speed { get; }
        float ExpireTime { get; }
        bool ExpireOnHit { get; }
        List<IProjectileTargetEffect> ProjectileTargetHitEffects { get; }
        event Action<IProjectile> OnLaunchE;
        event Action<IProjectileTarget> OnHitE;
        event Action<IProjectile> OnExpireE;
        void Launch(IProjectileEmitter sourceEmitter, Vector3 startPosition, Vector3 direction);
        void OnHit(IProjectileTarget target);
    }
}
