using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Base.Scripts
{
    public abstract class GeometryElement : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private int _size;
        public event Action<GeometryElement> Clicked;
        
        public int Size => _size;
        private float ScaleSize => (float)_size / 10;
        protected virtual Vector3 CalculateScale(float size) => Vector2.one * size;

        private void OnValidate()
        {
            transform.localScale = CalculateScale(ScaleSize);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Clicked?.Invoke(this);
        }

        protected void SetSize(int size)
        {
            if (size <= 0)
                throw new ArgumentOutOfRangeException();
            
            _size = size;
            OnValidate();
        }
    }
}