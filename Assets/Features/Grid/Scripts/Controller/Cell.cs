using UnityEngine;

namespace Sablo.Gameplay.Grid
{
    public class Cell
    {
        private Tile _defaultTile;
        private Tile _tile;
        private bool _isOccupied;
        private Vector2Int _index;
        
        public void Initialize(Vector2 position, Tile _defaultTile, Vector2Int index)
        {
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

        public void HighlightTile()
        {
            _defaultTile.HighlightTile();
        }
        
        private void SetCellPosition(Vector2 position) { }

        public Vector2 GetCellPosition()
        {
            return _defaultTile.GetPosition();
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