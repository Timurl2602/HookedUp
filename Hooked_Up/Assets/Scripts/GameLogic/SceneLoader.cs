using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace PTWO_PR {
    public class SceneLoader : MonoBehaviour {
        
        [SerializeField]
        private string sceneToLoad;

        [SerializeField]
        private Button button;

        private void Awake() 
        {
            button = GetComponent < Button > ();
        }

        private void OnEnable() 
        {
            button.onClick.AddListener(LoadScene);
        }

        private void OnDisable() 
        {
            button.onClick.RemoveListener(LoadScene);
        }

        private void LoadScene() 
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}