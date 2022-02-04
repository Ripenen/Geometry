using UnityEngine;

namespace ExtensionsApi
{
    [CreateAssetMenu]
    public class ExtensionSettings : ScriptableObject
    {
        [SerializeField] private UiElement _uiPrefabs;

        public UiElement UiPrefab => _uiPrefabs;
    }
}