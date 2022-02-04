using Base.Scripts;
using ExtensionsApi;

namespace Extensions.Triangle
{
    public sealed class Triangle : GeometryElement
    {
        public void Destroy()
        {
            Destroy(gameObject);
        }
        protected override void Handle(Handler handler)
        {
            if(handler is TriangleHandler triangle)
                triangle.Handle(this);
        }
    }
}