using System.Collections.Generic;
using System.Linq.Expressions;
using Sablo.Core;
using Sablo.Gameplay.Shape;
using Sablo.UI.Grid;
using UnityEngine;

namespace Sablo.Gameplay.Grid
{
    public class Grid : BaseGameplayModule, IGrid
    {
        [SerializeField] private GridView _view;
        [SerializeField] private Tile _baseTile;
        private int _gridWidth;
        private int _gridHeight;
        private float _cellOffset;
        private Cell[,] _grid;
        private List<Cell> _highlightedCells;
        private Vector2Int _currentClosestCell;

        
        public ITray TrayHandler { private get; set; }
        
        public override void Initialize()
        {
            base.Initialize();
            SetData();
            InitializeView();
            GenerateGrid();
        }
        
        private void SetData()
        {
            _highlightedCells = new List<Cell>();
            _currentClosestCell = new Vector2Int();
            _cellOffset = Configs.GameConfig.GridCellOffset;
            _gridWidth = Configs.GameConfig.GridWidth;
            _gridHeight = Configs.GameConfig.GridHeight;
        }
        
        public void GenerateGrid()
        {
            _grid = new Cell[_gridWidth, _gridHeight];
            
            for (int rowIndex = 0; rowIndex < _gridWidth; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < _gridHeight; columnIndex++)
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
                GridWidth = _gridWidth,
                GridHeight = _gridHeight,
                CellOffset = _cellOffset
            });
        }
        
        private bool IsWithinBoundsOfGrid(Vector2 position)
        {
            var isWithInBoundsOfGrid = _view.IsWithInBoundsOfGrid(position);
            return isWithInBoundsOfGrid;
        }

        void IGrid.IsWithinBoundsOfGrid(Vector2 position, Vector2 plugPosition)
        {
            var isWithInBoundsOfGrid = IsWithinBoundsOfGrid(position);
            RemoveHighlightFromPreviousCells();
            if (isWithInBoundsOfGrid)
            {
                HighlightShape(plugPosition);
            }
        }

        void IGrid.OnRelease(BaseShape shape)
        {
            var plugPosition = shape.GetPlugPosition();
            var isPlugWithinbounds = IsWithinBoundsOfGrid(plugPosition);
            if (isPlugWithinbounds && CanPlaceShape())
            {
                var cell = _grid[_currentClosestCell.x, _currentClosestCell.y];
                shape.SetShapePosition(cell.GetCellPosition());
            }
        }

        private bool CanPlaceShape()
        {
            for (var i = 0; i < _highlightedCells.Count; i++)
            {
                if (_highlightedCells[i].IsCellOccupied())
                {
                    return false;
                }
            }
            return true;
        }

        private void HighlightShape(Vector2 plugPosition)
        {
            var closestCell = GetClosestCell(plugPosition);
            _currentClosestCell = closestCell;
            var shapeTiles = TrayHandler.GetShapeTileIndices();
           
            for (var i=0; i< shapeTiles.Count ; i++)
            {
                var index = shapeTiles[i] + closestCell;
                if (index.x >= _gridWidth  || index.y >= _gridHeight || index.x <0 || index.y <0)
                {
                    return;
                }
                    var cell = _grid[index.x, index.y];
                    cell.HighlightTile();
                    _highlightedCells.Add(cell);
            }
        }

        private void RemoveHighlightFromPreviousCells()
        {
            if (_highlightedCells.Count == 0) {return;}
            
            for (var i = 0; i < _highlightedCells.Count; i++)
            {
                _highlightedCells[i].RemoveHighlightTile();
            }
            _highlightedCells = new List<Cell>();
        }
        
        private Vector2Int GetClosestCell(Vector2 plugPosition)
        {
            var minDistance = Mathf.Infinity;
            var closestIndex = new Vector2Int(-1, -1);

            for (int xIndex = 0; xIndex < _gridWidth; xIndex++)
            {
                for (int yIndex = 0; yIndex < _gridHeight; yIndex++)
                {
                    var cell = _grid[xIndex, yIndex];
                    var cellPosition = cell.GetCellPosition();
                    var distance = Vector2.Distance(cellPosition, plugPosition);

                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        closestIndex.x = xIndex;
                        closestIndex.y = yIndex;
                    }
                }
            }
            return closestIndex;
        }
    }
}