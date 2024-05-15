namespace Sablo.Gameplay.LevelCompletion
{
    public interface ILevelComplete
    {
        void OnLevelComplete();
        void OnNextButtonClicked();
        int GetCurrentLevel();
    }
}