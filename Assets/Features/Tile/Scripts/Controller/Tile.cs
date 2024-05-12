using UnityEngine;

namespace Sablo.Gameplay.Grid
{
    public class Tile: MonoBehaviour
    {
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private Vector2Int _index;
        [SerializeField] private GameObject _overlayImage;
        [SerializeField] private GameObject _switch;
        public float height => _rectTransform.rect.height;
        
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
            _overlayImage.SetActive(true);
        }

        public void RemoveHighlight()
        {
            _overlayImage.SetActive(false);
        }

        public Vector2 GetPosition()
        {
            return _rectTransform.position;
        }

        public void ActivateSwitch()
        {
            _switch.SetActive(true);
        }

        public bool HasActiveSwitch()
        {
            return _switch.activeSelf;
        }
    }
}