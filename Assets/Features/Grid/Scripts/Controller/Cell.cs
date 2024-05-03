using UnityEngine;

namespace Sablo.Gameplay.Grid
{
    public class Cell
    {
        private Tile _defaultTile;
        private Tile _tile;
        private bool _isOccupied;
        private Vector2Int _index;
        private Vector2 _position;
        
        public void Initialize(Vector2 position, Tile _defaultTile, Vector2Int index)
        {
            SetCellPosition(position);
            AddDefaultTile(_defaultTile);
            SetIndex(index);
        }

        private void SetIndex(Vector2Int index)
        {
            _index = index;
        }
        
        private void AddDefaultTile(Tile tile)
        {
            _defaultTile = tile;
        }
        
        private void SetCellPosition(Vector2 position)
        {
            _position = position;
        }
        
        public bool IsTileOccupied()
        {
            return _isOccupied;
        }
        
        public void AddTile(Tile tile)
        {
            _tile = tile;
            SetOccupationState(true);
        }
        
        private void SetOccupationState(bool state)
        {
            _isOccupied = state;
        }

    }
}