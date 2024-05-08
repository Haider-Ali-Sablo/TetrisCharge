using UnityEngine;
using UnityEngine.UI;

namespace Sablo.Gameplay.Grid
{
    public class Tile: MonoBehaviour
    {
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private Button _tileButton;
        [SerializeField] private Vector2Int _index;
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
            _tileButton.onClick.AddListener(OnTileClicked);
        }

        private void OnTileClicked()
        {
            
        }
    }
    
}