using System.Collections.Generic;
using UnityEngine;

public partial class GameConfig
{
    [Header("Grid")]
    public int GridWidth;
    public int GridHeight;
    public float GridCellOffsetRow;
    public float GridCellOffsetColumn;
    public List<Vector2Int> SwitchesOnGrid;
}
