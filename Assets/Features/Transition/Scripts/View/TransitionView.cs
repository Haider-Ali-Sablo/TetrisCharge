using UnityEngine;

namespace Sablo.UI.Transition
{
    public class TransitionView : BaseView
    {
        [SerializeField] private TransitionViewRefs _viewRefs;
        
        public override void Show()
        {
            base.Show();
            SetViewState(true);
            PlayTransition();
        }

        public override void Hide()
        {
            base.Hide();
            SetViewState(false);
        }

        public bool IsTransitionComplete()
        {
            return true;
        }

        private void PlayTransition()
        {
            
        }
    }
}

