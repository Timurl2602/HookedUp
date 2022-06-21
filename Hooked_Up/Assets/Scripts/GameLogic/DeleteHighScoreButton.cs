using UnityEngine;

namespace PTWO_PR {
    public class DeleteHighScoreButton : MonoBehaviour {

        private void DeleteHighScore()
        {
            // Because we only save one value / key to the Playerprefs this works. Otherwise with multiple Keys we would use "DeleteKey("NAME")"
            PlayerPrefs.DeleteAll();
        }
    }
}