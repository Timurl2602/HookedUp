using UnityEngine;
using UnityEngine.SceneManagement;

namespace PTWO_PR {
    public class PauseMenu : MonoBehaviour {

        [SerializeField]
        private GameObject pauseMenu;
        
        public static bool isPaused;

        
        private void Start() {
            pauseMenu.SetActive(false);
        }
        
        private void Update() 
        {
            if (Input.GetKeyDown(KeyCode.Escape)) 
            {
                if (isPaused) 
                {
                    ResumeGame();
                } else 
                {
                    PauseGame();
                }
            }
        }

        // stop game and show pause menu
        private void PauseGame() 
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            isPaused = true;
        }

        // if resumegame clicked, start playing game again and set pause menu on disabled
        private  void ResumeGame() 
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            isPaused = false;
        }

        // go back to main menu through pause menu
        private void GoToMainMenu() 
        {
            Time.timeScale = 1f;
            isPaused = false;
            SceneManager.LoadScene("MainMenu");
        }

        // quit game
        private void QuitGame() 
        {
            Application.Quit();
        }
    }
}