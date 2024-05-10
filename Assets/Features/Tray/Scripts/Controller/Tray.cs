using System.Collections.Generic;
using Sablo.Gameplay.Grid;
using UnityEngine;

namespace Sablo.Gameplay.Shape
{
    public class Tray : BaseGameplayModule, ITray
    {
        [SerializeField] private TrayView _view;
        [SerializeField] private List<BaseShape> _shapeList;
        [SerializeField] private List<Transform> _spawnTransforms;
        private List<Vector2> _spawnPoints;
        
        public IGrid GridHandler { private get; set; }
        
        public override void Initialize()
        {
            _spawnPoints = new List<Vector2>();
            InitializeView();
        }

        public override void PostInitialize()
        {
            _view.Show();
        }

        private void InitializeView()
        {
            foreach (var point in _spawnTransforms)
            {
                _spawnPoints.Add(point.position);
            }
            
            _view.Initialize(new TrayViewDataModel
            {
                TrayHandler = this,
                SpawnPoints = _spawnPoints,
                ShapeTypes = _shapeList
            });
        }
        
        private void SetData()
        {
            //todo: Get data from configs
        }
        
        void ITray.OnTrayReleased(BaseShape shape)
        {
            GridHandler.OnRelease(shape);
        }

        void ITray.OnInputDrag(Vector2 position, Vector2 plugPosition)
        {
            GridHandler.IsWithinBoundsOfGrid(position, plugPosition);
        }

        public List<Vector2Int> GetShapeTileIndices()
        {
            return _view.GetTilesIndicesOfShape();
        }
    }
}