using System.Collections.Generic;
using Sablo.Gameplay.Grid;
using UnityEngine;
using Sablo.Core;

namespace Sablo.Gameplay.Shape
{
    public class Tray : BaseGameplayModule, ITray
    {
        [SerializeField] private TrayView _view;
        [SerializeField] private List<Transform> _spawnTransforms;
        private List<BaseShape> _shapeList;
        private List<Vector2> _spawnPoints;
        
        public IGrid GridHandler { private get; set; }
        
        
        public override void Initialize()
        {
            SetData();
            InitializeView();
        }
        
        public override void PostInitialize()
        {
            _view.Show();
        }

        private void SetData()
        {
            var currentLevel = PlayerPrefs.GetInt(Constants.LevelPrefKeys.CurrentLevel, Configs.LevelConfig.DefaultLevel);
            _shapeList = Configs.LevelConfig.LevelData[currentLevel].ShapeTypes;
            SetSpawnPoints();
        }

        private void InitializeView()
        {
            _view.Initialize(new TrayViewDataModel
            {
                TrayHandler = this,
                SpawnPoints = _spawnPoints,
                ShapeTypes = _shapeList
            });
        }

        private void SetSpawnPoints()
        {
            _spawnPoints = new List<Vector2>();
            foreach (var point in _spawnTransforms)
            {
                _spawnPoints.Add(point.position);
            }
        }
        
        void ITray.OnTrayReleased(BaseShape shape)
        {
            GridHandler.OnTrayRelease(shape);
        }

        void ITray.OnInputDrag(Vector2 position, Vector2 plugPosition)
        {
            GridHandler.IsWithinBoundsOfGrid(position, plugPosition);
        }

        void ITray.OnReselectionOfShape(List<Vector2Int> shapeTiles, Vector2Int placementPoint)
        {
            var cellsOnGrid = new List<Vector2Int>();
            for (var i = 0; i < shapeTiles.Count; i++)
            {
                var index = shapeTiles[i] + placementPoint;
                cellsOnGrid.Add(index);
            }
            GridHandler.OnReselectionOfShape(cellsOnGrid);
        }

        public List<Vector2Int> GetShapeTileIndices()
        {
            return _view.GetTilesIndicesOfShape();
        }
    }
}