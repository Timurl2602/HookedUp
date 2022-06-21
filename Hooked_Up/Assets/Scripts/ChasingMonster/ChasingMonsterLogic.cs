using UnityEngine;

namespace PTWO_PR {

    public class ChasingMonsterLogic : MonoBehaviour 
    {
        [SerializeField]
        private float movementSpeed;
        
        private void Update() 
        {
            Vector3 movement = new Vector3(1, 0f, 0f);
            transform.position += movement * (Time.deltaTime * movementSpeed);
        }
    }
}