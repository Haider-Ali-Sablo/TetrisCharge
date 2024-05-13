using System.Collections.Generic;
using Sablo.Gameplay.Grid;
using UnityEngine;
using Sablo.Gameplay.PhoneCharge;
namespace Sablo.Gameplay.Shape
{
    public class BaseShape : MonoBehaviour
    {
        [SerializeField] protected List<Tile> _tiles;
        [SerializeField] private RectTransform _chargerTransform;
        [SerializeField] private RectTransform _plugTransform;
        [SerializeField] private RectTransform _shapeBounds;
        [SerializeField] private Phone _phone;
        
        private List<Vector2Int> _tileIndex;
        private bool _hasBeenPlaced;
        private Vector2Int _placementPoint;
        
        public virtual void Initialize()
        {
            SetIndexData();
            InitializePhone();
        }

        private void InitializePhone()
        {
            _phone.Initialize();
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
        
        public void MoveToPosition(Vector2 targetPosition)
        {
            _chargerTransform.position = targetPosition;
        }
        
        public Vector2 GetPlugPosition()
        {
            return _plugTransform.position;
        }

        public void SetShapePosition(Vector2 position)
        {
            _chargerTransform.position = position;
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

        public RectTransform GetShapeBounds()
        {
            return _shapeBounds;
        }

        public void SetPlugState(bool state)
        {
            _plugTransform.gameObject.SetActive(state);
            if (!state)
            {
                _phone.ChargeBattery();
            }
            else
            {
                _phone.DrainBattery();
            }
           
        }
    }
}