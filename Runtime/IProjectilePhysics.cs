namespace Projectiles
{
    public interface IProjectilePhysics
    {
        void Initialize(IProjectile projectile);
        void UpdatePhysics();
        void OnCollide(IProjectileTarget target);
    }
}
