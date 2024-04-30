namespace Sablo.Loading
{
    public interface ILoadingView
    {
        void Initialize();
        void SetProgressState(float progress);
    }

}