using System;
using System.Collections.Generic;
using UnityEngine;

namespace Projectiles.Implementation
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class ProjectileBase : MonoBehaviour, IProjectile
    {
        private readonly HashSet<IProjectileTarget> hitTargets = new HashSet<IProjectileTarget>();
        private IProjectileEmitter sourceEmitter;
        private bool expired;
        private float lastLaunchTime;

        public GameObject GameObject => gameObject;
        public abstract float Speed { get; }
        public abstract float ExpireTime { get; }
        public abstract bool ExpireOnHit { get; }
        public List<IProjectileTargetEffect> ProjectileTargetHitEffects { get; } = new List<IProjectileTargetEffect>();
        private float TimeSinceLaunch => Time.time - lastLaunchTime;
        
        public event Action<IProjectile> OnLaunchE;
        public event Action<IProjectileTarget> OnHitE;
        public event Action<IProjectile> OnExpireE;

        private void Update()
        {
            if(expired)
            {
                return;
            }
            
            if (TimeSinceLaunch > ExpireTime)
            {
                Expire();
            }
        }

        public void Launch(IProjectileEmitter sourceEmitter, Vector3 startPosition, Vector3 direction)
        {
            ResetProjectile();
            this.sourceEmitter = sourceEmitter;
            transform.position = startPosition;
            transform.rotation = Quaternion.LookRotation(direction);
            lastLaunchTime = Time.time;
            gameObject.SetActive(true);
            OnLaunchE?.Invoke(this);
        }

        public void OnHit(IProjectileTarget target)
        {
            if (hitTargets.Contains(target) || expired)
            {
                return;
            }

            hitTargets.Add(target);
            OnHitInternal(target);
        }

        private void OnHitInternal(IProjectileTarget target)
        {
            OnHitE?.Invoke(target);
            
            if (ExpireOnHit)
            {
                Expire();
            }
            
            foreach (IProjectileTargetEffect projectileTargetHitEffect in ProjectileTargetHitEffects)
            {
                projectileTargetHitEffect.Execute(sourceEmitter, target);
            }
        }

        private void ResetProjectile()
        {
            hitTargets.Clear();
            expired = false;
        }

        private void Expire()
        {
            if (expired) return;
            
            gameObject.SetActive(false);
            expired = true;
            OnExpireE?.Invoke(this);
        }
    }
}
