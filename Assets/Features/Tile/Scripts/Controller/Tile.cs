using UnityEngine;
using UnityEngine.UI;

namespace Sablo.Gameplay.Grid
{
    public class Tile: MonoBehaviour
    {
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private Button _tileButton;
        [SerializeField] private Vector2Int _index;
        [SerializeField] private GameObject _overlayImage;
        public float height => _rectTransform.rect.height;
        
        public void Initialize()
        {
            Register();
        }

        public Vector2Int GetTileIndex()
        {
            return _index;
        }
        
        private void Start()
        {
            Register();
        }
        private void Register()
        {
            // _tileButton.onClick.AddListener(OnTileClicked);
        }

        private void OnTileClicked()
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
        
    }
    
}