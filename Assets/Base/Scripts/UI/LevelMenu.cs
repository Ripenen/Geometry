using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Base.Scripts.UI
{
    public class LevelMenu : MonoBehaviour
    {
        [SerializeField] private List<string> _levelNames = new List<string>();
        [SerializeField] private CustomButton _buttonPrefab;
        [SerializeField] private GameObject _contentObject;

        private void Awake()
        {
            foreach (var level in _levelNames)
            {
                var customButton = Instantiate(_buttonPrefab, _contentObject.transform);
                customButton.Change(level);
                customButton.Clicked.AddListener(() => SceneManager.LoadScene(level));
            }
        }
    }
}