using ExtensionsApi;
using UnityEngine;

namespace Extensions.Triangle
{
    public class TriangleBehaviour : ExtensionBehaviour
    {
        [SerializeField] private int _startEnergy;
    
        public override IExtension GetExtension()
        {
            return new TriangleExtension(_startEnergy);
        }
    }
}