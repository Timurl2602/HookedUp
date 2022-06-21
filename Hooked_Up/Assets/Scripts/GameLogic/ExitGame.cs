using UnityEngine;
using UnityEngine.UI;

namespace PTWO_PR {
    public class ExitGame : MonoBehaviour {

        private Button button;

        private void Awake() 
        {
            button = GetComponent < Button > ();
        }

        private void Update() 
        {
            if (Input.GetKeyDown(KeyCode.Escape)) 
            {
                Application.Quit();
            }
        }

        private void OnEnable() 
        {
            button.onClick.AddListener(_ExitGame);
        }

        private void OnDisable() 
        {
            button.onClick.RemoveListener(_ExitGame);
        }

        private void _ExitGame() 
        {
            Application.Quit();
        }
    }
}