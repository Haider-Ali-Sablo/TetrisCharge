using Sablo.Core;
using Sablo.Gameplay.Grid;
using UnityEngine;

namespace Sablo.UI.Grid
{
    public class GridView : BaseView
    {
        [SerializeField] private GridViewRefs _refs;
        private Vector2 _startingPosition;
        private GridViewDataModel _model;
        
        public override void Initialize(object model)
        {
            _model = model as GridViewDataModel;
            CalculateStartingPosition();
        }
        
        private void CalculateStartingPosition()
        {
            var gridWidthPixels = _model.GridWidth * _model.CellOffset;
            var gridHeightPixels = _model.GridHeight * _model.CellOffset;
            var heightFactor = Configs.GameConfig.HeightDividingFactor;
            var widthFactor = Configs.GameConfig.WidthDividingFactor;
            
            _startingPosition = new Vector2(Screen.width / widthFactor - gridWidthPixels / widthFactor, Screen.height / heightFactor - gridHeightPixels / heightFactor);
        }


        public Tile SpawnTile(Vector3 position)
        {
            var tile = Instantiate(_model.DefaultTile, position, Quaternion.identity, _refs.GridTransform);
            tile.Initialize();
            return tile;
        }

        public bool IsWithInBoundsOfGrid(Vector2 position)
        {
            var isWithinBounds = false;
            return isWithinBounds;
        }
    }
}