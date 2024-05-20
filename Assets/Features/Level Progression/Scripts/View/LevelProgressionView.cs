using DG.Tweening;
using Sablo.Gameplay.LevelProgress;
using Sablo.Core;
using Sablo.UI.LevelProgression;
using UnityEngine;
using UnityEngine.UI;


namespace Sablo.UI.LevelProgress
{
    public class LevelProgressionView : BaseView
    {
        [SerializeField] private LevelProgressionViewRefs _viewRefs;

        private ILevelProgression _handler;
        
        private float _fillValue;
        private float _chargingAnimationDuration;
        private Image _batteryFillImage;
        public override void Initialize(object model=null)
        {
            base.Initialize(model);
            _handler = model as ILevelProgression;
            _batteryFillImage = _viewRefs.BatteryFillImage;
            _chargingAnimationDuration = Configs.ViewConfig.ChargingAnimationDuration;
            _batteryFillImage.color =  Constants.PhoneCharging.BatteryEmptyColorCode;
            _batteryFillImage.fillAmount = Configs.ViewConfig.BatteryEmptyTargetFillValue;
        }
        public void IncreaseBatteryHealth(float progress)
        {
            _fillValue+=progress;
            _batteryFillImage.color =  Constants.PhoneCharging.BatteryFullColorCode;
            _batteryFillImage.DOFillAmount(_fillValue, _chargingAnimationDuration).SetEase(Ease.Linear).OnComplete(
                () =>
                {
                    _handler.CheckIfLevelCompleted();
                });
        }
        public void DecreaseBatteryHealth(float progress)
        {
            _fillValue -= progress;
            _batteryFillImage.color =  Constants.PhoneCharging.BatteryEmptyColorCode;
            _batteryFillImage.DOFillAmount(_fillValue, _chargingAnimationDuration).SetEase(Ease.Linear);

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