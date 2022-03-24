using System.Collections.Generic;
using Base.Scripts.UI;
using ExtensionsApi;
using UnityEngine;

namespace Base.Scripts
{
    public class LevelStarter : MonoBehaviour
    {
        [SerializeField] private GameUi _gameUi;

        private BaseHandler _handler;
        private readonly List<IExtension> _extensions = new List<IExtension>();

        private ElementsHandlerRouter<Cube> _cubeRouter;
        private ElementsHandlerRouter<Circle> _circleRouter;

        private void Start()
        {
            _handler = new BaseHandler(new Player());
            
            _handler.CubeMoved += _gameUi.UpdateMovesCounter;
            _gameUi.UpdateMovesCounter(0);

            var expandedHandler = InitExtensions(_handler);
            
            _cubeRouter = new ElementsHandlerRouter<Cube>(FindObjectsOfType<Cube>(), expandedHandler);
            _circleRouter = new ElementsHandlerRouter<Circle>(FindObjectsOfType<Circle>(), expandedHandler);
            
            _cubeRouter.Init();
            _circleRouter.Init();
        }

        private Handler InitExtensions(Handler handler)
        {
            var extensionBehaviours = FindObjectsOfType<ExtensionBehaviour>();

            foreach (var extensionBehaviour in extensionBehaviours)
            {
                var availableExtension = extensionBehaviour.GetExtension();
                _extensions.Add(availableExtension);

                if (availableExtension is IHandlerExtension handlerExtension)
                {
                    handler = handlerExtension.InitHandler(handler);
                }

                if (availableExtension is IUiExtension uiExtension)
                {
                    var ui = _gameUi.InstantiateUiElement(uiExtension.UiPrefab);
                    uiExtension.InitUi(ui);
                }
            }

            return handler;
        }

        private void OnDisable()
        {
            _handler.CubeMoved -= _gameUi.UpdateMovesCounter;

            foreach (var extension in _extensions)
            {
                extension.DeInit();
            }
            
            _cubeRouter.DeInit();
            _circleRouter.DeInit();
        }
    }
}