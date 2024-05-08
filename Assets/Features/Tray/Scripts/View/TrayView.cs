using System.Collections.Generic;
using Sablo.Core;
using Sablo.UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Sablo.Gameplay.Shape
{
    public class TrayView: BaseView, IPointerDownHandler, IDragHandler, IEndDragHandler
    {
        private ITray _handler;
        private List<BaseShape> _shapes;
        private TrayViewDataModel _dataModel;
        private BaseShape _currentlySelecedShape;
        
        public override void Initialize(object dataModel)
        {
            base.Initialize(dataModel);
            _dataModel = dataModel as TrayViewDataModel;
            _shapes = new List<BaseShape>();
            _handler = _dataModel.TrayHandler;
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
                var shape = Instantiate(_dataModel.ShapeTypes[index], _dataModel.SpawnPoints[index], Quaternion.identity, transform);
                shape.Initialize();
                _shapes.Add(shape);
            }
        }

        private BaseShape IsWithinBoundsOfShape(Vector2 position)
        {
            for (var index = 0; index < _shapes.Count; index++)
            {
                var rectTransform = _shapes[index].GetRectTransform();
                var isWithinBounds = RectTransformUtility.RectangleContainsScreenPoint(rectTransform, position);
                if (isWithinBounds)
                {
                    return _shapes[index];
                }
            }
            return null;
        }

        private void OnTrayReleased()
        {
            _currentlySelecedShape = null;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            var shape = IsWithinBoundsOfShape(eventData.position);
            _currentlySelecedShape = shape;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (_currentlySelecedShape != null)
            {
                _currentlySelecedShape.MoveToPosition(eventData.position);
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            OnTrayReleased();
        }
    }
}