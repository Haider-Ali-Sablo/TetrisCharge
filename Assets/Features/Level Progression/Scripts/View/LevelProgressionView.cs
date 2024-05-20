using System.Collections;
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
        private Battery _currentBattery;
        
        public override void Initialize(object model=null)
        {
            base.Initialize(model);
            _handler = model as ILevelProgression;
            //_batteryFillImage = _viewRefs.BatteryFillImage;
            _chargingAnimationDuration = Configs.ViewConfig.ChargingAnimationDuration;
            //_batteryFillImage.color =  Constants.PhoneCharging.BatteryEmptyColorCode;
            //_batteryFillImage.fillAmount = Configs.ViewConfig.BatteryEmptyTargetFillValue;
        }

        IEnumerator AnimateCells()
        {
            for (int i = _currentBattery.cells.Length - 1; i >= 0; i--)
            {
                yield return new WaitForSeconds(.15f);
                _currentBattery.cells[i].SetActive(false);
            }
        }
        
        void ChargeBattery()
        {
            _currentBattery.cells[_cellIndex].SetActive(true);
            _cellIndex++;
        }
        void DrainBattery()
        {
            _cellIndex--;
            _currentBattery.cells[_cellIndex].SetActive(false);
        }

        private int _currentLevel;
        
        public void EnableBattery(int currentLevel)
        {
            var levelData = Configs.LevelConfig.LevelData;
            var shapeCount = levelData[currentLevel].ShapeTypes.Count;
            
            var index = shapeCount-1;
            foreach (var batteries in _viewRefs.LevelBatteries)
            {
                batteries.gameObject.SetActive(false);
            }
            _currentBattery = _viewRefs.LevelBatteries[index];
            _currentBattery.gameObject.SetActive(true);
            StartCoroutine(AnimateCells());
        }

        private int _cellIndex;
        public void IncreaseBatteryHealth()
        {
            ChargeBattery();
            _handler.CheckIfLevelCompleted();
        }

        public void DecreaseBatteryHealth()
        {
            DrainBattery();
        }

        #region Old Code to charge and drain battery
        // public void IncreaseBatteryHealth(float progress)
        // {
        //     _fillValue+=progress;
        //     _batteryFillImage.color =  Constants.PhoneCharging.BatteryFullColorCode;
        //     _batteryFillImage.DOFillAmount(_fillValue, _chargingAnimationDuration).SetEase(Ease.Linear).OnComplete(
        //         () =>
        //         {
        //             _handler.CheckIfLevelCompleted();
        //         });
        // }
        // public void DecreaseBatteryHealth(float progress)
        // {
        //     _fillValue -= progress;
        //     _batteryFillImage.color =  Constants.PhoneCharging.BatteryEmptyColorCode;
        //     _batteryFillImage.DOFillAmount(_fillValue, _chargingAnimationDuration).SetEase(Ease.Linear);
        //
        // }
        #endregion

        public override void Register()
        {
            _viewRefs.OkayButton.onClick.AddListener(OnOkayButtonClick);
            _viewRefs.ReloadSceneButton.onClick.AddListener(OnReloadButtonClick);
        }

        private void OnOkayButtonClick()
        {
            _handler.OnNextButtonClicked();
        }
        
        private void OnReloadButtonClick()
        {
            _handler.OnReloadButtonClick();
        }

        public void ShowLevelCompleteScreen()
        {
            _viewRefs.InGameScreen.SetActive(false);
            _viewRefs.CompletionScreen.SetActive(true);
        }

        public void HideLevelCompleteScreen()
        {
            _viewRefs.CompletionScreen.SetActive(false);
            Unregister();
        }

    }
}