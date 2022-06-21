using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PTWO_PR {
    public class RestartGame : MonoBehaviour
    {
        [SerializeField]
        private GameObject player;
        
        [SerializeField]
        private GameObject restartText;

        private void Start()
        {
            restartText.SetActive(false);
        }

        private void Update() 
        {
            // if game is restarted set timescale to 1, if not set the game will still be paused through death script
            if (Input.GetKeyDown(KeyCode.F5))
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene("Gameplay");
            }

            // if player death show restart text
            if (player == null)
            { 
                restartText.SetActive(true);
            }
         

        }
    }
}