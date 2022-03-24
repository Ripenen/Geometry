namespace ExtensionsApi
{
    public abstract class UiAndHandlerExtension : IUiExtension, IHandlerExtension 
    {
        protected UiAndHandlerExtension(UiElement uiPrefab)
        {
            UiPrefab = uiPrefab;
        }

        public UiElement UiPrefab { get; }

        public abstract void DeInit();

        public abstract void InitUi(UiElement ui);

        public abstract ExtensionHandler InitHandler(Handler previousHandler);
    }
}