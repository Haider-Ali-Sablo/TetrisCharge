using System.Collections.Generic;
using Sablo.Gameplay.Shape;
using UnityEngine;

namespace Sablo.Gameplay.Grid
{
    public interface IGrid
    {
        void IsWithinBoundsOfGrid(Vector2 position, Vector2 plugPosition);
        void OnTrayRelease(BaseShape shape);
        void OnReselectionOfShape(List<Vector2Int> shapeTiles);
    }
}