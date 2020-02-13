using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target; //describes position
    public float smoothing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // last method called
    void LateUpdate()
    {
        if(transform.position != target.position) // camera position vs target position
        {
            Vector3 targetPosition = new Vector3(target.position.x,target.position.y,transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing); //linear interpelation moves % distance between target
        }
        
    }
}
