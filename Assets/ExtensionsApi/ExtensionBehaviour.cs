using UnityEngine;

namespace ExtensionsApi
{
    public abstract class ExtensionBehaviour : MonoBehaviour
    {
        public abstract IExtension GetExtension();
    }
}