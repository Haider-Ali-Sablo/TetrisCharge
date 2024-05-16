using System.Collections.Generic;
using Sablo.Core;
using Sablo.UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Sablo.Gameplay.Shape
{
    public class TrayView: BaseView, IPointerDownHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] private TrayViewRefs _viewRefs;
        private ITray _handler;
        private List<BaseShape> _shapes;
        private TrayViewDataModel _dataModel;
        private BaseShape _currentlySelecedShape;
        private List<Vector3> _spawnPositions;
        private Vector3 _previousTouchPosition;
        
        public override void Initialize(object dataModel)
        {
            base.Initialize(dataModel);
            _dataModel = dataModel as TrayViewDataModel;
            _shapes = new List<BaseShape>();
            _handler = _dataModel.TrayHandler;
            SetSpawnPoints();
        }

        private void SetSpawnPoints()
        {
            _spawnPositions = new List<Vector3>();
            var spawnTransforms = _viewRefs.SpawnTransforms;
            var pointCount = spawnTransforms.Count;
            for (var index = 0; index < pointCount; index++)
            {
                _spawnPositions.Add(spawnTransforms[index].position);
            }
        }
        
        public override void Show()
        {
            base.Show();
            SpawnShapes();
        }

        public void SpawnShapes()
        {
            for (var index = 0; index < _dataModel.ShapeTypes.Count; index++)
            {
                var shape = Instantiate(_dataModel.ShapeTypes[index], _spawnPositions[index], Quaternion.identity, _viewRefs.SpawnParent);
                shape.Initialize();
                _shapes.Add(shape);
            }
        }

        private BaseShape IsWithinBoundsOfShape(Vector2 position)
        {
            for (var index = 0; index < _shapes.Count; index++)
            {
                return default;
            }
            return null;
        }

        private void OnTrayReleased()
        {
            _handler.OnTrayReleased(_currentlySelecedShape);
            _currentlySelecedShape = null;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
             _currentlySelecedShape = SelectShape(eventData.position);
             if (_currentlySelecedShape != null)
             {
                 _currentlySelecedShape.SetPlugState(true);
                 var placementStatus = _currentlySelecedShape.HasBeenPlaced();
                 if (placementStatus)
                 {
                     var shapeTiles = _currentlySelecedShape.GetTileIndex();
                     var anchorPoint = _currentlySelecedShape.GetPlacementPoint();
                     _handler.OnReselectionOfShape(shapeTiles, anchorPoint);
                     _currentlySelecedShape.SetPlacementState(false);
                 }
             }
        }

        private BaseShape SelectShape(Vector2 touchPosition)
        {
            var ray = Camera.main.ScreenPointToRay(touchPosition);
            var  rayCastHit = new RaycastHit();
        
            if (Physics.Raycast(ray, out rayCastHit))
            {
                var selectedObject = rayCastHit.collider.gameObject;
                var shape = selectedObject.GetComponent<BaseShape>();
                _previousTouchPosition = touchPosition;
                return shape;
            }
            return null;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (_currentlySelecedShape != null)
            {
                var shapePosition = eventData.position;
                var plugPosition = _currentlySelecedShape.GetPlugPosition();
                DragShape(shapePosition);
                _handler.OnInputDrag(shapePosition, plugPosition);
            }
        }
        
        private void DragShape(Vector2 touchPosition)
        {
            var dragSpeed = Configs.ViewConfig.ShapeDragSpeed;
            var delta = touchPosition - (Vector2)_previousTouchPosition;
            var worldDelta = new Vector3(delta.x, 0, delta.y) * dragSpeed;

            _currentlySelecedShape.transform.position +=(worldDelta);
            _previousTouchPosition = touchPosition;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if(_currentlySelecedShape!=null){  OnTrayReleased();}
        }

        public List<Vector2Int> GetTilesIndicesOfShape()
        {
            return _currentlySelecedShape.GetTileIndex();
        }

        public bool HaveAllShapesBeenPlaced()
        {
            var allShapesHaveBeenPlaced = true;
            foreach (var shape in _shapes)
            {
                if (!shape.HasBeenPlaced())
                {
                    allShapesHaveBeenPlaced = false;
                }
            }
            return allShapesHaveBeenPlaced;
        }
    }
}