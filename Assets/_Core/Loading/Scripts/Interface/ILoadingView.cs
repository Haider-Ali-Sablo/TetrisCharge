using System;

namespace Sablo.Loading
{
    public interface ILoadingView
    {
        void Initialize();
        void SetProgressState(float progress,Action callback = null);
    }

}