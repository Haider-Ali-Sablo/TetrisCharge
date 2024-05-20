using Features.Level_Progression.Scripts.Interface;
using Sablo.Core;
using Sablo.Gameplay;
using Sablo.Gameplay.Shape;
using Sablo.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelProgression : BaseGameplayModule, ILevelProgression
{
    [SerializeField] private LevelProgressionView _view;
    public ITray TrayHandler { private get; set; }
    public int plugCount;
    
    public override void Initialize()
    {
        _view.Initialize(this);
        var currentLevel = GetCurrentLevelCount();
        plugCount = Configs.LevelConfig.LevelData[currentLevel].ShapeTypes.Count;
        
    }
    

    void ILevelProgression.CheckIfLevelCompleted()
    {
        if (TrayHandler.CheckIfAllShapesHaveBeenPlaced())
        {
            _view.ShowLevelCompleteScreen();
        }
    }
    
    void ILevelProgression.IncreaseBatteryHealth()
    {
        _view.IncreaseBatteryHealth(GetBatterHealthBasedOnShapes());
    } 
    void ILevelProgression.DecreaseBatteryHealth()
    {
        _view.DecreaseBatteryHealth(GetBatterHealthBasedOnShapes());
    }
    
    private float GetBatterHealthBasedOnShapes()
    { 
        float batteryHealthValue = 0;
        batteryHealthValue = 1.0f/plugCount;
        return batteryHealthValue;
    } 

    void ILevelProgression.OnNextButtonClicked()
    {
        _view.HideLevelCompleteScreen();
        UpdateLevelCountInPref();
        LoadScene();
    }
            
    int ILevelProgression.GetCurrentLevel()
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

