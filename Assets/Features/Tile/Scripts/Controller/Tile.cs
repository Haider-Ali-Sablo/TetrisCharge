using UnityEngine;

namespace Sablo.Gameplay.Grid
{
    public class Tile: MonoBehaviour
    {
        [SerializeField] private Transform _modelTransform;
        [SerializeField] private Vector2Int _index;
        [SerializeField] private GameObject _switch;
        public float height => _modelTransform.localScale.y;
        public float width => _modelTransform.localScale.z;
        
        public void Initialize()
        {
            Register();
        }

        public Vector2Int GetTileIndex()
        {
            return _index;
        }
        
        private void Register()
        {
           
        }

        public void HighlightTile()
        {
            
        }

        public void RemoveHighlight()
        {
            
        }

        public Vector2 GetPosition()
        {
            return transform.position;
        }

        public void ActivateSwitch()
        {
            
        }

        public bool HasActiveSwitch()
        {
            return false;
        }
    }
}