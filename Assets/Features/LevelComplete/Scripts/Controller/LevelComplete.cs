using Sablo.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sablo.Gameplay.LevelCompletion
{
    public class LevelComplete : BaseGameplayModule, ILevelComplete
    {
        [SerializeField] private LevelCompleteView _view;

        public override void Initialize()
        {
            _view.Initialize(this);
        }
        
        void ILevelComplete.OnLevelComplete()
        {
            _view.ShowLevelCompleteScreen();
        }

        void ILevelComplete.OnNextButtonClicked()
        {
            _view.HideLevelCompleteScreen();
            UpdateLevelCountInPref();
            LoadScene();
        }
        
        int ILevelComplete.GetCurrentLevel()
        {
            var level = GetCurrentLevelCount();
            return level;
        }
        
        private void LoadScene()
        {
            SceneManager.LoadScene(Constants.SceneName.MainScene);
        }

        private void UpdateLevelCountInPref()
        {
            var currentLevel = GetCurrentLevelCount();
            currentLevel++;
            if (currentLevel > 5)
            {
                SetLevel(1);
                return;
            }
            SetLevel(currentLevel);
        }
        
        private int GetCurrentLevelCount()
        {
            var currentLevel = PlayerPrefs.GetInt(Constants.LevelPrefKeys.CurrentLevel, 1);
            return currentLevel;
        }

        private void SetLevel(int level)
        {
            PlayerPrefs.SetInt(Constants.LevelPrefKeys.CurrentLevel, level);
        }
    }
}