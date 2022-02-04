using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Base.Scripts.UI
{
    public class LevelMenu : MonoBehaviour
    {
        [SerializeField] private List<SceneAsset> _levels = new List<SceneAsset>();
        [SerializeField] private CustomButton _buttonPrefab;
        [SerializeField] private GameObject _contentObject;

        private void Awake()
        {
            foreach (var level in _levels)
            {
                var customButton = Instantiate(_buttonPrefab, _contentObject.transform);
                customButton.Change(level.name);
                customButton.Clicked.AddListener(() => SceneManager.LoadScene(level.name));
            }
        }
    }
}