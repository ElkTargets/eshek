using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCameraController : MonoBehaviour
{
    public Camera cam;
    
        private Vector3 initialPosition;
        private Vector3 startPosition;
        private Vector3 targetPosition;
        private float camMovePercent;
    
    	void Start ()
            {
                initialPosition = cam.transform.position;
                startPosition = initialPosition;
                targetPosition = initialPosition + (Random.insideUnitSphere * 2);
    	}
    	
    	void FixedUpdate ()
            {
                if (cam.transform.position != targetPosition)
                {
                    camMovePercent += 0.001f;
                    cam.transform.position = Vector3.Lerp(startPosition, targetPosition, camMovePercent);
                }
                else 
                {
                    camMovePercent = 0f;
                    startPosition = cam.transform.position;
                    targetPosition = initialPosition + (Random.insideUnitSphere * 2);
                }
    	}
}
