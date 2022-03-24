using System.Threading.Tasks;
using ExtensionsApi;
using UnityEngine;

namespace Base.Scripts
{
    public sealed class Cube : GeometryElement
    {
        public bool IsMoved { get; private set; }

        public async void MoveTo(Vector3 position)
        {
            var direction = position - transform.position;
            
            while ((position - transform.position).sqrMagnitude > Mathf.Pow(0.01f, 2))
            {
                transform.Translate(direction * Time.deltaTime);
                await Task.Yield();
            }
            
            IsMoved = true;
        }

        public void DecreaseSize()
        {
            SetSize(Size - 1);
        }
    }
}