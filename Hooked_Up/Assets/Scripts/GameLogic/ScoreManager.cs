using TMPro;
using UnityEngine;

namespace PTWO_PR {

    public class ScoreManager: MonoBehaviour {

        [SerializeField]
        private Transform player;
        
        [SerializeField]
        private TMP_Text meterTraveled;
        
        [SerializeField]
        private TMP_Text highscore;

        [SerializeField]
        private float meter;
        
        [SerializeField]
        private float highscoreCount;

        private void Start() 
        {
            // set highscore & save highscore with Playerprefs
            if (PlayerPrefs.GetFloat("HighScore") != 0) 
            {
                highscoreCount = PlayerPrefs.GetFloat("HighScore");
            }
        }

        private void Update() 
        {
            // Dont track Player position if hes death -> fixes console error
            if (player != null) 
            {

                // the player position is the meter count
                meter = player.position.x;

                // set new highscore if meters tracked are greater than current highscore
                if (meter > highscoreCount) 
                {
                    highscoreCount = meter;
                    PlayerPrefs.SetFloat("HighScore", highscoreCount);
                }

                // setting format and text to unity component
                meterTraveled.text = "Meter: " + meter.ToString("0");
                highscore.text = "Highscore: " + highscoreCount.ToString("0");

            }

        }
    }
}