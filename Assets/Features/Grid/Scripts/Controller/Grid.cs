using Sablo.UI.Grid;
using UnityEngine;

namespace Sablo.Gameplay.Grid
{
    public class Grid : BaseGameplayModule
    {
        [SerializeField] private GridView _view;
        [SerializeField] private int _width;
        [SerializeField] private int _height;
        [SerializeField] private float _cellOffset;
        private Cell[,] _grid;
        
        public override void Initialize()
        {
            base.Initialize();
            
            // _width = Configs.GameConfig.GridWidth;
            // _height = Configs.GameConfig.GridHeight;
            // _cellOffset = Configs.GameConfig.CellOffsetMultiplier;
            InitializeView();
            GenerateGrid();
        }
        
        public void GenerateGrid()
        {
            _grid = new Cell[_width, _height];
        
            for (int rowIndex = 0; rowIndex < _width; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < _height; columnIndex++)
                {
                    var xPos = rowIndex * _cellOffset;
                    var yPos = columnIndex * _cellOffset;
            
                    var position = new Vector2(xPos, yPos);
                    _grid[rowIndex, columnIndex] = CreateNewCell(rowIndex, columnIndex, position);
                }
            }
        }
        
        private Cell CreateNewCell(int rowIndex, int columnIndex, Vector2 position)
        {
            var cell = new Cell();
            var tile = _view.SpawnTile(position);
            cell.Initialize(position, tile, new Vector2Int(rowIndex, columnIndex));
            return cell;
        }
        
        private void InitializeView()
        {
            _view.Initialize(new GridViewDataModel()
            {
                GridWidth = _width,
                GridHeight = _height,
                CellOffset = _cellOffset
            });
        }
    }
}