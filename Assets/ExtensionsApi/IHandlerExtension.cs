namespace ExtensionsApi
{
    public interface IHandlerExtension : IExtension
    {
        public Handler Handler { get; }
        public void InitHandler(Handler previousHandler);
    }
}