namespace Projectiles
{
    public interface IProjectileTargetEffect
    {
        void Execute(IProjectileEmitter sourceEmitter, IProjectileTarget target);
    }
}
