using ExtensionsApi;
using UnityEngine;

namespace Base.Scripts.UI
{
    public class GameUi : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private UiElement _movesCounter;
    
        public UiElement InstantiateUiElement(UiElement prefab)
        {
            return Instantiate(prefab, _canvas.transform);
        }

        public void UpdateMovesCounter(int value)
        {
            var result = string.Concat("Moves: ", value.ToString());
        
            _movesCounter.Change(result);
        }
    }
}