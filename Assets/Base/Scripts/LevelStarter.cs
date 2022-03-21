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
        
        private void Start()
        {
            _handler = new BaseHandler(new Player());
            _handler.CubeMoved += _gameUi.UpdateMovesCounter;
            _gameUi.UpdateMovesCounter(0);
        
            InitExtensions(_handler);
        
            InitElements(_handler);
        }

        private void InitExtensions(Handler handler)
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
        }
        private void InitElements(Handler handler)
        {
            var geometryElements = FindObjectsOfType<GeometryElement>();
        
            foreach (var geometryElement in geometryElements)
            {
                geometryElement.Init(handler);
            }
        }

        private void OnDisable()
        {
            _handler.CubeMoved -= _gameUi.UpdateMovesCounter;

            foreach (var extension in _extensions)
            {
                extension.DeInit();
            }
        }
    }
}