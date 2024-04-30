using UnityEngine;

namespace Sablo.Core
{
    public class BaseDependencyInjector : MonoBehaviour
    {
        private void Awake()
        {
            InjectDependencies();
        }

        public virtual void InjectDependencies()
        {
            
        }
    }
}