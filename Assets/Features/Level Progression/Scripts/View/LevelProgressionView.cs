using System.Collections;
using System.Threading.Tasks;
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
        
        private Battery _currentBattery;
        private int _currentLevel;

        
        public override void Initialize(object model=null)
        {
            base.Initialize(model);
            _handler = model as ILevelProgression;
        }

        IEnumerator AnimateCells()
        {
            for (int i = _currentBattery.cells.Length - 1; i >= 0; i--)
            {
                yield return new WaitForSeconds(.17f);
                _currentBattery.cells[i].SetActive(false);
            }
        }
        
        void ChargeBattery()
        {
            _currentBattery.cells[_cellIndex].SetActive(true);
            _handler.PlayBatteryCellAddedSfx();
            _cellIndex++;
        }
        void DrainBattery()
        {
            _cellIndex--;
            _currentBattery.cells[_cellIndex].SetActive(false);
            _handler.PlayBatteryCellRemovedSfx();
        }

        
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
            StartCoroutine(ShowLevelCompleteScreenWithDelay(.5f));
        }
        private IEnumerator ShowLevelCompleteScreenWithDelay(float delay)
        {
            yield return new WaitForSeconds(delay);
            _handler.PlayLevelCompleteSfx();
            _viewRefs.InGameScreen.SetActive(false);
            yield return new WaitForSeconds(delay);
            _viewRefs.CompletionScreen.SetActive(true);
        }

        public void HideLevelCompleteScreen()
        {
            _viewRefs.CompletionScreen.SetActive(false);
            Unregister();
        }

    }
}