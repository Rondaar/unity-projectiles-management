using Projectiles.Implementation;
using UnityEngine;

namespace BasicImplementationSample.Scripts
{
    public class PlayerProjectileEmitter : MonoBehaviour
    {
        private ProjectileEmitterControllerBase projectileEmitterControllerBase;
        private Camera cam;
        private Plane plane;
    
        private void Awake()
        {
            projectileEmitterControllerBase = GetComponent<ProjectileEmitterControllerBase>();
            cam = Camera.main;
            plane = new Plane(Vector3.up, projectileEmitterControllerBase.ProjectileSpawnPoint.position);
        }
    
        private void Update()
        {
            if(!Input.GetMouseButtonDown(0)) return;
        
            plane.SetNormalAndPosition(Vector3.up, projectileEmitterControllerBase.ProjectileSpawnPoint.position);
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (!plane.Raycast(ray, out float distance)) return;
            Vector3 hitPoint = ray.GetPoint(distance);
            Vector3 direction = (hitPoint - projectileEmitterControllerBase.ProjectileSpawnPoint.position).normalized;
            projectileEmitterControllerBase.EmitProjectile(direction);
        }
    }
}