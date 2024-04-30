using UnityEngine;

namespace Sablo.Core
{
    public interface IGameFlow
    { 
        AsyncOperation OnPlay();
    }
}