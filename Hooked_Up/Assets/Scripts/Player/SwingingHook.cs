using UnityEngine;

namespace PTWO_PR {

    public class SwingingHook : MonoBehaviour {

        [SerializeField]
        private Camera mainCamera;
        
        [SerializeField]
        private LineRenderer _lineRenderer;
        
        [SerializeField]
        private DistanceJoint2D _distanceJoint;
       
        [SerializeField]
        private Animator animator;
        
        
        void Start() {
            _distanceJoint.enabled = false;
        }
        
        void Update() 
        {
            
            // Hook not useable while Game is paused
            if (!PauseMenu.isPaused) 
            {

                // Draw line to Mouseclick 
                if (Input.GetKeyDown(KeyCode.Mouse0)) 
                {
                    Vector2 mousePos = (Vector2) mainCamera.ScreenToWorldPoint(Input.mousePosition);
                    _lineRenderer.SetPosition(0, mousePos);
                    _lineRenderer.SetPosition(1, transform.position);
                    _distanceJoint.connectedAnchor = mainCamera.ScreenToWorldPoint(Input.mousePosition);
                    _distanceJoint.enabled = true;
                    _lineRenderer.enabled = true;
                    // animation for roping
                    animator.SetBool("IsRoping",true);
                    
                } else if (Input.GetKeyUp(KeyCode.Mouse0)) 
                {
                    _distanceJoint.enabled = false;
                    _lineRenderer.enabled = false;
                    animator.SetBool("IsRoping",false);
                }
                if (_distanceJoint.enabled) 
                {
                    _lineRenderer.SetPosition(1, transform.position);
                }
            }
        }
    }
}


