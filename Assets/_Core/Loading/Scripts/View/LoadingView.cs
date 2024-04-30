using UnityEngine;
using UnityEngine.UI;

namespace Sablo.Loading
{
    public class LoadingView : MonoBehaviour, ILoadingView
    {
        [SerializeField] private LoadingViewRefs _viewRefs;
        
        public ILoading LoadingHandler { private get; set; }
        
        void ILoadingView.Initialize()
        {
           
        }

        void ILoadingView.SetProgressState(float progress)
        {
            
        }
    }
}