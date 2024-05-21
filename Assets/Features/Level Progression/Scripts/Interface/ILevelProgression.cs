
namespace Sablo.Gameplay.LevelProgress
{
    public interface ILevelProgression
    {
        void IncreaseBatteryHealth();
        void DecreaseBatteryHealth();
        void OnNextButtonClicked();
        void OnReloadButtonClick();
        void PlayBatteryCellAddedSfx();
        void PlayBatteryCellRemovedSfx();
        void PlayLevelCompleteSfx();
        int GetCurrentLevel();
        void CheckIfLevelCompleted();
        
    }
}
