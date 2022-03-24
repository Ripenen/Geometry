using Base.Scripts;
using Base.Scripts.UI;
using ExtensionsApi;

namespace Extensions.Triangle
{
    public class TriangleExtension : UiAndHandlerExtension
    {
        private UiElement _ui;
        private TriangleHandler _triangleHandler;
        private ElementsHandlerRouter<Triangle> _elementsHandlerRouter;

        private readonly int _startEnergy;
        private readonly Triangle[] _triangles;

        public TriangleExtension(UiElement uiPrefab, int startEnergy, Triangle[] triangles) : base(uiPrefab)
        {
            _startEnergy = startEnergy;
            _triangles = triangles;
        }

        public override void DeInit()
        {
            _triangleHandler.EnergyChanged -= _ui.Change;
            _elementsHandlerRouter.DeInit();
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

            _elementsHandlerRouter = new ElementsHandlerRouter<Triangle>(_triangles, _triangleHandler);
            _elementsHandlerRouter.Init();
            
            return _triangleHandler;
        }
    }
}