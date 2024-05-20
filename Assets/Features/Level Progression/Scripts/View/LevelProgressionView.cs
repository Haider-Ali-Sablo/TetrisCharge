using DG.Tweening;
using Features.Level_Progression.Scripts.Interface;
using Sablo.Core;
using UnityEngine;

namespace Sablo.UI
{
    public class LevelProgressionView : BaseView
    {
        [SerializeField] private LevelProgressionViewRefs _viewRefs;

        private ILevelProgression _handler;
        public override void Initialize(object model=null)
        {
            base.Initialize(model);
            _handler = model as ILevelProgression;
            _viewRefs.BatteryFillImage.color =  Constants.PhoneCharging.BatteryEmptyColorCode;
            _viewRefs.BatteryFillImage.fillAmount = Configs.ViewConfig.BatteryEmptyTargetFillValue;
        }
        public void IncreaseBatteryHealth(float progress)
        {
            _viewRefs._fillValue+=progress;
            _viewRefs.BatteryFillImage.color =  Constants.PhoneCharging.BatteryFullColorCode;
            _viewRefs.BatteryFillImage.DOFillAmount(_viewRefs._fillValue, Configs.ViewConfig.ChargingAnimationDuration).SetEase(Ease.Linear).OnComplete(
                () =>
                {
                    _handler.CheckIfLevelCompleted();
                });
        }
        public void DecreaseBatteryHealth(float progress)
        {
            _viewRefs._fillValue -= progress;
            _viewRefs.BatteryFillImage.color =  Constants.PhoneCharging.BatteryEmptyColorCode;
            _viewRefs.BatteryFillImage.DOFillAmount(_viewRefs._fillValue, Configs.ViewConfig.ChargingAnimationDuration).SetEase(Ease.Linear);

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