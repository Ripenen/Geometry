using Base.Scripts;

namespace ExtensionsApi
{
    public abstract class ExtensionHandler : Handler
    {
        private readonly Handler _handler;

        protected ExtensionHandler(Handler handler)
        {
            _handler = handler;
        }

        public override void Handle(Cube cube)
        {
            _handler.Handle(cube);
        }

        public override void Handle(Circle circle)
        {
            _handler.Handle(circle);
        }
    }
}