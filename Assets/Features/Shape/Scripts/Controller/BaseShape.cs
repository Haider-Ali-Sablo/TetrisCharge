using System.Collections.Generic;
using Sablo.Gameplay.Grid;
using UnityEngine;
using DG.Tweening;
using Sablo.Core;

namespace Sablo.Gameplay.Shape
{
    public class BaseShape : MonoBehaviour
    {
        [SerializeField] protected List<Tile> _tiles;
        [SerializeField] private Transform _chargerTransform;
        [SerializeField] private Transform _plugTransform;
        [SerializeField] private Collider _shapeBounds;
        private Vector3 _defaultPosition;
        
        private List<Vector2Int> _tileIndex;
        private bool _hasBeenPlaced;
        private Vector2Int _placementPoint;
        
        public virtual void Initialize(Vector3 defaultPosition)
        {
            _defaultPosition = defaultPosition;
            SetIndexData();
        }

        private void SetIndexData()
        {
            _tileIndex = new List<Vector2Int>();
            _placementPoint = new Vector2Int();
            
            for (var i = 0; i < _tiles.Count; i++)
            {
                _tileIndex.Add(_tiles[i].GetTileIndex());
            }
        }

        public List<Vector2Int> GetTileIndex()
        {
            return _tileIndex;
        }
        
        public Vector3 GetPlugPosition()
        {
            return _plugTransform.position;
        }

        public bool HasBeenPlaced()
        {
            return _hasBeenPlaced;
        }

        public Vector2Int GetPlacementPoint()
        {
            return _placementPoint;
        }
        
        public void SetPlacementPoint(Vector2Int placementPoint)
        {
            _placementPoint = placementPoint;
        }

        public void SetPlacementState(bool state)
        {
            _hasBeenPlaced = state;
        }

        public void SetPlugState(bool state)
        {
            _plugTransform.gameObject.SetActive(state);
        }
        
        public void SetShapePosition(Vector3 targetPosition, float movementSpeed)
        {
            var xOffset = Configs.ViewConfig.XOffsetonShapePickup;
            var zOffset = Configs.ViewConfig.ZOffsetonShapePickup;
            
            var offSet = new Vector3(xOffset, 0, zOffset);
            _chargerTransform.position += offSet;
            _chargerTransform.position = Vector3.Lerp(_chargerTransform.position, targetPosition, movementSpeed);
        }

        public void PlaceShapeOnCell(Vector3 cellPosition)
        {
            var placementDuration = Configs.ViewConfig.ShapePositionResetDuration;
            _chargerTransform.DOMove(cellPosition,placementDuration);
        }
        

        public void ReturnToOriginalPosition()
        {
            var returnDuration = Configs.ViewConfig.ShapePositionResetDuration;
            _chargerTransform.DOMove(_defaultPosition,returnDuration).SetEase(Ease.OutQuart);
        }
    }
}