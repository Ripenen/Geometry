using Base.Scripts;

namespace ExtensionsApi
{
    public abstract class Handler
    {
        protected GeometryElement SelectedElement;
    
        public abstract void Handle(Cube cube);

        public abstract void Handle(Circle circle);
    }
}