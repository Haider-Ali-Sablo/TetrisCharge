using Sablo.UI;
using UnityEngine;

namespace Sablo.Gameplay.LevelCompletion
{
    public class LevelCompleteView : BaseView
    {
        [SerializeField] private LevelCompletionViewRefs _viewRefs;
        private ILevelComplete _handler;
        
        public override void Initialize(object model=null)
        {
            base.Initialize(model);
            _handler = model as ILevelComplete;
        }

        public override void Register()
        {
            _viewRefs.OkayButton.onClick.AddListener(OnOkayButtonClick);
        }

        private void OnOkayButtonClick()
        {
            _handler.OnNextButtonClicked();
        }

        public void ShowLevelCompleteScreen()
        {
            _viewRefs.CompletionScreen.SetActive(true);
        }

        public void HideLevelCompleteScreen()
        {
            _viewRefs.CompletionScreen.SetActive(false);
            Unregister();
        }
    }
}