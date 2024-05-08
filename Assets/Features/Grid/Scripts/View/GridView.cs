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
            var screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2);
            _startingPosition = screenCenter - new Vector2(_model.GridWidth* _model.CellOffset / 2, _model.GridHeight * _model.CellOffset / 2);
        }

        public Tile SpawnTile(Vector2 position)
        {
            position.x += _startingPosition.x;
            position.y += _startingPosition.y;
            
            var tile = Instantiate(_refs.DefaultTile, position, Quaternion.identity, _refs.SpawnPoint);
            tile.Initialize();
            return tile;
        }
        
    }
}