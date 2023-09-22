using Projectiles;
using UnityEngine;

namespace BasicImplementationSample.Scripts.Effects.ExampleDealDamage
{
    public class ExampleDealDamageEffect : IProjectileTargetEffect
    {
        public void Execute(IProjectileEmitter sourceEmitter, IProjectileTarget target)
        {
            /* Example Usage:
            IDamageable = target.GameObject.GetComponent<IDamageable>();
            IDealDamage = sourceEmitter.GameObject.GetComponent<IDealDamage>();
  
            if (damageable != null)
            {
                damageable.Hp -= dealDamage.Damage;
            }  
            */
            
            Debug.Log($"Damage dealt to {target.GameObject.name}");
        }
    }
}
