namespace ExtensionsApi
{
    public interface IUiExtension : IExtension
    {
        public UiElement UiPrefab { get; }
        public void InitUi(UiElement ui);
    }
}