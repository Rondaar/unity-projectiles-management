using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Events;

namespace Projectiles.Implementation
{
    [Serializable]
    public class DefaultProjectilePresentation : MonoBehaviour, IProjectilePresentation
    {
        [SerializeField]
        private UnityEvent onLaunch;
        [SerializeField]
        private UnityEvent onHit;
        [SerializeField]
        private UnityEvent onExpire;
        [SerializeField]
        private float timeToEndPresentationAfterExpire = 5f;
        
        private ParentConstraint parentConstraint;
        private IProjectile projectile;

        public GameObject GameObject => gameObject;
        public event Action<IProjectilePresentation> OnPresentationEnd;

        private void Awake()
        {
            parentConstraint = GetComponent<ParentConstraint>();
        }

        public void Initialize(IProjectile projectile)
        {
            this.projectile = projectile;
            projectile.OnLaunchE += Projectile_OnLaunch;
            projectile.OnHitE += Projectile_OnHit;
            projectile.OnExpireE += Projectile_OnExpire;
        }

        public void OnLaunch()
        {
            gameObject.SetActive(true);
            transform.position = projectile.GameObject.transform.position;
            transform.rotation = projectile.GameObject.transform.rotation;
            
            parentConstraint.AddSource(new ConstraintSource()
            {
                sourceTransform = projectile.GameObject.transform,
                weight = 1f
            });
            
            parentConstraint.constraintActive = true;
            projectile.OnLaunchE -= Projectile_OnLaunch;
            onLaunch.Invoke();
        }

        public void OnHit(IProjectileTarget target)
        {
            onHit.Invoke();
        }

        public void OnExpire()
        {
            parentConstraint.RemoveSource(0);
            parentConstraint.constraintActive = false;
            StartCoroutine(EndPresentationAfterExpire());
            projectile.OnExpireE -= Projectile_OnExpire;
            projectile.OnHitE -= Projectile_OnHit;
            projectile.OnLaunchE -= Projectile_OnLaunch;
            onExpire.Invoke();
        }

        private IEnumerator EndPresentationAfterExpire()
        {
            yield return new WaitForSeconds(timeToEndPresentationAfterExpire);
            OnPresentationEnd?.Invoke(this);
            gameObject.SetActive(false);
        }
        
        private void Projectile_OnLaunch(IProjectile projectile)
        {
            OnLaunch();
        }
        
        private void Projectile_OnHit(IProjectileTarget target)
        {
            OnHit(target);
        }
        
        private void Projectile_OnExpire(IProjectile projectile)
        {
            OnExpire();
        }
    }
}
