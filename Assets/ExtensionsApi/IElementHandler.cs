using Base.Scripts;

namespace ExtensionsApi
{
    public interface IElementHandler<in T> where T : GeometryElement
    {
        public void Handle(T geometryElement);
    }
}