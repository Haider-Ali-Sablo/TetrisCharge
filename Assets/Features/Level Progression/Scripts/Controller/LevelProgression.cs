using Features.Level_Progression.Scripts.Interface;
using Sablo.Core;
using Sablo.Gameplay;
using Sablo.Gameplay.LevelCompletion;
using Sablo.Gameplay.Shape;
using Sablo.UI;
using UnityEngine;

public class LevelProgression : BaseGameplayModule, ILevelProgression
{
    [SerializeField] private LevelProgressionView _view;
    public ILevelComplete LevelHandler { private get; set; }
    public ITray TrayHandler { private get; set; }


    public int plugCount;
    
    public override void Initialize()
    {
        _view.Initialize(this);
        var currentLevel = PlayerPrefs.GetInt(Constants.LevelPrefKeys.CurrentLevel, 1);
        plugCount = Configs.LevelConfig.LevelData[currentLevel].ShapeTypes.Count;
        
    }
    
    void ILevelProgression.CheckIfLevelCompleted()
    {
        if (TrayHandler.CheckIfAllShapesHaveBeenPlaced())
        {
            LevelHandler.OnLevelComplete();
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
        Debug.Log(batteryHealthValue);
        return batteryHealthValue;
    }
}

