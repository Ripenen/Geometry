using Base.Scripts;

namespace Extensions.Triangle
{
    public sealed class Triangle : GeometryElement
    {
        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}