using UnityEngine;

namespace PTWO_PR {
    public class GroundedCheck: MonoBehaviour {

        GameObject Player;

        void Start() 
        {
            Player = gameObject.transform.parent.gameObject;
        }

        // Set Grounded check to true if Player hits Ground so he can Jump
        private void OnCollisionEnter2D(Collision2D collision) 
        {
            if (collision.collider.tag == "Ground") 
            {
                Player.GetComponent < PlayerMovement > ().IsGrounded = true;
            }
        }

        // Set Grounded check to false if Player the Player is still in the Air so he cant jump
        private void OnCollisionExit2D(Collision2D collision) 
        {
            if (collision.collider.tag == "Ground") 
            {
                Player.GetComponent < PlayerMovement > ().IsGrounded = false;
            }
        }
    }
}