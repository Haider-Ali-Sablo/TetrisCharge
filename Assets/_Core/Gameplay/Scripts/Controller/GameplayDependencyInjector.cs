using Sablo.Gameplay.Shape;
using UnityEngine;
using Sablo.Gameplay.LevelProgress;
using Grid = Sablo.Gameplay.Grid.Grid;


namespace Sablo.Core
{
    public class GameplayDependencyInjector : BaseDependencyInjector
    {
        [SerializeField] private Tray _tray;
        [SerializeField] private Grid _grid;
        [SerializeField] private LevelProgression _levelProgression;
        [SerializeField] private SfxController _sfx;
        
        public override void InjectDependencies()
        {
            _tray.GridHandler = _grid;
            _grid.TrayHandler = _tray;
            _grid.LevelProgressionHandler = _levelProgression;
            _levelProgression.TrayHandler = _tray;
            _levelProgression.SfxHandler = _sfx;
        }
    }
}