using System.Collections.Generic;
using UnityEngine;

namespace Sablo.Gameplay.Shape
{
    public interface ITray
    {
        void OnTrayReleased();
        void OnInputDrag(Vector2 position, Vector2 plugPosition);
        List<Vector2Int> GetShapeTileIndices();
    }
}