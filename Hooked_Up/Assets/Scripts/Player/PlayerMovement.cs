using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

namespace PTWO_PR {
   public class PlayerMovement : MonoBehaviour {

      [SerializeField]
      private float movementSpeed;
      
      [SerializeField]
      private float jumpForce;
      
      [SerializeField]
      private bool isGrounded = false;

      [SerializeField]
      private Animator animator;

      // for Groundedcheck Script
      public bool IsGrounded 
      {
         get {
            return isGrounded;
         }
         set {
            isGrounded = value;
         }
      }
      
      [SerializeField]
      private bool isFacingRight;

      [SerializeField]
      private Rigidbody2D rb;

      void Start() 
      {
         // initial facing direction right
         isFacingRight = true;

         rb = GetComponent < Rigidbody2D > ();
         
      }

      void Update() 
      {
         
         
         Jump();
         float horizontalInput = Input.GetAxis("Horizontal");

         // Horizontal Movement
         Vector3 movement = new Vector3(horizontalInput, 0f, 0f);
         transform.position += movement * (Time.deltaTime * movementSpeed);

         Flip(horizontalInput);
         
         // On Horizontal Movement play the Walking Animation, Mathf.Abs fixes that Animation is only playing while moving right
         animator.SetFloat("Speed", Mathf.Abs(horizontalInput));

         // Check if the Animator should play the jumping animation
         if (isGrounded == true)
         {
            animator.SetBool("IsJumping", false);
         }
         else
         {
            animator.SetBool("IsJumping", true);
         }
      }

      // Jump Logic & Check if Player is grounded & allowed to Jump
      void Jump() 
      {
         if (Input.GetButtonDown("Jump") && isGrounded == true) 
         {
            
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            animator.SetBool("IsJumping", true);
         }
      }

      // Flip Sprite in Movement Direction
      void Flip(float horizontal) 
      {

         if (horizontal > 0 && !isFacingRight || horizontal < 0 && isFacingRight) 
         {

            isFacingRight = !isFacingRight;

            // multiply x Scale to flip Player
            Vector3 playerScale = transform.localScale;

            playerScale.x *= -1;

            transform.localScale = playerScale;
         }
      }

      // Player death logic
      private void OnCollisionEnter2D(Collision2D collision) 
      {
         if (collision.gameObject.tag == "Enemy") 
         {
            Destroy(gameObject);
            Time.timeScale = 0f;

         }
      }

   }
}