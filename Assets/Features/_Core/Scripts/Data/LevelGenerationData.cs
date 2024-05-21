using System.Collections.Generic;
using Sablo.Gameplay.Shape;
using UnityEngine;

namespace Sablo.Gameplay.Grid
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "LevelGeneration/Level Data")]
    public class LevelGenerationData : ScriptableObject
    {
        public List<Vector2Int> SwitchesOnGrid;
        public List<Vector2Int> InActiveTilesOnGrid;
        public List<BaseShape> ShapeTypes;
    }
}