using Projectiles;
using UnityEngine;

namespace BasicImplementationSample.Scripts.Effects.ExampleLogTargetInfo
{
    public class ExampleLogTargetInfoEffect : IProjectileTargetEffect
    {
        public void Execute(IProjectileEmitter sourceEmitter, IProjectileTarget target)
        {
            Debug.Log($"Hit {target.GameObject.name}");
        }
    }
}
