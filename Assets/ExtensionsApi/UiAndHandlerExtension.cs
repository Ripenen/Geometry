namespace ExtensionsApi
{
    public abstract class UiAndHandlerExtension : IUiExtension, IHandlerExtension
    {
        protected UiAndHandlerExtension(string name, UiElement uiPrefab)
        {
            Name = name;
            UiPrefab = uiPrefab;
        }

        public string Name { get; }
        public UiElement UiPrefab { get; }

        public abstract void DeInit();

        public abstract void InitUi(UiElement ui);

        public abstract ExtensionHandler InitHandler(Handler previousHandler);
    }
}