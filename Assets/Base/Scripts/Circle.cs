using ExtensionsApi;
using UnityEngine;

namespace Base.Scripts
{
    public sealed class Circle : GeometryElement
    {
        public bool IsBusy { get; private set; }
        
        private const float Ratio = 1.45f;
        public void MakeBusy() => IsBusy = true;
        protected override void RecalculateSize()
        {
            transform.localScale = Vector2.one * ScaleSize * Ratio;
        }

        protected override void Handle(Handler handler)
        {
            handler.Handle(this);
        }
    }
}