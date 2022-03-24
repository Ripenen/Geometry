using ExtensionsApi;

namespace Base.Scripts
{
    public class ElementsHandlerRouter<T> where T : GeometryElement
    {
        private readonly T[] _geometryElements;
        private readonly IElementHandler<T> _handler;

        public ElementsHandlerRouter(T[] geometryElements, IElementHandler<T> elementHandler)
        {
            _geometryElements = geometryElements;
            _handler = elementHandler;
        }

        public void Init()
        {
            foreach (var geometryElement in _geometryElements)
            {
                geometryElement.Clicked += GeometryElementOnClicked;
            }
        }

        public void DeInit()
        {
            foreach (var geometryElement in _geometryElements)
            {
                geometryElement.Clicked -= GeometryElementOnClicked;
            }
        }

        private void GeometryElementOnClicked(GeometryElement element)
        {
            _handler.Handle(element as T);
        }
    }
}