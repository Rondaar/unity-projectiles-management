using Projectiles;
using Projectiles.Implementation;
using UnityEngine;

namespace BasicImplementationSample.Scripts.Effects.ExampleLogTargetInfo
{
    [CreateAssetMenu(fileName = nameof(ExampleLogTargetInfoEffectFactorySo), menuName = "Projectiles/ProjectileEffects/" + nameof (ExampleLogTargetInfoEffectFactorySo))]
    public class ExampleLogTargetInfoEffectFactorySo : ProjectileTargetEffectFactorySo
    {
        public override IProjectileTargetEffect CreateEffect()
        {
            return new ExampleLogTargetInfoEffect();
        }
    }
}
