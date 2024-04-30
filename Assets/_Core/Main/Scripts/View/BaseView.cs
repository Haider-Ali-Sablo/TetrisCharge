using UnityEngine;

namespace Sablo.UI
{
    public class BaseView : MonoBehaviour
    {
        public virtual void Show()
        {
            Register();
        }

        public virtual  void Register()
        {
            
        }
        
        public virtual void Unregister()
        {
            
        }
        
        public virtual void Hide()
        {
            Unregister();
        }

        public void SetViewState(bool state) => gameObject.SetActive(state);

    }
}

