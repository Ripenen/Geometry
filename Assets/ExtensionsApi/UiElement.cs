using UnityEngine;

namespace ExtensionsApi
{
    public abstract class UiElement : MonoBehaviour
    {
        public virtual void Change(string text)
        {
            throw new System.NotImplementedException();
        }
    
        public virtual void Change(int value)
        {
            throw new System.NotImplementedException();
        }
    }
}