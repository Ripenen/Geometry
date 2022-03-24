using Base.Scripts;

namespace ExtensionsApi
{
    public abstract class Handler : IElementHandler<Cube>, IElementHandler<Circle>
    {
        protected GeometryElement SelectedElement;
    
        public abstract void Handle(Cube cube);

        public abstract void Handle(Circle circle);
    }
}