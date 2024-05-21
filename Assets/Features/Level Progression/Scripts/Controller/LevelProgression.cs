using Sablo.Core;
using Sablo.Gameplay.Shape;
using Sablo.UI.LevelProgress;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sablo.Gameplay.LevelProgress
{ 
    public class LevelProgression : BaseGameplayModule, ILevelProgression 
    {
        
    [SerializeField] private LevelProgressionView _view;
    public ITray TrayHandler { private get; set; }
    public ISfxController SfxHandler { private get; set; }

    [SerializeField]private int _plugCount;
    
    public override void Initialize()
    {
        _view.Initialize(this);
        var currentLevel = GetCurrentLevelCount();
        EnableCurrentLevelBattery();
        _plugCount = Configs.LevelConfig.LevelData[currentLevel].ShapeTypes.Count;
    }

    void EnableCurrentLevelBattery()
    {
        _view.EnableBattery(GetCurrentLevelCount());
    }
    

    void ILevelProgression.CheckIfLevelCompleted()
    {
        if (TrayHandler.CheckIfAllShapesHaveBeenPlaced())
        {
            _view.ShowLevelCompleteScreen();
        }
    }

    void ILevelProgression.PlayBatteryCellAddedSfx()
    {
        SfxHandler.PlayBatteryCellAddedSfx();
    }
    void ILevelProgression.PlayBatteryCellRemovedSfx()
    {
        SfxHandler.PlayBatteryCellRemovedSfx();
    }
    void ILevelProgression.PlayLevelCompleteSfx()
    {
        SfxHandler.PlayLevelCompleteSfx();
    }
    
    void ILevelProgression.IncreaseBatteryHealth()
    {
        _view.IncreaseBatteryHealth();
        SfxHandler.PlayPlugInSfx();
    } 
    void ILevelProgression.DecreaseBatteryHealth()
    {
        _view.DecreaseBatteryHealth();
    }
    void ILevelProgression.OnNextButtonClicked()
    {
        _view.HideLevelCompleteScreen();
        UpdateLevelCountInPref();
        LoadScene();
    }

    void ILevelProgression.OnReloadButtonClick()
    {
       LoadScene();
    }

    int ILevelProgression.GetCurrentLevel()
    {
        var level = GetCurrentLevelCount();
        return level;
    }
            
    private void LoadScene()
    {
        SceneManager.LoadScene(Constants.SceneName.GameplayScene);
    }
    
    private void UpdateLevelCountInPref()
    {
        var currentLevel = GetCurrentLevelCount();
        currentLevel++;
        var levelCount = Configs.LevelConfig.LevelData.Count;
        if (currentLevel >= levelCount)
        {
            currentLevel = 1;
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

