using Base.Scripts.UI;
using ExtensionsApi;

namespace Extensions.Triangle
{
    public class TriangleExtension : UiAndHandlerExtension
    {
        private UiElement _ui;
        private readonly int _startEnergy;
        private TriangleHandler _triangleHandler;
        
        public TriangleExtension(string name, UiElement uiPrefab, int startEnergy) : base(name, uiPrefab)
        {
            _startEnergy = startEnergy;
        }

        public override void DeInit()
        {
            _triangleHandler.EnergyChanged -= _ui.Change;
        }

        public override void InitUi(UiElement instantiatedUi)
        {
            _ui = instantiatedUi;
        
            if(instantiatedUi is TextElement textElement)
                textElement.SetTextName("Energy: ");
        
            instantiatedUi.Change(_startEnergy);
            _triangleHandler.EnergyChanged += instantiatedUi.Change;
        }

        public override ExtensionHandler InitHandler(Handler previousHandler)
        {
            _triangleHandler = new TriangleHandler(previousHandler, new TrianglePlayer(_startEnergy));
            return _triangleHandler;
        }
    }
}