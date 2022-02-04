namespace ExtensionsApi
{
    public interface IExtension
    {
        public string Name { get; }
        public void Init();
        public void DeInit();
    }
}