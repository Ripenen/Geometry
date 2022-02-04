using ExtensionsApi;
using UnityEngine;

namespace Base.Scripts
{
    public sealed class Cube : GeometryElement
    {
        public bool IsMoved { get; private set; }
        private void OnValidate()
        {
            transform.localScale = Vector2.one * ScaleSize;
        }

        public void MoveTo(Vector2 position)
        {
            transform.position = position;
            IsMoved = true;
        }

        public void DecreaseSize()
        {
            SetSize(Size - 1);
        }

        protected override void Handle(Handler handler)
        {
            handler.Handle(this);
        }
    }
}