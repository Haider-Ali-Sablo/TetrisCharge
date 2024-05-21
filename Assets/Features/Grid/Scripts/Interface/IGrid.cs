using System.Collections.Generic;
using Sablo.Gameplay.Shape;
using UnityEngine;

namespace Sablo.Gameplay.Grid
{
    public interface IGrid
    {
        void IsWithinBoundsOfGrid(Vector3 position, Vector3 plugPosition);
        void OnTrayRelease(BaseShape shape);
        void OnReselectionOfShape(List<Vector2Int> shapeTiles);
        Vector3 GetPositionAtIndex(Vector2Int index);
    }
}