using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Projectiles.Implementation
{
    [Serializable]
    public class DefaultPooledProjectileEmitter : IProjectileEmitter
    {
        private readonly Dictionary<IProjectile, ObjectPool<IProjectile>> projectilePrefabToPoolLut = new Dictionary<IProjectile, ObjectPool<IProjectile>>();
        private readonly Dictionary<IProjectile, ObjectPool<IProjectile>> projectileInstanceToPoolLut = new Dictionary<IProjectile, ObjectPool<IProjectile>>();
        private readonly Dictionary<IProjectilePresentation, ObjectPool<IProjectilePresentation>> projectilePresentationPrefabToPoolLut = new Dictionary<IProjectilePresentation, ObjectPool<IProjectilePresentation>>();
        private readonly Dictionary<IProjectilePresentation, ObjectPool<IProjectilePresentation>> projectilePresentationInstanceToPoolLut = new Dictionary<IProjectilePresentation, ObjectPool<IProjectilePresentation>>();

        public void EmitProjectile(IProjectile projectilePrefab, IProjectilePresentation projectilePresentationPrefab, Vector3 startPosition, Vector3 direction)
        {
            IProjectile newProjectile = GetProjectileFromPool(projectilePrefab);
            IProjectilePresentation projectilePresentation = GetProjectilePresentationFromPool(projectilePresentationPrefab);
            projectilePresentation.Initialize(newProjectile);
            projectilePresentation.OnPresentationEnd += ProjectilePresentation_OnPresentationEnd;
            newProjectile.Launch(this, startPosition, direction);
        }

        private IProjectilePresentation GetProjectilePresentationFromPool(IProjectilePresentation projectilePresentationPrefab)
        {
            if (!projectilePresentationPrefabToPoolLut.TryGetValue(projectilePresentationPrefab, out ObjectPool<IProjectilePresentation> projectilePool))
            {
                projectilePool = new ObjectPool<IProjectilePresentation>(() => CreateProjectilePresentation(projectilePresentationPrefab), OnGetPresentation, OnReleasePresentation);
                projectilePresentationPrefabToPoolLut.Add(projectilePresentationPrefab, projectilePool);
            }
            
            IProjectilePresentation projectilePresentation = projectilePool.Get();
            projectilePresentationInstanceToPoolLut.TryAdd(projectilePresentation, projectilePool);
            return projectilePresentation;
        }

        private IProjectile GetProjectileFromPool(IProjectile projectilePrefab)
        {
            if (!projectilePrefabToPoolLut.TryGetValue(projectilePrefab, out ObjectPool<IProjectile> pool))
            {
                pool = new ObjectPool<IProjectile>(() => CreateProjectile(projectilePrefab), OnGetProjectile, OnReleaseProjectile);
                projectilePrefabToPoolLut.Add(projectilePrefab, pool);
            }

            IProjectile newProjectile = pool.Get();
            projectileInstanceToPoolLut.TryAdd(newProjectile, pool);
            return newProjectile;
        }

        private void OnGetPresentation(IProjectilePresentation projectile)
        {
        }

        private void OnReleasePresentation(IProjectilePresentation projectile)
        {
        }

        private IProjectilePresentation CreateProjectilePresentation(IProjectilePresentation projectile)
        {
            GameObject newProjectileGameObject = GameObject.Instantiate(projectile.GameObject);
            IProjectilePresentation newProjectile = newProjectileGameObject.GetComponent<IProjectilePresentation>();
            return newProjectile;
        }
        
        private void OnGetProjectile(IProjectile projectile)
        {
            projectile.OnExpireE += Projectile_OnExpireE;
        }
        
        private void OnReleaseProjectile(IProjectile projectile)
        {
        }
        
        private IProjectile CreateProjectile(IProjectile projectile)
        {
            GameObject newProjectileGameObject = GameObject.Instantiate(projectile as MonoBehaviour).gameObject;
            IProjectile newProjectile = newProjectileGameObject.GetComponent<IProjectile>();
            return newProjectile;
        }
        
        private void Projectile_OnExpireE(IProjectile projectile)
        {
            projectile.OnExpireE -= Projectile_OnExpireE;
            projectileInstanceToPoolLut[projectile].Release(projectile);
        }
        
        private void ProjectilePresentation_OnPresentationEnd(IProjectilePresentation projectilePresentation)
        {
            projectilePresentation.OnPresentationEnd -= ProjectilePresentation_OnPresentationEnd;
            projectilePresentationInstanceToPoolLut[projectilePresentation].Release(projectilePresentation);
        }
    }
}
