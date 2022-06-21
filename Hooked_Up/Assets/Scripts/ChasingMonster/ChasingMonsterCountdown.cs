using TMPro;
using UnityEngine;

namespace PTWO_PR {
    public class ChasingMonsterCountdown : MonoBehaviour {

        [SerializeField]
        private GameObject chasingMonster;

        [SerializeField]
        private float timeRemaining;

        [SerializeField]
        private bool isTimerRunning = false;

        [SerializeField]
        private bool isInternalCountDownRunning = false;

        [SerializeField]
        private float internalCountdown;

        [SerializeField]
        private TMP_Text chasingMonsterText;

        // Start is called before the first frame update
        private void Start() 
        {
            chasingMonsterText.enabled = false;
            // start timer on game start
            isTimerRunning = true;
        }

        // Update is called once per frame
        private void Update() 
        {
            
            // Countdown for Firewall to spawn & set internal cooldown for text
            if (isTimerRunning == true) 
            {
                Debug.Log(timeRemaining);
                timeRemaining -= Time.deltaTime;
                isInternalCountDownRunning = true;
            }

            // Text internal cooldown starts running if game start through code above^
            if (isInternalCountDownRunning == true) 
            {
                internalCountdown -= Time.deltaTime;
            }

            // if the internal countdown reached 0, show the "Death is coming" message
            if (internalCountdown <= 0) 
            {
                chasingMonsterText.enabled = true;
            }

            // if main cooldown reached 0, spawn the firewall & set it active and stop every timer
            if (timeRemaining <= 0) 
            {
                isTimerRunning = false;
                chasingMonster.SetActive(true);
                timeRemaining = 10;
                isInternalCountDownRunning = false;
                internalCountdown = 3;
                chasingMonsterText.enabled = false;
            }

        }

    }
}