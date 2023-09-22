using Projectiles;
using Projectiles.Implementation;
using UnityEngine;

namespace BasicImplementationSample.Scripts.Effects.ExampleDebugLog
{
    [CreateAssetMenu(fileName = nameof(ExampleDebugLogEffectFactorySo), menuName = "Projectiles/ProjectileEffects/" + nameof (ExampleDebugLogEffectFactorySo))]
    public class ExampleDebugLogEffectFactorySo : ProjectileTargetEffectFactorySo
    {
        [SerializeField]
        private string message;
        
        public override IProjectileTargetEffect CreateEffect()
        {
            return new ExampleDebugLogEffect(message);
        }
    }
}
