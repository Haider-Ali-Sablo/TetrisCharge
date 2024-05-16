using UnityEngine;

namespace Sablo.Gameplay.Grid
{
    public class Cell
    {
        private Tile _defaultTile;
        private bool _isOccupied;
        private Vector2Int _index;
        
        public void Initialize(Tile _defaultTile, Vector2Int index)
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
        
        public void RemoveHighlightTile()
        {
            _defaultTile.RemoveHighlight();
        }

        public Vector2 GetCellPosition()
        {
            return _defaultTile.GetPosition();
        }
        
        public bool IsCellOccupied()
        {
            return _isOccupied;
        }
        
        public void SetOccupationState(bool state)
        {
            _isOccupied = state;
        }

        public void ActivateSwitch()
        {
            _defaultTile.ActivateSwitch();
        }

        public bool HasActiveSwitch()
        {
            return _defaultTile.HasActiveSwitch();
        }
    }
}