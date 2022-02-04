using ExtensionsApi;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Base.Scripts
{
    public abstract class GeometryElement : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private int _size;
        private Handler _handler;

        public int Size => _size;
        protected float ScaleSize => (float)_size / 10;

        private  void OnValidate()
        {
            RecalculateSize();
        }

        public void Init(Handler handler)
        {
            _handler = handler;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Handle(_handler);
        }

        protected virtual void RecalculateSize()
        {
            transform.localScale = Vector2.one * ScaleSize;
        }
        protected abstract void Handle(Handler handler);

        protected void SetSize(int size)
        {
            _size = size;
            RecalculateSize();
        }
    }
}