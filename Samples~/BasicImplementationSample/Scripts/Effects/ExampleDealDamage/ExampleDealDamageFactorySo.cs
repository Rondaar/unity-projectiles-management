using Projectiles;
using Projectiles.Implementation;
using UnityEngine;

namespace BasicImplementationSample.Scripts.Effects.ExampleDealDamage
{
    [CreateAssetMenu(fileName = nameof(ExampleDealDamageFactorySo), menuName = "Projectiles/ProjectileEffects/" + nameof (ExampleDealDamageFactorySo))]
    public class ExampleDealDamageFactorySo : ProjectileTargetEffectFactorySo
    {
        public override IProjectileTargetEffect CreateEffect()
        {
            return new ExampleDealDamageEffect();
        }
    }
}
