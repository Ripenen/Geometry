using Base.Scripts;
using ExtensionsApi;
using UnityEngine;

namespace Extensions.Triangle
{
    public class TriangleBehaviour : ExtensionBehaviour
    {
        [SerializeField] private int _startEnergy;
        [SerializeField] private UiElement _energyText;
    
        public override IExtension GetExtension()
        {
            return new TriangleExtension(_energyText, _startEnergy, FindObjectsOfType<Triangle>());
        }
    }
}