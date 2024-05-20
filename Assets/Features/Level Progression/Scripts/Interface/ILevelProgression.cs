
namespace Sablo.Gameplay.LevelProgress
{
    public interface ILevelProgression
    {
        void IncreaseBatteryHealth();
        void DecreaseBatteryHealth();
        void OnNextButtonClicked();
        int GetCurrentLevel();
        void CheckIfLevelCompleted();
    }
}
