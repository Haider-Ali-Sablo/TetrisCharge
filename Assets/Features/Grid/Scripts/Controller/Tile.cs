using UnityEngine;

namespace Sablo.Gameplay.Grid
{
    public class Tile: MonoBehaviour
    {
        [SerializeField]
        private RectTransform _rectTransform;
        public float height => _rectTransform.rect.height;
        
        public void Initialize()
        {
            
        }
    }
}