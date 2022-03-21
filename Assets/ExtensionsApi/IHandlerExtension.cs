namespace ExtensionsApi
{
    public interface IHandlerExtension : IExtension
    {
        public ExtensionHandler InitHandler(Handler previousHandler);
    }
}