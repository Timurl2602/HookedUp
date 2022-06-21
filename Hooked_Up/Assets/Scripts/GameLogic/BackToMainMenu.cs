using UnityEngine.SceneManagement;
using UnityEngine;

namespace PTWO_PR {

    public class BackToMainMenu: MonoBehaviour {
        private void Update() 
        {
            if (Input.GetKeyDown(KeyCode.Escape)) 
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}