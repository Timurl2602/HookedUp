using UnityEngine;

namespace PTWO_PR {

    public class Parallax: MonoBehaviour {
        
        [SerializeField]
        private Camera cam;

        [SerializeField]
        private Transform subject;

        Vector2 startPosition;

        float startZ;

        Vector2 travel => (Vector2) cam.transform.position - startPosition;

        float distanceFromSubject => transform.position.z - subject.position.z;

        float clippingPlane => (cam.transform.position.z + (distanceFromSubject > 0 ? cam.farClipPlane : cam.nearClipPlane));

        float parallaxFactor => Mathf.Abs(distanceFromSubject) / clippingPlane;

        private void Start() 
        {
            startPosition = transform.position;
            startZ = transform.position.z;
        }

        private void Update() 
        {
            // Dont track Player position if hes death -> fixes console error
            if (subject != null) 
            {
                Vector2 newPos = transform.position = startPosition + travel * parallaxFactor;
                transform.position = new Vector3(newPos.x, newPos.y, startZ);
            }
        }
    }
}