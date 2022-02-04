using Base.Scripts.UI;
using ExtensionsApi;
using UnityEngine;

namespace Base.Scripts
{
    public class LevelStarter : MonoBehaviour
    {
        [SerializeField] private GameUi _gameUi;

        private Handler _handler;
        private void Start()
        {
            var baseHandler = new BaseHandler(new Player());
            baseHandler.CubeMoved += _gameUi.UpdateMovesCounter;
            _gameUi.UpdateMovesCounter(0);
        
            _handler = baseHandler;
        
            InitExtensions();
        
            InitElements(_handler);
        }

        private void InitExtensions()
        {
            var extensionBehaviours = FindObjectsOfType<ExtensionBehaviour>();
        
            foreach (var extensionBehaviour in extensionBehaviours)
            {
                var availableExtension = extensionBehaviour.GetExtension();
                availableExtension.Init();

                if (availableExtension is IHandlerExtension handlerExtension)
                {
                    handlerExtension.InitHandler(_handler);

                    _handler = handlerExtension.Handler;
                }

                if (availableExtension is IUiExtension uiExtension)
                {
                    var ui = _gameUi.InstantiateUiElement(uiExtension.UiPrefab);
                    uiExtension.InitUi(ui);
                }
            }
        }
        private void InitElements(Handler handler)
        {
            var geometryElements = FindObjectsOfType<GeometryElement>();
        
            foreach (var geometryElement in geometryElements)
            {
                geometryElement.Init(handler);
            }
        }

        private void OnDestroy()
        {
            if(_handler is BaseHandler baseHandler)
                baseHandler.CubeMoved -= _gameUi.UpdateMovesCounter;
        }
    }
}