using System.Collections.Generic;
using UnityEngine;

namespace Sablo.Gameplay.Shape
{
    public interface ITray
    {
        void OnTrayReleased(BaseShape shape);
        void OnInputDrag(Vector2 position, Vector2 plugPosition);
        void OnReselectionOfShape(List<Vector2Int> shapeTiles, Vector2Int placementPoint);
        List<Vector2Int> GetShapeTileIndices();
        int GetShapeCount();
        bool CheckIfAllShapesHaveBeenPlaced();

    }
}