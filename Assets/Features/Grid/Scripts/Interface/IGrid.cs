using UnityEngine;

namespace Sablo.Gameplay.Grid
{
    public interface IGrid
    {
        void IsWithinBoundsOfGrid(Vector2 position, Vector2 plugPosition);
    }
}