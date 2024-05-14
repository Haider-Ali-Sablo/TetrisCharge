using System.Collections.Generic;
using Sablo.Gameplay.Shape;
using UnityEngine;

namespace Sablo.Gameplay.Grid
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "LevelGeneration/Level Data")]
    public class LevelGenerationData : ScriptableObject
    {
        public int GridWidth;
        public int GridHeight;
        public List<Vector2Int> SwitchesOnGrid;
        public List<BaseShape> ShapeTypes;
    }
}