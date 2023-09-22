using Projectiles;
using UnityEngine;

namespace BasicImplementationSample.Scripts
{
    public class DefaultProjectileTarget : MonoBehaviour, IProjectileTarget
    {
        public GameObject GameObject => gameObject;
    }
}
