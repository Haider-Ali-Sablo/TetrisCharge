using Sablo.Gameplay.Shape;
using UnityEngine;
using Grid = Sablo.Gameplay.Grid.Grid;

namespace Sablo.Core
{
    public class GameplayDependencyInjector : BaseDependencyInjector
    {
        [SerializeField] private Tray _tray;
        [SerializeField] private Grid _grid;
        
        public override void InjectDependencies()
        {
            _tray.GridHandler = _grid;
            _grid.TrayHandler = _tray;
        }
    }
}