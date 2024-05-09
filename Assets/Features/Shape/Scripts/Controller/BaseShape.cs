using System.Collections.Generic;
using Sablo.Gameplay.Grid;
using UnityEngine;

namespace Sablo.Gameplay.Shape
{
    public class BaseShape : MonoBehaviour
    {
        [SerializeField] protected List<Tile> _tiles;
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private RectTransform _plugTransform;
        private List<Vector2Int> _tileIndex;
        
        public virtual void Initialize()
        {
            SetIndexData();
        }

        private void SetIndexData()
        {
            _tileIndex = new List<Vector2Int>();
            
            for (var i = 0; i < _tiles.Count; i++)
            {
                _tileIndex.Add(_tiles[i].GetTileIndex());
            }
        }

        public List<Vector2Int> GetTileIndex()
        {
            return _tileIndex;
        }
        
        public void MoveToPosition(Vector2 targetPosition)
        {
            _rectTransform.position = targetPosition;
        }

        public RectTransform GetRectTransform()
        {
            return _rectTransform;
        }

        public Vector2 GetPlugPosition()
        {
            return _plugTransform.position;
        }
    }
}