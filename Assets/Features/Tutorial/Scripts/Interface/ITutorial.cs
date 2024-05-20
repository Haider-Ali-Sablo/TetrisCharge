using UnityEngine;

namespace Sablo.Core.Tutorial
{
    public interface ITutorial
    {
        Vector3 GetPositionOfFirstCell();
        Vector3 GetPositionOfSecondCell();
    }
}