using UnityEngine;
using UnityEngine.UI;

namespace PTWO_PR {

    public class LevelProgressTracker: MonoBehaviour {

        [SerializeField]
        private Slider slider;

        [SerializeField]
        private Transform startPoint;

        [SerializeField]
        private Transform endPoint;

        [SerializeField]
        private Transform playerPosition;

        private void Update() 
        {
            // if player death dont track position anymore
            if (playerPosition != null) 
            {

                // math for tracking the player progress in the level
                // With - (minus) startPoint.x we assure that if the start position isnt always exactly 0 (zero)
                // only the distance between start and end will be counted towards the progress and not from zero on
                float Distance = (playerPosition.position.x - startPoint.position.x) /
                                 (endPoint.position.x - startPoint.position.x);

                // dont decrease slider if player is running towards start
                if (slider.value > Distance) 
                {
                    slider.value = slider.value;

                } else 
                {
                    slider.value = Distance;
                }
            }

        }
    }
}