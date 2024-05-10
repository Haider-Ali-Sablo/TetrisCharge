using Sablo.Core;
using Sablo.UI.Transition;
using UnityEngine;

namespace Sablo.Home
{
    public class HomeController : BaseModule ,IHome
    {
        [SerializeField] private HomeView _view;
        public ITransition TransitionHandler { private get; set; }

        public override void Initialize()
        {
            base.Initialize();
            _view.Initialize(this);
        }

        void IHome.OnPlayButtonClick()
        {
            TransitionHandler.TransitionToGameplay();
        }
    }
}
