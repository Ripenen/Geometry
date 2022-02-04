using ExtensionsApi;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Base.Scripts.UI
{
    [RequireComponent(typeof(Button))]
    public class CustomButton : UiElement
    {
        [SerializeField] private Text _text;
    
        private Button _button;
    
        public UnityEvent Clicked => _button.onClick;
    

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        public override void Change(string text)
        {
            _text.text = text;
        }
    }
}