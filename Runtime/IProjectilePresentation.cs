using System;

namespace Projectiles
{
    public interface IProjectilePresentation : IGameObject
    {
        event Action<IProjectilePresentation> OnPresentationEnd;
        void Initialize(IProjectile projectile);
        void OnLaunch();
        void OnHit(IProjectileTarget target);
        void OnExpire();
    }
}
