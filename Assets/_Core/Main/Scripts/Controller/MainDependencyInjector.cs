using Sablo.Home;
using Sablo.UI.Transition;
using UnityEngine;

namespace Sablo.Core
{
    public class MainDependencyInjector : BaseDependencyInjector
    {
        [SerializeField] private Transition _transition;
        [SerializeField] private HomeController _homeController;

        public override void InjectDependencies()
        {
            base.InjectDependencies();
            _homeController.TransitionHandler = _transition;
        }
        
    }
}