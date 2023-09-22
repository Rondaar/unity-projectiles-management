using Projectiles;
using UnityEngine;

namespace BasicImplementationSample.Scripts.Effects.ExampleDebugLog
{
    public class ExampleDebugLogEffect : IProjectileTargetEffect
    {
        private readonly string message;
        
        public ExampleDebugLogEffect(string message)
        {
            this.message = message;
        }
        
        public void Execute(IProjectileEmitter sourceEmitter, IProjectileTarget target)
        {
            Debug.Log(message);
        }
    }
}
