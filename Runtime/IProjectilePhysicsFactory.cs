namespace Projectiles
{
    public interface IProjectilePhysicsFactory
    {
        IProjectilePhysics Create(IProjectile projectile);
    }
}
