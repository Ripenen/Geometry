using Base.Scripts.UI;
using ExtensionsApi;
using UnityEngine;

namespace Extensions.Triangle
{
    public class TriangleExtension : IUiExtension, IHandlerExtension
    {
        public string Name => "Triangle";
        public Handler Handler { get; private set; }
        public UiElement UiPrefab { get; private set; }

        private UiElement _ui;
        private readonly int _startEnergy;

        public TriangleExtension(int startEnergy)
        {
            _startEnergy = startEnergy;
        }

        public void Init()
        {
            var settings = Resources.Load<ExtensionSettings>(Name);
            UiPrefab = settings.UiPrefab;
        }

        public void InitHandler(Handler previousHandler)
        {
            var handler = new TriangleHandler(previousHandler, new TrianglePlayer(_startEnergy));
        
            Handler = handler;
        }

        public void InitUi(UiElement instantiatedUi)
        {
            _ui = instantiatedUi;
        
            if(instantiatedUi is TextElement textElement)
                textElement.SetTextName("Energy: ");
        
            instantiatedUi.Change(_startEnergy);
            ((TriangleHandler) Handler).EnergyChanged += instantiatedUi.Change;
        }

        public void DeInit()
        {
            ((TriangleHandler) Handler).EnergyChanged -= _ui.Change;
        }
    }
}