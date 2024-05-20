
namespace Features.Level_Progression.Scripts.Interface
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
