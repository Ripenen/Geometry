using ExtensionsApi;
using UnityEngine;
using UnityEngine.UI;

namespace Base.Scripts.UI
{
    public class TextElement : UiElement
    {
        [SerializeField] private Text _text;
        private string _textName;

        public void SetTextName(string text)
        {
            _textName = text;
        }
        public override void Change(string text)
        {
            _text.text = string.Concat(_textName, text);
        }

        public override void Change(int value)
        {
            Change(value.ToString());
        }
    }
}