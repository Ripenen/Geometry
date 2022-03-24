using UnityEngine;

namespace Base.Scripts
{
    public sealed class Circle : GeometryElement
    {
        public bool IsBusy { get; private set; }
        
        private const float Ratio = 1.45f;
        public void MakeBusy() => IsBusy = true;
        protected override Vector3 CalculateScale(float size) =>Vector2.one * size * Ratio;
    }
}