using Base.Scripts;
using JetBrains.Annotations;

namespace ExtensionsApi
{
    public abstract class Handler
    {
        [CanBeNull] protected GeometryElement SelectedElement;
    
        public abstract void Handle(Cube cube);

        public abstract void Handle(Circle circle);
    }
}